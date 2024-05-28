namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>RoomState</c> RoomState
/// </summary>
public record RoomState
{
    public int messageInterval { get; set; }
    public bool sendPeerList { get; set; }
    public bool enabled { get; set; }
}
