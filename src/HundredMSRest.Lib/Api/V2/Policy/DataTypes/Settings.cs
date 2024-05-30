using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>Settings</c> Settings
/// </summary>
public record Settings
{
    public string? region { get; set; }
    public RecordingInfo? recording { get; set; }
    public RoomState? roomState { get; set; }
}
