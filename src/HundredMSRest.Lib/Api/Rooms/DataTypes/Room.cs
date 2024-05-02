namespace HundredMSRest.Lib.Api.Rooms.DataTypes;

/// <summary>
/// Record <c>Room</c>
/// </summary>
public record Room
{
    public WebHook? webhook { get; set; }
    public bool enabled { get; set; }
    public string? description { get; set; }
    public string? customer_id { get; set; }
    public bool recording_source_template { get; set; }
    public RecordingInfo? recording_info { get; set; }
    public string? template_id { get; set; }
    public string? template { get; set; }
    public string? region { get; set; }
    public DateTime created_at { get; set; }
    public string? key { get; set; }
    public DateTime updated_at { get; set; }
    public bool large_room { get; set; }
    public int size { get; set; }
    public int max_duration_seconds { get; set; }
    public string[]? polls { get; set; }
    public string? name { get; set; }
    public string? id { get; set; }
}
