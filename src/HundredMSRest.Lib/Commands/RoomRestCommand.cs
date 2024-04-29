namespace HundredMSRest.Lib.Commands;

using HundredMSRest.Lib.Records;

/// <summary>
/// Class <c>RoomRestCommand</c> 100MS Room specific rest commands
/// </summary>
public sealed class RoomRestCommand : RestCommand
{
    #region Methods

    /// <summary>
    /// Constructor takes RequestData and HttpMethod
    /// </summary>
    /// <param name="command"></param>
    /// <param name="data"></param>
    public RoomRestCommand() : base()
    {
        BaseUrl = "v2/rooms";
    }

    /// <summary>
    /// Creates a new 100 MS room
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <returns>RoomRestCommand</returns>
    public static async Task<Room> CreateRoomAsync(string name, string description, HttpClient? httpClient = null)
    {
        var command = new RoomRestCommand();
        var result = await command.RequestAsync<Room>(HttpMethod.Post, 
                                                      httpClient,
                                                      requestRecord: new CreateRoomRecord(name, description, ""));
        return result;
    }

    /// <summary>
    /// Returns a list of rooms
    /// </summary>
    /// <returns></returns>
    public static async Task<List<Room>> ListRoomsAsync()
    {
        var result = await new RoomRestCommand().RequestAsync<List<Room>>(HttpMethod.Get);
        return result;
    }

    #endregion
}
