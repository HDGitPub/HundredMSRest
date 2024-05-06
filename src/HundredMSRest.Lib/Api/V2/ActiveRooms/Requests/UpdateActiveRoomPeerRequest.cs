using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.ActiveRooms.Requests;

/// <summary>
/// Record <c>UpdateActiveRoomPeerRequest</c>
/// <see cref="https://www.100ms.live/docs/server-side/v2/api-reference/active-rooms/update-a-peer"/>
/// </summary>
public record UpdateActiveRoomPeerRequest : RequestRecord
{
    public string? name { get; set; }
    public string? role { get; set; }
    public string? metadata { get; set; }
}
