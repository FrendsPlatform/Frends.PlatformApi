namespace Frends.PlatformApi.Request.Definitions;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Input parameters.
/// </summary>
public class Input
{
    /// <summary>
    /// Gets or sets HTTP request method.
    /// </summary>
    /// <example>Methods.Get.</example>
    [DefaultValue(Methods.Get)]
    public Methods Method { get; set; }

    /// <summary>
    /// Gets or sets URL.
    /// </summary>
    /// <example>https://tenant.frendsapp.com/api/v1/api-management/access/api-keys/1.</example>
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether token is generated.
    /// </summary>
    /// <example>false.</example>
    [DefaultValue(false)]
    public bool GeneratedToken { get; set; }

    /// <summary>
    /// gets or sets Application URI.
    /// </summary>
    /// <example>api://qwe123-rty456-uio789-1p2i-asd9078.</example>
    [UIHint(nameof(GeneratedToken), "", true)]
    [DisplayFormat(DataFormatString = "Text")]
    public string ApplicationUri { get; set; }

    /// <summary>
    /// Gets or sets application ID.
    /// </summary>
    /// <example>qwe123-rty456-uio789-1p2i-asd9078.</example>
    [UIHint(nameof(GeneratedToken), "", true)]
    [DisplayFormat(DataFormatString = "Text")]
    public string ApplicationId { get; set; }

    /// <summary>
    /// Gets or sets client secret.
    /// </summary>
    /// <example>1r2t3y4u5i6o7p8a9s.</example>
    [UIHint(nameof(GeneratedToken), "", true)]
    [DisplayFormat(DataFormatString = "Text")]
    public string ClientSecret { get; set; }

    /// <summary>
    /// Gets or sets bearer token.
    /// </summary>
    /// <example>abcd123.</example>
    [UIHint(nameof(GeneratedToken), "", false)]
    [DisplayFormat(DataFormatString = "Text")]
    [PasswordPropertyText]
    public string Token { get; set; }

    /// <summary>
    /// Gets or sets message to be sent with the request.
    /// </summary>
    /// <example>
    /// {
    ///   "agentGroupId": 0,
    ///   "processes": [    {
    ///   "processGuid": "00000000-0000-0000-0000-000000000000"
    ///   ...
    /// </example>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether multipart is used.
    /// If true, using Content-Type = multipart/form-data instead of application/json.
    /// </summary>
    /// <example>false.</example>
    [DefaultValue(false)]
    public bool IsMultipart { get; set; }

    /// <summary>
    /// Gets or sets download path where resource will be exported.
    /// </summary>
    /// <example>C:\temp\foo.json.</example>
    [UIHint(nameof(Method), "", Methods.Get)]
    public string DownloadPath { get; set; }

    /// <summary>
    /// Gets or sets array of files to be imported.
    /// </summary>
    /// <example>{ {FileParameterKey = FileParameterKey.File, Fullpath = "C:\temp\file.json"} }.</example>
    [UIHint(nameof(Method), "", Methods.Post)]
    public SendFileParameters[] FilePaths { get; set; }

    /// <summary>
    /// Gets or sets manual parameters.
    /// No need to add Content-Type, Accept and Authorization headers.
    /// </summary>
    /// <example>{ {Key = foo, Value = bar, ParameterType = ParameterTypes.GetOrPost} }.</example>
    public ManualParameters[] ManualParameters { get; set; }
}