using HundredMSRest.Lib.Api.V2.Common.DataTypes;

namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>Destinations</c> Destinations
/// </summary>
public record Destinations
{
    public RtmpDestinations? rtmpDestinations { get; set; }
    public HlsDestinations? hlsDestinations { get; set; }
    public Transcription? transcriptions { get; set; }
}
