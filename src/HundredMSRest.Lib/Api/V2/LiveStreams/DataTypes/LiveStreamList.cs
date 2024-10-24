using HundredMSRest.Lib.Api.V2.LiveStreams.DataTypes;

/// <summary>
/// Record <c>LiveStreamList</c>
/// </summary>
/// <param name="limit"></param>
/// <param name="data"></param>
/// <param name="last"></param>
public record LiveStreamList(int limit, LiveStream[] data, string last)
{
    public string? Error {get;set;}
}