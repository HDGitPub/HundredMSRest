using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>Destinations</c> Destinations
/// </summary>
public record Destinations : RequestRecord
{
    public IDictionary<string, RtmpDestinations>? rtmpDestinations { get; set; }
    public IDictionary<string, HlsDestinations>? hlsDestinations { get; set; }
    public IDictionary<string, Transcription>? transcriptions { get; set; }
}
