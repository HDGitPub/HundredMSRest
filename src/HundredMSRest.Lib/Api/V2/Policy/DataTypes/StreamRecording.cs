namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

public record StreamRecording
{
    public bool? enabled { get; set; }
    public int? width { get; set; }
    public int? height { get; set; }
}
