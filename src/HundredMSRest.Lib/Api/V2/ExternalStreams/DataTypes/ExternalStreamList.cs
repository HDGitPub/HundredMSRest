namespace HundredMSRest.Lib.Api.V2.ExternalStreams.DataTypes;

public record ExternalStreamList(int limit, ExternalStream[]? data, string last)
{
    public string? Error { get; set; }
}
