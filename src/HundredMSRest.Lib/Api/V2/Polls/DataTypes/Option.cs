namespace HundredMSRest.Lib.Api.V2.Polls.DataTypes;

public record Option
{
    public int? index {get; set;}
    public string? text {get; set;}
    public int? weight {get; set;}
}