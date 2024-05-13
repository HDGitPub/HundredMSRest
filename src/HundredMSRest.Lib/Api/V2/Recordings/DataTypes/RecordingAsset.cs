namespace HundredMSRest.Lib.Api.V2.Recordings.DataTypes;

/// <summary>
/// Record <c>RecordingAsset</c>
/// </summary>
public record RecordingAsset
{
    public string? id { get; set; }
    public object? thumbnails { get; set; }
    public Metadata? metadata { get; set; }
    public int? duration { get; set; }
    public string? path { get; set; }
    public string? status { get; set; }
    public DateTime? created_at { get; set; }
    public string? type { get; set; }
    public int? size { get; set; }
    public string? job_id { get; set; }
    public string? room_id { get; set; }
    public string? session_id { get; set; }
}
