namespace HundredMSRest.Lib.Api.V2.Polls.DataTypes;

/// <summary>
/// Record <c>UserResponse</c>
/// </summary>
public record UserResponse
{
    public string? id { get; set; }
    public string? poll_id { get; set; } 
    public string? session_id { get; set; }
    public int? duration { get; set; }
    public int? question {get; set; }
    public bool? skipped { get; set;}
    public string? text { get; set;}
    public bool? update {get;set;}
    public string? original_response {get;set;}
    public int? retries {get; set;}
    public DateTime? sent_at { get; set; }
    public string? peer_id { get; set; }
    public string? user_id { get; set; }
}