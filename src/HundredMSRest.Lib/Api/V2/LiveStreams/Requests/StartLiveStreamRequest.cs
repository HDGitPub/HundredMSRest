using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Api.V2.LiveStreams.DataTypes;
using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.LiveStreams.Requests;

/// <summary>
/// Record <c>StartLiveStreamRequest</c>
/// </summary>
public record StartLiveStreamRequest : RequestRecord
{
    public string? meeting_url {get;set;}
    public Recording? recording {get;set;}
    public string? destination {get;set;}
    public Transcription? transcription {get;set;}
}