namespace Frends.PlatformApi.Request.Definitions;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Options parameters.
/// </summary>
public class Options
{
    /// <summary>
    /// Gets or sets timeout in seconds.
    /// </summary>
    /// <example>10.</example>
    public int Timeout { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to throw an error on failure.
    /// </summary>
    /// <example>true.</example>
    [DefaultValue(true)]
    public bool ThrowErrorOnFailure { get; set; } = true;

    /// <summary>
    /// Gets or sets the message that overrides the error message on failure.
    /// </summary>
    /// <example>Failed to call Frends Platform API.</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("")]
    public string ErrorMessageOnFailure { get; set; } = string.Empty;
}
