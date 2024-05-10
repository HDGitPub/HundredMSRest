namespace HundredMSRest.Lib.Api.V2.Sessions.DataTypes;

public record SessionList(int limit, Session[] data, string last);
