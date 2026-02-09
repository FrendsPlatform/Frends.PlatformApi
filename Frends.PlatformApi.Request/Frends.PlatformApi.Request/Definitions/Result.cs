namespace Frends.PlatformApi.Request.Definitions;

/// <summary>
/// Result class.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="success">Gets a value indicating whether the Task was executed successfully and without errors.</param>
    /// <param name="data">Result data.</param>
    /// <param name="errorMessage">Error message.</param>
    internal Result(bool success, dynamic data, dynamic errorMessage)
    {
        this.Success = success;
        this.Data = data;
        this.ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Gets a value indicating whether the Task was executed successfully and without errors.
    /// </summary>
    /// <example>true.</example>
    public bool Success { get; private set; }

    /// <summary>
    /// Gets result data.
    /// </summary>
    /// <example>{"data":{"id":1,"value":"1-2-3-4-5","modified":"2024-01-25T07:56:27.147","modifier":"user","environment":{"id":51,"displayName":"Development"},"name":"test","rulesetIds":[],"requestLimit":100,"requestLimitPeriod":"Day"}}.</example>
    public dynamic Data { get; private set; }

    /// <summary>
    /// Gets error message.
    /// This value is generated when an exception occurs and Options.ThrowExceptionOnError is false.
    /// </summary>
    /// <example>Error occured...</example>
    public dynamic ErrorMessage { get; private set; }
}
