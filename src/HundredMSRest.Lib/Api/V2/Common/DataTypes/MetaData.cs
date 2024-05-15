namespace HundredMSRest.Lib.Api.V2.Common.DataTypes;

/// <summary>
/// Record <c>Metadata</c>
/// </summary>
public record Metadata
{
    public Resolution? resolution { get; set; }
    public string? num_layers { get; set; }
    public string? layer { get; set; }
    public int? max_width { get; set; }
    public int? max_height { get; set; }
}
