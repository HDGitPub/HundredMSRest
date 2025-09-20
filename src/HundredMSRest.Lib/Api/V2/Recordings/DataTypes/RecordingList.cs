namespace HundredMSRest.Lib.Api.V2.Recordings.DataTypes;

/// <summary>
/// Record <c>RecordingList</c>
/// </summary>
/// <param name="limit"></param>
/// <param name="data"></param>
/// <param name="last"></param>
public record RecordingList(int limit, Recording[]? data, string last);
