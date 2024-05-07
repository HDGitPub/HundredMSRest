namespace HundredMSRest.Lib.Api.V2.ActiveRooms.DataTypes;

/// <summary>
/// Record <c>Peer</c> represents a peer in a room
/// </summary>
public record Peer
{
    public string? id { get; set; }
    public string? name { get; set; }
    public string? user_id { get; set; }
    public string? metadata { get; set; }
    public string? role { get; set; }
    public string? joined_at { get; set; }
    public Dictionary<string, Track>? tracks { get; set; }
}
