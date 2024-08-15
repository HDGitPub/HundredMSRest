namespace HundredMSRest.Lib.Api.V2.Common.DataTypes;

/// <summary>
/// Record <c>Options</c>
/// </summary>
/// <param name="region"></param>
public record Options
{
    public string? region { get; set; }
    public string? account_id { get; set; }
}
