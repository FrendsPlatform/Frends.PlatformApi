namespace Frends.PlatformApi.Request.Definitions;

/// <summary>
/// Result class.
/// </summary>
public class Result
{
    /// <summary>
    /// Gets or sets a value indicating whether the Task was executed successfully and without errors.
    /// </summary>
    /// <example>true.</example>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets result data.
    /// </summary>
    /// <example>{"data":{"id":1,"value":"1-2-3-4-5","modified":"2024-01-25T07:56:27.147","modifier":"user","environment":{"id":51,"displayName":"Development"},"name":"test","rulesetIds":[],"requestLimit":100,"requestLimitPeriod":"Day"}}.</example>
    public dynamic Data { get; set; }

    /// <summary>
    /// Gets or sets the error that occurred during Task execution.
    /// </summary>
    /// <example>object { string Message, dynamic AdditionalInfo }</example>
    public Error Error { get; set; }
}
