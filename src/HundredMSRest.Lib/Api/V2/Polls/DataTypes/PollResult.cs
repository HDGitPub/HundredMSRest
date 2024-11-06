namespace HundredMSRest.Lib.Api.V2.Polls.DataTypes;

/// <summary>
/// Record <c>PollResult</c>
/// </summary>
public record PollResult
{
    public string? id { get; set; }
    public string? poll_id { get; set; }
    public string? session_id { get; set; }
    public int? question { get; set; }
    public int? duration { get; set; }
    public string? peer_id { get; set; }
    public string? user_id { get; set; }
    public int? score { get; set; }
}
