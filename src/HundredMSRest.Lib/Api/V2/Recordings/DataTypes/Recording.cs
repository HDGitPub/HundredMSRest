using HundredMSRest.Lib.Api.V2.Recordings.Constants;

namespace HundredMSRest.Lib.Api.V2.Recordings.DataTypes;

/// <summary>
/// Record <c>Recording</c>
/// </summary>
public record Recording
{
    public string? id { get; set; }
    public string? room_id { get; set; }
    public string? session_id { get; set; }
    public string? status { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? started_at { get; set; }
    public DateTime? updated_at { get; set; }
    public DateTime? stopped_at { get; set; }
    public string? meeting_url { get; set; }
    public string? destination { get; set; }
    public string? started_by { get; set; }
    public string? stopped_by { get; set; }
    public AssetTypes? asset_types { get; set; }
    public RecordingAsset[]? recording_assets { get; set; }
}
