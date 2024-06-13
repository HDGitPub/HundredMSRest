namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

public record Thumbnails
{
    public int? width { get; set; }
    public int? height { get; set; }
    public int[]? offsets { get; set; }
    public int? fps { get; set; }
}
