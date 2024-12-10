namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Record <c>Audio</c>
/// </summary>
public record Audio
{
    public int? maxBitRate { get; set; }
    public string? deviceId { get; set; }
    public int? volume { get; set; }
    public string? codec { get; set; }
}
