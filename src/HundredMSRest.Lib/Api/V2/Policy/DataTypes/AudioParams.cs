namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>AudioParams</c> AudioParams
/// </summary>
public record AudioParams
{
    public int bitRate { get; set; }
    public string? codec { get; set; }
}
