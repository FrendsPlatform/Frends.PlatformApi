using System.Threading;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using Frends.PlatformApi.Request.Definitions;
using Newtonsoft.Json;

namespace Frends.PlatformApi.Request.Tests;

[TestFixture]
internal class UnitTests
{
    private static readonly string ApplicationId = Environment.GetEnvironmentVariable("APPLICATION_ID");
    private static readonly string ClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
    private readonly string tenantUrl = Environment.GetEnvironmentVariable("TENANT_URL");

    private readonly string applicationUri = $"api://{ApplicationId}";
    private static readonly string TestDir = Path.Join(Directory.GetCurrentDirectory(), "TestData");
    private static readonly string DownloadPath = Path.Join(TestDir, "downloads");
    private Input input;
    private Options options;

    private readonly string apiSpecFile = Path.Join(TestDir, "TaskTest.yaml");

    [SetUp]
    public void SetUp()
    {
        input = new Input
        {
            Url = tenantUrl,
            Token = null,
            Method = Methods.Get,
            DownloadPath = null,
            FilePaths = null,
            IsMultipart = false,
            ManualParameters = null,
            Message = null,
            ApplicationId = ApplicationId,
            ApplicationUri = applicationUri,
            ClientSecret = ClientSecret,
            GeneratedToken = true
        };

        options = new Options
        {
            ThrowExceptionOnError = true,
            Timeout = 10,
        };
    }

    [TearDown]
    public void OneTimeTearDown()
    {
        if (Directory.Exists(@$"C:\temp"))
            Directory.Delete(@$"C:\temp", true);
    }

    [Test]
    public async Task Get_With_DownloadPath_Works_Correctly()
    {
        var path = Path.Join(DownloadPath + $"Test_Get_processes_export_{Guid.NewGuid().ToString("N")[..4]}");
        input.DownloadPath = path;
        input.Url = tenantUrl + "api/v1/processes/1126/export";
        var ret = await PlatformApi.Request(input, options, CancellationToken.None);
        Assert.That(ret.Success);
        Assert.That(ret.ErrorMessage, Is.Null);
        Assert.That(ret.Data.Contains("downloaded"));
        Assert.That(File.Exists(path + ".json_"));
    }

    [Test]
    public async Task Get_With_DownloadPath_Fails_When_No_Data_Found()
    {
        var path = Path.Join(DownloadPath + $"Test_Get_processes_export_{Guid.NewGuid().ToString("N")[..4]}");
        input.DownloadPath = path;
        input.Url = tenantUrl + $"api/v1/processes/{Guid.NewGuid()}/export";
        var ret = await PlatformApi.Request(input, options, CancellationToken.None);
        Assert.That(ret.Success, Is.False);
        Assert.That(ret.ErrorMessage, Does.Contain("There is no data to write to the file."));
    }

    [Test]
    public async Task Post_With_FilePaths_Works_Correctly()
    {
        input.Method = Methods.Post;
        input.Url = tenantUrl + "api/v1/api-management/api-specifications/import";
        input.IsMultipart = true;
        input.FilePaths = new[]
        {
            new SendFileParameters
            {
                FileParameterKey = FileParameterKey.File,
                Fullpath = apiSpecFile,
            },
        };

        var ret = await PlatformApi.Request(input, options, CancellationToken.None);

        Assert.That(ret.Success);
        Assert.That(ret.ErrorMessage, Is.Null);
        Assert.That(ret.Data, Is.Not.Null);

        int apiSpecId = JsonConvert.DeserializeObject<dynamic>(ret.Data.Content.ToString()).data.id;
        await DeleteApiSpec(apiSpecId);
    }

    [Test]
    public async Task Simple_Get_Works_Correctly()
    {
        input.Url = tenantUrl + "/api/v1/api-management/api-specifications";
        var ret = await PlatformApi.Request(input, options, CancellationToken.None);
        Assert.That(ret.Success);
        Assert.That(ret.ErrorMessage, Is.Null);
        Assert.That(ret.Data, Is.Not.Null);
    }

    [Test]
    public async Task ManualParameters_Added_ToQuery()
    {
        input.Url = tenantUrl +
                    "api/v1/api-management/access/api-keys?pagingQuery.pageSize=10";
        input.ManualParameters = new[]
        {
            new ManualParameters
            {
                Key = "pagingQuery.pageNumber",
                Value = "999",
                ParameterType = ParameterTypes.QueryString,
            },
        };
        var ret = await PlatformApi.Request(input, options, CancellationToken.None);
        Assert.That(ret.Success);
        Assert.That(ret.ErrorMessage, Is.Null);
        Assert.That(ret.Data, Does.Contain("\"data\":[],"));
    }

    private async Task DeleteApiSpec(int apiSpecId)
    {
        input.Method = Methods.Delete;
        input.Url = $"{tenantUrl}api/v1/api-management/api-specifications/{apiSpecId}/agent-group/51";
        input.IsMultipart = false;
        input.FilePaths = null;
        await PlatformApi.Request(input, options, CancellationToken.None);
    }
}
