using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>Role</c> Role
/// </summary>
public record Role : RequestRecord
{
    public string? name { get; set; }
    public PublishParams? publishParams { get; set; }
    public SubscribeParams? subscribeParams { get; set; }
    public Permissions? permissions { get; set; }
    public int? priority { get; set; }
    public int? maxPeerCount { get; set; }
}
