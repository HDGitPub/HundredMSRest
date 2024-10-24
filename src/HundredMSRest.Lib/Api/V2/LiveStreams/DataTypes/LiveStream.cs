using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.LiveStreams.DataTypes;

/// <summary>
/// Record <c>LiveStream</c>
/// </summary>
public record LiveStream : RequestRecord
{
    public string? id {get;set;}
    public string? room_id {get;set;}
    public string? session_id {get;set;}
    public string? status {get;set;}
    public Playback? playback {get;set;}
    public Recording? recording {get;set;}
    public string? meeting_url {get;set;}
    public string? destination {get;set;}
    public RecordingAsset[]? recording_assets {get;set;}
    public DateTime created_at {get;set;}
    public DateTime started_at {get;set;}
    public DateTime started_by {get;set;}
    public DateTime stopped_at {get;set;}
    public string? stopped_by {get;set;}
    public DateTime updated_at {get;set;}
}