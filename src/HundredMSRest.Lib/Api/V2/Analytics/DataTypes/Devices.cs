namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Record <c>Devices</c>
/// </summary>
public record Devices
{
    public string[]? videoInput { get; set; }
    public string[]? audioInput { get; set; }
    public string[]? audioOutput { get; set; }
}
