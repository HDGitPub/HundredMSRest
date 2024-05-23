using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.RoomCodes.Requests;

/// <summary>
/// Record <c>RoomCodeRequest</c> for updating a room code
/// </summary>
/// <param name="code"></param>
/// <param name="enabled"></param>
public record RoomCodeRequest(string code,bool enabled) : RequestRecord;