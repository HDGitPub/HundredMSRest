using HundredMSRest.Lib.Api.V2.Rooms.DataTypes;
using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Rooms.Requests;

/// <summary>
/// Record <c>UpdateRoomRequest</c>
/// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/Rooms/update-a-room"/>
/// </summary>
public record UpdateRoomRequest : RequestRecord
{
    public string? name { get; set; }
    public string? description { get; set; }
    public RecordingInfo? recording_info { get; set; }
    public string? region { get; set; }
    public bool? large_room { get; set; }
    public int? size { get; set; }
    public int? max_duration_seconds { get; set; }
    public string[]? polls { get; set; }
    public WebHook? webhook { get; set; }
}
