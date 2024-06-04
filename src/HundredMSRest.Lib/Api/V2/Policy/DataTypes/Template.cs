using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>Template</c> Template
/// </summary>
public record Template : RequestRecord
{
    public string? id { get; set; }
    public string? name { get; set; }
    public string? customer_id { get; set; }
    public Dictionary<string, Role>? roles { get; set; }
    public Settings? settings { get; set; }
    public Destinations? destinations { get; set; }
}
