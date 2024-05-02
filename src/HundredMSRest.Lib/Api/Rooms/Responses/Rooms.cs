using HundredMSRest.Lib.Api.Rooms.DataTypes;

namespace HundredMSRest.Lib.Api.Rooms.Responses;

/// <summary>
/// Record <c>Rooms</c>
/// </summary>
/// <param name="limit"></param>
/// <param name="data"></param>
/// <param name="last"></param>
public record RoomList(int limit, Room[] data, string last);
