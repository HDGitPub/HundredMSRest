namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>ScreenParams</c> ScreenParams
/// </summary>
public record ScreenParams
{
    public int bitRate { get; set; }
    public string? codec { get; set; }
    public int frameRate { get; set; }
    public int height { get; set; }
    public int width { get; set; }
}
