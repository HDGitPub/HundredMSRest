using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

/// <summary>
/// Class <c>SettingsBuilder</c> Builds a Settings class
/// </summary>
public sealed class SettingsBuilder
{
    #region Attributes
    private readonly Settings _settings;
    #endregion

    #region

    /// <summary>
    /// Constructor
    /// </summary>
    public SettingsBuilder()
    {
        _settings = new Settings();
    }

    /// <summary>
    /// Adds region (in,us,eu,auto)
    /// </summary>
    /// <param name="region"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public SettingsBuilder AddRegion(string region)
    {
        if (region != "in" && region != "us" && region != "eu" && region != "auto")
            throw new ArgumentNullException(Strings.POLICY_INVALID_REGION);

        _settings.region = region;
        return this;
    }

    /// <summary>
    /// Adds recording info
    /// </summary>
    /// <param name="recording"></param>
    /// <returns></returns>
    public SettingsBuilder AddRecordingInfo(RecordingInfo recording)
    {
        _settings.recording = recording;
        return this;
    }

    /// <summary>
    /// Adds room state
    /// </summary>
    /// <param name="messageInterval"></param>
    /// <param name="sendPeerList"></param>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public SettingsBuilder AddRoomState(int? messageInterval, bool? sendPeerList, bool? enabled)
    {
        var roomState = new RoomState()
        {
            messageInterval = messageInterval ?? 5,
            sendPeerList = sendPeerList ?? false,
            enabled = enabled ?? false
        };
        _settings.roomState = roomState;
        return this;
    }

    /// <summary>
    /// Returns a new Settings instance
    /// </summary>
    /// <returns></returns>
    public Settings Build()
    {
        return _settings;
    }
    #endregion
}
