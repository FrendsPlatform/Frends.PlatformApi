namespace Frends.PlatformApi.Request.Definitions;

using System.ComponentModel;

/// <summary>
/// Options parameters.
/// </summary>
public class Options
{
    /// <summary>
    /// Gets or sets a value indicating whether an error should stop the Task and throw an exception.
    /// If set to true, an exception will be thrown when an error occurs.
    /// If set to false, Task will try to continue and the error message will be added into Result.ErrorMessage and Result.Success will be set to false.
    /// </summary>
    /// <example>true.</example>
    [DefaultValue(true)]
    public bool ThrowExceptionOnError { get; set; }

    /// <summary>
    /// Gets or sets timeout in seconds.
    /// </summary>
    /// <example>10.</example>
    public int Timeout { get; set; }
}