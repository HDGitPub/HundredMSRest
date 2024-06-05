namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>RtmpDestinations</c> RtmpDestinations
/// </summary>
public record RtmpDestinations(string name)
{
    public int? width { get; set; }
    public int? height { get; set; }
    public int? maxDuration { get; set; }
    public IEnumerable<string>? rtmpUrls { get; set; }
    public bool? recordingEnabled { get; set; }
    public int? autoStopTimeout { get; set; }
}
