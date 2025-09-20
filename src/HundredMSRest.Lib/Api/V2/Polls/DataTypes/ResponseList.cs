namespace HundredMSRest.Lib.Api.V2.Polls.DataTypes;

/// <summary>
/// Record <c>ResponseList</c>
/// </summary>
/// <param name="limit"></param>
/// <param name="results"></param>
/// <param name="last"></param>
public record ResponseList<T>(int limit, T[]? responses, string last);
