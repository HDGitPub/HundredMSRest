namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

public record CompositeRecording
{
    public BrowserComposite? browserComposite { get; set; }
    public CustomComposite? customComposite { get; set; }
}
