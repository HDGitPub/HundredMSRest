using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Sessions.DataTypes;

/// <summary>
/// Record <c>Session</c>
/// </summary>
public record Session : RequestRecord
{
    public string? id { get; set; }
    public string? room_id { get; set; }
    public string? customer_id { get; }
    public bool? active { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
    public Dictionary<string, Peer>? peers { get; set; }
}
