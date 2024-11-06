using System.Runtime.InteropServices;

namespace HundredMSRest.Lib.Api.V2.Polls.DataTypes;

/// <summary>
/// Record <c>Answer</c>
/// </summary>
public record Answer
{
    public bool? hidden { get; set; }
    public Option[]? options { get; set; }
    public string? text { get; set; }
    public bool? @case { get; set; }
    public bool? trim { get; set; }
}
