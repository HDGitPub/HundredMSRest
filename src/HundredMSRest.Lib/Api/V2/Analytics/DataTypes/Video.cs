namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Record <c>Video</c>
/// </summary>
public record Video
{
    public string? deviceId { get; set; }
    public int? maxFrameRate { get; set; }
    public int? maxBitRate { get; set; }
    public string? codec { get; set; }
    public int? height { get; set; }
    public int? width { get; set; }
}
