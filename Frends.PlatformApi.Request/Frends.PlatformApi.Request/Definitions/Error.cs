namespace Frends.PlatformApi.Request.Definitions;

/// <summary>
/// Error that occurred during the task.
/// </summary>
public class Error
{
    /// <summary>
    /// Summary of the error.
    /// </summary>
    /// <example>Request failed with status code 401 Unauthorized.</example>
    public string Message { get; set; }

    /// <summary>
    /// Additional information about the error, such as the exception or the failed HTTP response.
    /// </summary>
    /// <example>object { Exception AdditionalInfo }</example>
    public dynamic AdditionalInfo { get; set; }
}
