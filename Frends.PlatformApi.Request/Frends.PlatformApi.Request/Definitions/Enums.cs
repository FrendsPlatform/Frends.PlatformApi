namespace Frends.PlatformApi.Request.Definitions;

/// <summary>
/// Type of HTTP Request.
/// </summary>
public enum Methods
{
    /// <summary>
    /// GET.
    /// </summary>
    Get,

    /// <summary>
    /// POST.
    /// </summary>
    Post,

    /// <summary>
    /// PUT.
    /// </summary>
    Put,

    /// <summary>
    /// PATCH.
    /// </summary>
    Patch,

    /// <summary>
    /// DELETE.
    /// </summary>
    Delete,
}

/// <summary>
/// Selection of file parameter key.
/// </summary>
public enum FileParameterKey
{
    /// <summary>
    /// File.
    /// </summary>
    File,

    /// <summary>
    /// Content.
    /// </summary>
    Content,
}

/// <summary>
/// Parameter types.
/// </summary>
public enum ParameterTypes
{
    /// <summary>
    /// Parameter that will added to the QueryString for GET, DELETE, OPTIONS and HEAD requests; and form for POST and PUT requests.
    /// </summary>
    GetOrPost,

    /// <summary>
    /// Parameter that will be added to part of the url by replacing a {placeholder} within the absolute path.
    /// </summary>
    UrlSegment,

    /// <summary>
    /// Parameter that will be added as a request header.
    /// </summary>
    HttpHeader,

    /// <summary>
    /// Parameter that will be added to the request body.
    /// </summary>
    RequestBody,

    /// <summary>
    /// Parameter that will be added to the query string.
    /// </summary>
    QueryString,
}