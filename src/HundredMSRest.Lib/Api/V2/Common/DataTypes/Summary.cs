namespace HundredMSRest.Lib.Api.V2.Common.DataTypes;

/// <summary>
/// Record <c>Summary</c>
/// </summary>
public record Summary
{
    public bool? enabled { get; set; }
    public string? context { get; set; }
    public IEnumerable<Section>? sections { get; set; }
    public float? temperature { get; set; }
}
