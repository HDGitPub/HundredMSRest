namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Class <c>EventType</c>
/// </summary>
/// <param name="name"></param>
public class EventType(string name)
{
    private readonly string _name = name;

    #region static members
    public static EventType TRACK_ADD_SUCCESS = new EventType("track.add.success");
    public static EventType TRACK_UPDATE_SUCCESS = new EventType("track.update.success");
    public static EventType TRACK_REMOVE_SUCCESS = new EventType("track.remove.success");
    public static EventType BEAM_RECORDING_SUCCESS = new EventType("beam.recording.success");
    public static EventType CLIENT_PUBLISH_FAILED = new EventType("client.publish.failed");
    public static EventType CLIENT_SUBSCRIBE_FAILED = new EventType("client.subscribe.failed");
    public static EventType CLIENT_JOIN_FAILED = new EventType("client.join.failed");
    public static EventType CLIENT_DISCONNECTED = new EventType("client.disconnected");
    public static EventType CLIENT_CONNECT_FAILED = new EventType("client.connect.failed");
    #endregion

    #region Methods
    public override string ToString()
    {
        return _name;
    }
    #endregion
}