namespace HundredMSRest.Lib.Api.Rooms.DataTypes;

/// <summary>
/// Record <c>WebHook</c>
/// </summary>
/// <param name="url"></param>
/// <param name="headers"></param>
public record WebHook(string url, Headers headers);
