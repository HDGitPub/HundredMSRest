namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Record <c>RecordingEvent</c>
/// </summary>
public record RecordingEvent : Event
{
    public string? beam_id { get; set; }
    public string? template_id { get; set; }
    public DateTime? created_at { get; set; }
    public int? duration { get; set; }
    public DateTime? started_at { get; set; }
    public DateTime? stopped_at { get; set; }
    public int? max_width { get; set; }
    public int max_height { get; set; }
    public string? recording_path { get; set; }
    public string? recording_presigned_url { get; set; }
    public string? meeting_url { get; set; }
    public string[]? rtmp { get; set; }
    public DateTime? session_started_at { get; set; }
    public int? size { get; set; }
}
