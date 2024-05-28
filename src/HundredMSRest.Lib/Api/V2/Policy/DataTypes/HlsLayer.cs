namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>HlsLayer</c> HlsLayer
/// </summary>
public record HlsLayer
{
    public int width { get; set; }
    public int height { get; set; }
    public int videoBitrate { get; set; }
    public int audioBitrate { get; set; }
}
