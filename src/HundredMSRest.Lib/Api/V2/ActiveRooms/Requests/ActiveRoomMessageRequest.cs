using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.ActiveRooms.Requests;

public record ActiveRoomMessageRequest : RequestRecord
{
    public string? message { get; set; }
    public string? peer_id { get; set; }
    public string? role { get; set; }
    public string? type { get; set; }
}
