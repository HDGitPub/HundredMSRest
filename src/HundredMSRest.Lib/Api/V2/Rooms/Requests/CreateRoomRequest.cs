using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Rooms.Requests;

/// <summary>
/// Record <c>CreateRoom</c> contains params for room creation
/// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/Rooms/create-via-api"/>
/// </summary>
/// <param name="name">Name Param</param>
/// <param name="description"></param>
/// <param name="template_id"></param>
public record CreateRoomRequest(string name, string description, string template_id)
    : RequestRecord;
