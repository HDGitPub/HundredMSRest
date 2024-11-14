namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Class <c>EventType</c>
/// </summary>
/// <param name="name"></param>
public class EventType(string name)
{    
    public static EventType TRACK_ADD_SUCCESS = new EventType("track.add.success");

    private readonly string _name = name;
}