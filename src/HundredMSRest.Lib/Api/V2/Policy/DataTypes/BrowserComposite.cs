namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

public record BrowserComposite
{
    public bool? enabled { get; set; }
    public int? autoStopTimeout { get; set; }
    public int? width { get; set; }
    public int? height { get; set; }
}
