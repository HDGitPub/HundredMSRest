using HundredMSRest.Lib.Api.V2.Rooms.DataTypes;
using HundredMSRest.Lib.Api.V2.Rooms.Requests;
using HundredMSRest.Lib.Api.V2.Rooms.Responses;
using HundredMSRest.Lib.Core.Commands;
using HundredMSRest.Lib.Core.Services;
using HundredMSRest.Lib.Core.Tokens;

namespace HundredMSRest.Lib.Api.V2.Rooms.Commands;

/// <summary>
/// Class <c>RoomRestCommand</c> 100MS Room specific rest commands
/// </summary>
public sealed class RoomRestCommand : RestCommand
{
    #region Methods

    /// <summary>
    /// Constructor takes RequestData and HttpMethod
    /// </summary>
    public RoomRestCommand(string? urlParams = null)
    {
        BuildBaseRoute("v2/rooms", urlParams);
    }

    /// <summary>
    /// Returns a new authentication token that can be used to connect to a room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="role"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static Token GetRoomToken(string roomId, string role, string userId)
    {
        return new TokenService().GetAuthToken(roomId, role, userId);
    }

    /// <summary>
    /// Creates a new 100 MS room
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Room> CreateRoomAsync(
        string name,
        string description,
        string templateId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RoomRestCommand();
        var result = await command.RequestAsync<Room>(
            HttpMethod.Post,
            httpClient,
            requestRecord: new CreateRoomRequest(name, description, templateId),
            cancellationToken: cancellationToken
        );
        return result;
    }

    /// <summary>
    /// Returns a list of rooms
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<RoomList> ListRoomsAsync(
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RoomRestCommand();
        var result = await command.RequestAsync<RoomList>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
        return result;
    }

    /// <summary>
    /// Retrieves information for a specific room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Room> GetRoomAsync(
        string roomId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RoomRestCommand(roomId);
        var result = await command.RequestAsync<Room>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
        return result;
    }

    /// <summary>
    /// Allows updates to a rooms name, description, region and or recording info
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="updateRoom"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Room> UpdateRoomAsync(
        string roomId,
        UpdateRoomRequest updateRoom,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RoomRestCommand(roomId);
        var result = await command.RequestAsync<Room>(
            HttpMethod.Post,
            httpClient,
            requestRecord: updateRoom,
            cancellationToken: cancellationToken
        );
        return result;
    }

    /// <summary>
    /// Enable or disable a room. Pass false to disable, true to enable
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="updateRoom"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Room> EnableDisableRoomAsync(
        string roomId,
        EnableDisableRoomRequest enableDisableRoom,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RoomRestCommand(roomId);
        var result = await command.RequestAsync<Room>(
            HttpMethod.Post,
            httpClient,
            requestRecord: enableDisableRoom,
            cancellationToken: cancellationToken
        );
        return result;
    }
    #endregion
}
