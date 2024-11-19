namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Record <c>Agent</c>
/// </summary>
public record Agent
{
    public string? agent { get; set; }
    public string? sdk { get; set; }
    public string? device_model { get; set; }
    public string? os_version { get; set; }
    public bool? is_prebuilt { get; set; }
    public string? framework_version { get; set; }
    public string? os { get; set; }
    public string? framework_sdk_version { get; set; }
    public string? @string { get; set; }
    public string? framework { get; set; }
    public string? domain { get; set; }
    public string? sdk_version { get; set; }
}