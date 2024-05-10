using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Sessions.DataTypes;

public record Session : RequestRecord
{
    public string? id { get; set; }
    public string? room_id { get; set; }
    public string? customer_id { get; }
    public string? active { get; set; }
    public Dictionary<string, Peer>? peers { get; set; }
}
