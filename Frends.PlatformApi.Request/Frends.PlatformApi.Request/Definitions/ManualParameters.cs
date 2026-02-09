namespace Frends.PlatformApi.Request.Definitions;

using System.ComponentModel;

/// <summary>
/// Manual parameters.
/// </summary>
public class ManualParameters
{
    /// <summary>
    /// Gets or sets name of the parameter.
    /// </summary>
    /// <example>foo.</example>
    public string Key { get; set; }

    /// <summary>
    /// Gets or sets value for the parameter.
    /// </summary>
    /// <example>bar.</example>
    public string Value { get; set; }

    /// <summary>
    /// Gets or sets parameter type.
    /// GetOrPost = Parameter that will added to the QueryString for GET, DELETE, OPTIONS and HEAD requests; and form for POST and PUT requests.
    /// UrlSegment = Parameter that will be added to part of the url by replacing a {placeholder} within the absolute path.
    /// HttpHeader = Parameter that will be added as a request header.
    /// RequestBody = Parameter that will be added to the request body.
    /// QueryString = Parameter that will be added to the query string.
    /// </summary>
    /// <example>ParameterTypes.GetOrPost.</example>
    [DefaultValue(ParameterTypes.GetOrPost)]
    public ParameterTypes ParameterType { get; set; }
}
