namespace Frends.PlatformApi.Request.Tests;

using Frends.PlatformApi.Request.Definitions;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.IO;
using System.Threading.Tasks;

[TestFixture]
internal class UnitTests
{
    /// <summary>
    /// These tests cannot be tested in Github. Set your own tenant and token etc. and test locally.
    /// </summary>
    private readonly string managementAPIApplicationId = Environment.GetEnvironmentVariable("ManagementAPIApplicationId");
    private readonly string managementAPIClientSecret = Environment.GetEnvironmentVariable("managementAPIClientSecret");
    private readonly string managementAPIApplicationURI = Environment.GetEnvironmentVariable("ManagementAPIApplicationURI");
    private readonly string testTenant = Environment.GetEnvironmentVariable("TestTenant");
    private readonly string downloadPath = @$"C:\temp\PlatformApiTest\{DateTime.Now}\";
    private Input input = new();
    private Options options = new();
    private readonly string _apiKeyName = $"TaskTestApiKeyName_{Guid.NewGuid()}";
    private int _apikeyId = 0;
    private readonly string _rulesetName = "TaskTestRuleSet";
    private int _rulesetId = 0;
    private readonly string _apiSpecFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "TaskTest.yaml");
    private int _apiSpecId = 0;

    [SetUp]
    public void SetUp()
    {
        this.input = new Input
        {
            Url = testTenant,
            Token = null,
            Method = Methods.Get,
            DownloadPath = null,
            FilePaths = null,
            IsMultipart = false,
            ManualParameters = null,
            Message = null,
            ApplicationId = managementAPIApplicationId,
            ApplicationUri = managementAPIApplicationURI,
            ClientSecret = managementAPIClientSecret,
            GeneratedToken = true
        };

        this.options = new Options
        {
            ThrowExceptionOnError = true,
            Timeout = 10,
        };
    }

    [TearDown]
    public async Task OneTimeTearDown()
    {
        if (Directory.Exists(@$"C:\temp\PlatformApiTest"))
            Directory.Delete(@$"C:\temp\PlatformApiTest", true);

        if (_apikeyId > 0) await DeleteApiKey();
        if (_rulesetId > 0) await DeleteRuleset();
        if (_apiSpecId > 0) await DeleteApiSpec();
    }

    [Test]
    public async Task Test_Get_apikeys()
    {
        this.input.Url = testTenant + "api/v1/api-management/access/api-keys/1";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_apirulesets()
    {
        this.input.Url = testTenant + "api/v1/api-management/access/api-rulesets/1";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_apikeys_name()
    {
        this.input.Url = testTenant + "api/v1/api-management/access/api-keys/name/test";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_apirulesets_name()
    {
        this.input.Url = testTenant + "api/v1/api-management/access/api-rulesets/name/FrendsAcademy";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_api_rulesets()
    {
        this.input.Url = testTenant + "api/v1/api-management/access/api-rulesets?pagingQuery.pageNumber=1&pagingQuery.pageSize=1";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_api_apikeys()
    {
        this.input.Url = testTenant + "api/v1/api-management/access/api-keys?environmentId=51&pagingQuery.pageNumber=1&pagingQuery.pageSize=1";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_api_specifications()
    {
        this.input.Url = testTenant + "api/v1/api-management/api-specifications/3";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_api_specifications_2()
    {
        this.input.Url = testTenant + "api/v1/api-management/api-specifications/3/1";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_api_specifications_3()
    {
        this.input.Url = testTenant + "api/v1/api-management/api-specifications?pagingQuery.pageNumber=1&pagingQuery.pageSize=1";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_environments()
    {
        this.input.Url = testTenant + "api/v1/environments";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_agent_groups()
    {
        this.input.Url = testTenant + "api/v1/agent-groups/51";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_environments_2()
    {
        this.input.Url = testTenant + "api/v1/environments/51";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_environments_agent_groups2()
    {
        this.input.Url = testTenant + "api/v1/environments/51/agent-groups";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_environment_variables()
    {
        this.input.Url = testTenant + "api/v1/environment-variables/1";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_environment_variables_2()
    {
        this.input.Url = testTenant + "api/v1/environment-variables?environmentVariableName=ManagementAPI&pagingQuery.pageNumber=1&pagingQuery.pageSize=1";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_processes()
    {
        this.input.Url = testTenant + "api/v1/processes/1";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_processes_export()
    {
        var path = downloadPath + @$"Test_Get_processes_export_{DateTime.Now}";
        this.input.DownloadPath = path;
        this.input.Url = testTenant + "api/v1/processes/1/export";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data.Contains("downloaded"));
        ClassicAssert.IsTrue(File.Exists(path + ".json_"));
    }

    [Test]
    public async Task Test_Get_processes_2()
    {
        this.input.Url = testTenant + "api/v1/processes/6933c9e1-95f4-4494-a630-d3d6b36f7006/versions/2";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Get_processes_batch_export()
    {
        var path = downloadPath + @$"Test_Get_processes_export_{DateTime.Now}";
        this.input.DownloadPath = path;
        this.input.Url = testTenant + "api/v1/processes/batch-export?ids=1";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data.Contains("downloaded"));
        ClassicAssert.IsTrue(File.Exists(path + ".json_"));
    }

    [Test]
    public async Task Test_Post_Create_apikeys()
    {
        this.input.Method = Methods.Post;
        this.input.Url = testTenant + "api/v1/api-management/access/api-keys";
        this.input.Message = $@"{{
  ""name"": ""{_apiKeyName}"",
  ""rulesetIds"": [
    1
  ],
  ""requestLimit"": 1,
  ""requestLimitPeriod"": ""Minute"",
  ""environmentId"": 51
}}";

        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);

        _apikeyId = JsonConvert.DeserializeObject<dynamic>(ret.Data.ToString()).data.id;
    }

    [Test]
    public async Task Test_Post_Create_rulesets()
    {
        this.input.Method = Methods.Post;
        this.input.Url = testTenant + "api/v1/api-management/access/api-rulesets";
        this.input.Message = $@"{{
  ""name"": ""{_rulesetName}"",
  ""description"": ""Testing Management API Task. Can be deleted."",
  ""apiRules"": [
    {{
      ""method"": ""Any"",
      ""path"": ""string""
    }}
  ]
}}";

        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
        _rulesetId = JsonConvert.DeserializeObject<dynamic>(ret.Data.ToString()).data.id;
    }

    [Test]
    public async Task Test_Post_Create_apispecifications_Import()
    {
        this.input.Method = Methods.Post;
        this.input.Url = testTenant + "api/v1/api-management/api-specifications/import";
        this.input.IsMultipart = true;
        this.input.FilePaths = new[] { new SendFileParameters() { FileParameterKey = FileParameterKey.File, Fullpath = _apiSpecFile } };

        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);

        _apiSpecId = JsonConvert.DeserializeObject<dynamic>(ret.Data.Content.ToString()).data.id;
    }

    [Test]
    public async Task Test_Put_RuleSet_Rename()
    {
        //_apikeyId = await CreateApiKey();
        _rulesetId = await CreateRuleSet();
        this.input.Method = Methods.Put;
        this.input.Url = $@"{testTenant}api/v1/api-management/access/api-rulesets/{_rulesetId}";
        this.input.Message = $@"{{
  ""name"": ""NewName{DateTime.Now}"",
  ""description"": ""this is new desc {DateTime.Now}"",
  ""apiRules"": [
    {{
            ""method"": ""Any"",
      ""path"": ""string""
    }}
  ]
}}";
        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    public async Task Test_Delete_ApiKey()
    {
        _apikeyId = await CreateApiKey();
        _rulesetId = await CreateRuleSet();
        this.input.Method = Methods.Post;
        this.input.Url = $@"{testTenant}api/v1/api-management/access/api-keys/{_apikeyId}";
        this.input.Message = $@"{{
  ""name"": ""New name{Guid.NewGuid()}"",
  ""rulesetIds"": [
    {_rulesetId}
  ],
  ""requestLimit"": 1,
  ""requestLimitPeriod"": ""Minute""
}}";

        var ret = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(ret.Success);
        ClassicAssert.IsNull(ret.ErrorMessage);
        ClassicAssert.NotNull(ret.Data);
    }

    [Test]
    public async Task Test_Delete_Ruleset()
    {
        var rulesetId = await CreateRuleSet();
        this.input.Method = Methods.Delete;
        this.input.Url = $@"{testTenant}api/v1/api-management/access/api-rulesets/{rulesetId}";
        var result = await PlatformApi.Request(this.input, this.options, default);
        ClassicAssert.IsTrue(result.Success);
        ClassicAssert.IsNull(result.ErrorMessage);
    }

    public async Task<int> CreateApiKey()
    {
        this.input.Method = Methods.Post;
        this.input.Url = testTenant + "api/v1/api-management/access/api-keys";
        this.input.Message = $@"{{
  ""name"": ""{_apiKeyName}"",
  ""rulesetIds"": [
    1
  ],
  ""requestLimit"": 1,
  ""requestLimitPeriod"": ""Minute"",
  ""environmentId"": 51
}}";

        var ret = await PlatformApi.Request(this.input, this.options, default);

        return JsonConvert.DeserializeObject<dynamic>(ret.Data.ToString()).data.id;
    }

    public async Task<int> CreateRuleSet()
    {
        this.input.Method = Methods.Post;
        this.input.Url = testTenant + "api/v1/api-management/access/api-rulesets";
        this.input.Message = $@"{{
  ""name"": ""{_rulesetName}{DateTime.Now}"",
  ""description"": ""Testing Management API Task. Can be deleted."",
  ""apiRules"": [
    {{
      ""method"": ""Any"",
      ""path"": ""string""
    }}
  ]
}}";

        var ret = await PlatformApi.Request(this.input, this.options, default);
        return JsonConvert.DeserializeObject<dynamic>(ret.Data.ToString()).data.id;
    }

    public async Task DeleteApiKey()
    {
        this.input.Method = Methods.Delete;
        this.input.Url = $@"{testTenant}api/v1/api-management/access/api-keys/{_apikeyId}";
        this.input.Message = null;
        await PlatformApi.Request(this.input, this.options, default);
    }

    public async Task DeleteRuleset()
    {
        this.input.Method = Methods.Delete;
        this.input.Url = $@"{testTenant}api/v1/api-management/access/api-rulesets/{_rulesetId}";
        await PlatformApi.Request(this.input, this.options, default);
    }

    public async Task DeleteApiSpec()
    {
        this.input.Method = Methods.Delete;
        this.input.Url = $@"{testTenant}api/v1/api-management/api-specifications/{_apiSpecId}/agent-group/51";
        this.input.IsMultipart = false;
        this.input.FilePaths = null;
        await PlatformApi.Request(this.input, this.options, default);
    }
}