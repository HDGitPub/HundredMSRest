using HundredMSRest.Lib.Core.Requests;

public record Session : RequestRecord
{
    public string? id { get; set; }
    public string? room_id { get; set;}
    public string? customer_id { get;}
    public string? active { get; set;}
    public object? peers { get; set; }
}