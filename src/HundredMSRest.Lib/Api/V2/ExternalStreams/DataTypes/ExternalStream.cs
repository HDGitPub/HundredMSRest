using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.ExternalStreams.DataTypes;

public record ExternalStream : RequestRecord
{
    public string? id { get; set; }
    public string? room_id { get; set; }
    public string? session_id { get; set; }
    public string? status { get; set; }
    public string[]? rtmp_urls { get; set; }
    public bool recording { get; set; }
    public Resolution? resolution { get; set; }
    public string? meeting_url { get; set; }
    public string? destination { get; set; }
    public RecordingAsset[]? recording_assets { get; set; }
    public DateTime created_at { get; set; }
    public DateTime started_at { get; set; }
    public DateTime started_by { get; set; }
    public DateTime stopped_at { get; set; }
    public string? stopped_by { get; set; }
    public DateTime updated_at { get; set; }
}
