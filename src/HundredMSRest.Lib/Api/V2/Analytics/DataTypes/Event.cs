namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Record <c>Event</c>
/// </summary>
public record Event
{
    public string? room_id { get; set; }
    public string? session_id { get; set; }
    public string? peer_id { get; set; }
}
