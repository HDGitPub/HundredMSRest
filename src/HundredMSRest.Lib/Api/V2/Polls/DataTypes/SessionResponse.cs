namespace HundredMSRest.Lib.Api.V2.Polls.DataTypes;

/// <summary>
/// Record <c>SessionResponse</c>
/// </summary>
public record SessionResponse
{
    public string? id {get;set;}
    public string? poll_id {get;set;}
    public string? session_id {get;set;}
    public DateTime? started_at {get;set;}
    public DateTime? stopped_at {get;set;}
    public int? total_responses {get;set;}
    public int? unique_participants {get;set;}
}