namespace HundredMSRest.Lib.Requests;

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
    public RoomRestCommand(HttpMethod httpMethod) : base(httpMethod)
    {
        _baseUrl += _baseUrl + "/rooms";
    }

    /// <summary>
    /// Creates a new 100 MS room
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <returns>RoomRestCommand</returns>
    public static async Task<Room> CreateRoomAsync(string name, string description)
    {
        var command = new RoomRestCommand(HttpMethod.Post);
        var result = await command.RequestAsync<Room>(new CreateRoomRecord("", "", ""));
        return result;
    }

    #endregion

    #region Properties

    #endregion
}
