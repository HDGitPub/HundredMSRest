namespace HundredMSRest.Lib.Api.V2.Polls.DataTypes;

/// <summary>
/// Record <c>PollResultList</c>
/// </summary>
/// <param name="limit"></param>
/// <param name="results"></param>
/// <param name="last"></param>
public record PollResultList(int limit, PollResult[] results, string last);