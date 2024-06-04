using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

public sealed class SettingsBuilder
{
    #region Attributes
    private readonly Settings _settings;
    #endregion

    #region
    public SettingsBuilder()
    {
        _settings = new Settings();
    }

    public SettingsBuilder AddRegion(string region)
    {
        if (region != "in" || region != "us" || region != "eu" || region != "auto")
            throw new ArgumentNullException(Strings.POLICY_INVALID_REGION);

        _settings.region = region;
        return this;
    }

    public SettingsBuilder AddRecordingInfo(RecordingInfo recording)
    {
        _settings.recording = recording;
        return this;
    }

    public SettingsBuilder AddRoomState(int? messageInterval,bool? sendPeerList,bool? enabled)
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
    #endregion
}
