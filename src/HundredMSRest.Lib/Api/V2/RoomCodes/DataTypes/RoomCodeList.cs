namespace HundredMSRest.Lib.Api.V2.RoomCodes.DataTypes;

/// <summary>
/// Record <c>RoomCodeList</c> List of RoomCodes
/// </summary>
public record RoomCodeList(int limit, RoomCode[]? data, string last);
