using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Polls.DataTypes;

/// <summary>
/// Record <c>Poll</c>
/// </summary>
public record Poll : RequestRecord
{
    public string? Id {get;set;}
    public string? Title {get;set;}
    public int? duration {get;set;}
    public bool? anonymous {get;set;}
    public string? mode {get;set;}
    public string? type {get;set;}
    public string? start {get;set;}
    public IEnumerable<Question>? questions {get;set;}
}