using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Rooms.Requests;

/// <summary>
/// Class <c>EnableDisableRoomRequest</c>
/// </summary>
public record EnableDisableRoomRequest : RequestRecord
{
    public bool enabled { get; set; }
}
