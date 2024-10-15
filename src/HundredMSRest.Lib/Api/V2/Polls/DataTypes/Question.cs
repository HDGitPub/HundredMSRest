namespace HundredMSRest.Lib.Api.V2.Polls.DataTypes;

/// <summary>
/// Record <c>Question</c>
/// </summary>
public record Question
{
    public int? index {get;set;}
    public string? text {get;set;}
    public string? format {get;set;}
    public string[]? attachment {get;set;}
    public bool? skippable {get;set;}
    public int? duration {get;set;}

    public bool? once {get;set;}
    public int? weight {get;set;}
    public int? answer_min_len {get;set;}
    public int? answer_max_len {get;set;}
    public Answer? answer {get;set;}
    public IEnumerable<Option>? options {get;set;}
}