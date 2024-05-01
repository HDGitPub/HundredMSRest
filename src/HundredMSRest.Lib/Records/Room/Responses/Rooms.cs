namespace HundredMSRest.Lib.Records.Room.Responses;

public record Rooms(int limit, Room[] data, string last);
