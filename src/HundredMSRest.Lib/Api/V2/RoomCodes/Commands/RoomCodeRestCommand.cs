using HundredMSRest.Lib.Api.V2.RoomCodes.DataTypes;
using HundredMSRest.Lib.Api.V2.RoomCodes.Requests;
using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.RoomCodes.Commands;

/// <summary>
/// Class <c>RoomCodeRestCommand</c> Rest commands for the room code api
/// </summary>
public sealed class RoomCodeRestCommand : RestCommand
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="urlParams"></param>
    /// <param name="filterParams"></param>
    public RoomCodeRestCommand(string? urlParams = null, string? filterParams = null)
    {
        BuildBaseRoute("v2/room-codes", urlParams, filterParams);
    }

    /// <summary>
    /// Returns a room code
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<RoomCodeList?> ListAsync(
        string roomId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RoomCodeRestCommand($"room/{roomId}");
        return await command.RequestAsync<RoomCodeList>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Creates a room code for all roles in the room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<RoomCodeList> CreateAsync(
        string roomId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RoomCodeRestCommand($"room/{roomId}");
        return await command.RequestAsync<RoomCodeList>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Creates a room code for a specific role in the room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<RoomCode> CreateRoleRoomCodeAsync(
        string roomId,
        string role,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RoomCodeRestCommand($"room/{roomId}/role/{role}");
        return await command.RequestAsync<RoomCode>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Updates a room code
    /// </summary>
    /// <param name="roomCode"></param>
    /// <param name="enabled"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<RoomCode> UpdateAsync(
        string roomCode,
        bool enabled,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var request = new RoomCodeRequest(roomCode, enabled);
        var command = new RoomCodeRestCommand($"code");
        return await command.RequestAsync<RoomCode>(
            HttpMethod.Post,
            httpClient,
            requestRecord: request,
            cancellationToken: cancellationToken
        );
    }
}
