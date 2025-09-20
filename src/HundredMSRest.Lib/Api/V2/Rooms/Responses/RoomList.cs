using HundredMSRest.Lib.Api.V2.Rooms.DataTypes;

namespace HundredMSRest.Lib.Api.V2.Rooms.Responses;

/// <summary>
/// Record <c>Rooms</c>
/// </summary>
/// <param name="limit"></param>
/// <param name="data"></param>
/// <param name="last"></param>
public record RoomList(int limit, Room[]? data, string last);
