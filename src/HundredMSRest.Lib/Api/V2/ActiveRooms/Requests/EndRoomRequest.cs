using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.ActiveRooms.Requests;

public record EndRoomRequest : RequestRecord
{
    public string? reason { get; set; }
    public bool? Lock { get; set; }
}
