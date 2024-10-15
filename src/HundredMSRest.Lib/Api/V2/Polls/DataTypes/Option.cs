namespace HundredMSRest.Lib.Api.V2.Polls.DataTypes;


/// <summary>
/// Record <c>Option</c>
/// </summary>
public record Option
{
    public int? index {get; set;}
    public string? text {get; set;}
    public int? weight {get; set;}
}