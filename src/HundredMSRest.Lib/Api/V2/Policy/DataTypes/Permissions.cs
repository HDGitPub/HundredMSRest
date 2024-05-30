namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>Permissions</c> Permissions
/// </summary>
public record Permissions
{
    public bool endRoom { get; set; }
    public bool removeOthers { get; set; }
    public bool mute { get; set; }
    public bool unmute { get; set; }
    public bool changeRole { get; set; }
    public bool sendRoomState { get; set; }
    public bool pollRead { get; set; }
    public bool pollWrite { get; set; }
    public bool browserRecording { get; set; }
    public bool rtmpStreaming { get; set; }
    public bool hlsStreaming { get; set; }
}
