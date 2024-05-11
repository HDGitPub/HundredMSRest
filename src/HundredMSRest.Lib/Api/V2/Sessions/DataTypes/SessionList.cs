namespace HundredMSRest.Lib.Api.V2.Sessions.DataTypes;

/// <summary>
/// Record <c>SessionList</c>
/// </summary>
public record SessionList(int limit, Session[] data, string last);
