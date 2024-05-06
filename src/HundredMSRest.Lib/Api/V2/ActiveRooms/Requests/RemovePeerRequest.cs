using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.ActiveRooms.Requests;

/// <summary>
/// Record <c>RemovePeerRequest</c>
/// </summary>
public record RemovePeerRequest : RequestRecord
{
    public string? peer_id { get; set; }
    public string? role { get; set; }
    public string? reason { get; set; }
}
