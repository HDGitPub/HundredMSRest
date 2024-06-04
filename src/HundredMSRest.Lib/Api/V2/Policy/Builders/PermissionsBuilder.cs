using HundredMSRest.Lib.Api.V2.Policy.DataTypes;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

public sealed class PermissionsBuilder
{
    #region Attributes
    private readonly Permissions _permissions;
    #endregion

    #region Method
    public PermissionsBuilder()
    {
        _permissions = new Permissions();
    }

    public PermissionsBuilder EnableEndRoom(bool endRoom)
    {
        _permissions.endRoom = endRoom;
        return this;
    }

    public PermissionsBuilder EnableRemoveOthers(bool removeOthers)
    {
        _permissions.removeOthers = removeOthers;
        return this;
    }

    public PermissionsBuilder EnableMute(bool mute)
    {
        _permissions.mute = mute;
        return this;
    }

    public PermissionsBuilder EnableUnmute(bool unmute)
    {
        _permissions.unmute = unmute;
        return this;
    }

    public PermissionsBuilder EnableChangeRole(bool changeRole)
    {
        _permissions.changeRole = changeRole;
        return this;
    }

    public PermissionsBuilder EnableSendRoomState(bool sendRoomState)
    {
        _permissions.sendRoomState = sendRoomState;
        return this;
    }

    public PermissionsBuilder EnablePollRead(bool pollRead)
    {
        _permissions.pollRead = pollRead;
        return this;
    }

    public PermissionsBuilder EnablePollWrite(bool pollWrite)
    {
        _permissions.pollWrite = pollWrite;
        return this;
    }

    public PermissionsBuilder EnableBrowserRecording(bool browserRecording)
    {
        _permissions.browserRecording = browserRecording;
        return this;
    }

    public PermissionsBuilder EnableRtmpStreaming(bool rtmpStreaming)
    {
        _permissions.rtmpStreaming = rtmpStreaming;
        return this;
    }

    public PermissionsBuilder EnableHlsStreaming(bool hlsStreaming)
    {
        _permissions.hlsStreaming = hlsStreaming;
        return this;
    }

    public Permissions Build()
    {
        return _permissions;
    }

    #endregion
}
