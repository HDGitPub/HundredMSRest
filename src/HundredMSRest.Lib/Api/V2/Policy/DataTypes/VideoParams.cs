namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>VideoParams</c> VideoParams
/// </summary>
public record VideoParams
{
    public int bitRate { get; set; }
    public string? codec { get; set; }
    public int frameRate { get; set; }
    public int height { get; set; }
    public int width { get; set; }
}
