namespace Frends.PlatformApi.Request.Definitions;

using System.ComponentModel;

/// <summary>
/// File which will be sent.
/// </summary>
public class SendFileParameters
{
    /// <summary>
    /// Gets or sets key used for file parameter.
    /// </summary>
    /// <example>FileParameterKey.File.</example>
    [DefaultValue(FileParameterKey.File)]
    public FileParameterKey FileParameterKey { get; set; }

    /// <summary>
    /// Gets or sets full path to the file to be uploaded.
    /// </summary>
    /// <example>C:\temp\file.txt.</example>
    public string Fullpath { get; set; }
}