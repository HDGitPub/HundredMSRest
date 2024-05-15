using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Api.V2.Recordings.DataTypes;
using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Recordings.Requests;

/// <summary>
/// Record <c>RecordingRequest</c> RecordingRequest record
/// </summary>
public record RecordingRequest : RequestRecord
{
    public string? meeting_url { get; set; }
    public Resolution? resolution { get; set; }
    public string? destination { get; set; }
    public bool? audio_only { get; set; }
    public Transcription? transcription { get; set; }
}
