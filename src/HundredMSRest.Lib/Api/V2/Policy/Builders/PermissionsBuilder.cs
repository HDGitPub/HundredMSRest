using HundredMSRest.Lib.Api.V2.Policy.DataTypes;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

/// <summary>
/// Class <c>PermissionsBuilder</c>
/// </summary>
public sealed class PermissionsBuilder
{
    #region Attributes
    private readonly Permissions _permissions;
    #endregion

    #region Method

    /// <summary>
    /// Constructor
    /// </summary>
    public PermissionsBuilder()
    {
        _permissions = new Permissions();
    }

    /// <summary>
    /// Enables Ending a room
    /// </summary>
    /// <param name="endRoom"></param>
    /// <returns></returns>
    public PermissionsBuilder EnableEndRoom(bool endRoom)
    {
        _permissions.endRoom = endRoom;
        return this;
    }

    /// <summary>
    /// Enables Removing peers
    /// </summary>
    /// <param name="removeOthers"></param>
    /// <returns></returns>
    public PermissionsBuilder EnableRemoveOthers(bool removeOthers)
    {
        _permissions.removeOthers = removeOthers;
        return this;
    }

    /// <summary>
    /// Enables mute
    /// </summary>
    /// <param name="mute"></param>
    /// <returns></returns>
    public PermissionsBuilder EnableMute(bool mute)
    {
        _permissions.mute = mute;
        return this;
    }

    /// <summary>
    /// Enables unmute
    /// </summary>
    /// <param name="unmute"></param>
    /// <returns></returns>
    public PermissionsBuilder EnableUnmute(bool unmute)
    {
        _permissions.unmute = unmute;
        return this;
    }

    /// <summary>
    /// Enables ChangeRole
    /// </summary>
    /// <param name="changeRole"></param>
    /// <returns></returns>
    public PermissionsBuilder EnableChangeRole(bool changeRole)
    {
        _permissions.changeRole = changeRole;
        return this;
    }

    /// <summary>
    /// Enables SendRoomState
    /// </summary>
    /// <param name="sendRoomState"></param>
    /// <returns></returns>
    public PermissionsBuilder EnableSendRoomState(bool sendRoomState)
    {
        _permissions.sendRoomState = sendRoomState;
        return this;
    }

    /// <summary>
    /// Enables Poll Read
    /// </summary>
    /// <param name="pollRead"></param>
    /// <returns></returns>
    public PermissionsBuilder EnablePollRead(bool pollRead)
    {
        _permissions.pollRead = pollRead;
        return this;
    }

    /// <summary>
    /// Enables Poll Write
    /// </summary>
    /// <param name="pollWrite"></param>
    /// <returns></returns>
    public PermissionsBuilder EnablePollWrite(bool pollWrite)
    {
        _permissions.pollWrite = pollWrite;
        return this;
    }

    /// <summary>
    /// Enables Browser Recording
    /// </summary>
    /// <param name="browserRecording"></param>
    /// <returns></returns>
    public PermissionsBuilder EnableBrowserRecording(bool browserRecording)
    {
        _permissions.browserRecording = browserRecording;
        return this;
    }

    /// <summary>
    /// Enables Rtmp Streaming
    /// </summary>
    /// <param name="rtmpStreaming"></param>
    /// <returns></returns>
    public PermissionsBuilder EnableRtmpStreaming(bool rtmpStreaming)
    {
        _permissions.rtmpStreaming = rtmpStreaming;
        return this;
    }

    /// <summary>
    /// Enables Hls Streaming
    /// </summary>
    /// <param name="hlsStreaming"></param>
    /// <returns></returns>
    public PermissionsBuilder EnableHlsStreaming(bool hlsStreaming)
    {
        _permissions.hlsStreaming = hlsStreaming;
        return this;
    }

    /// <summary>
    /// Returns a configured instance of Permissions
    /// </summary>
    /// <returns></returns>
    public Permissions Build()
    {
        return _permissions;
    }

    #endregion
}
