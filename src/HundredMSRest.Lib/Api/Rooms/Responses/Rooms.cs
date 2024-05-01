using HundredMSRest.Lib.Api.Rooms.DataTypes;

namespace HundredMSRest.Lib.Api.Rooms.Responses;

public record Rooms(int limit, Room[] data, string last);
