namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Record <c>TrackEvent</c>
/// </summary>
public record TrackEvent : Event
{
    public string? room_name { get; set; }
    public string? user_id { get; set; }
    public string? user_name { get; set; }
    public DateTime? joined_at { get; set; }
    public string? role { get; set; }
    public string? track_id { get; set; }
    public string? stream_id { get; set; }
    public string? type { get; set; }
    public string? source { get; set; }
    public bool? mute { get; set; }
    public DateTime? started_at { get; set; }
    public DateTime? stopped_at { get; set; }
}
