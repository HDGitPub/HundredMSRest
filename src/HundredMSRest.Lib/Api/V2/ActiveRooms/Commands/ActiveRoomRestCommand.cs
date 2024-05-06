using HundredMSRest.Lib.Api.V2.ActiveRooms.DataTypes;
using HundredMSRest.Lib.Api.V2.ActiveRooms.Requests;
using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.ActiveRooms.Commands;

/// <summary>
/// Class <c>ActiveRoomRestCommand</c> Active rooms contain participants
/// </summary>
public class ActiveRoomRestCommand : RestCommand
{
    /// <summary>
    /// Constructor takes RequestData and HttpMethod
    /// </summary>
    public ActiveRoomRestCommand(string? urlExtension = null)
    {
        string baseRoute = "v2/active-rooms";
        BaseUrl = urlExtension is not null ? $"{baseRoute}/{urlExtension}" : baseRoute;
    }

    /// <summary>
    /// Returns an active room
    /// </summary>
    /// <param name="activeRoomId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/active-rooms/retrieve-active-room"/>
    /// <returns></returns>
    public static async Task<ActiveRoom?> GetAsync(
        string activeRoomId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ActiveRoomRestCommand(activeRoomId);
        return await command.RequestAsync<ActiveRoom>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Retrieves peer detail information for an active peer currently in the room
    /// </summary>
    /// <param name="activeRoomId"></param>
    /// <param name="peerId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/active-rooms/retrieve-peer"/>
    /// <returns></returns>
    public static async Task<Peer?> GetPeerAsync(
        string activeRoomId,
        string peerId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ActiveRoomRestCommand($"{activeRoomId}/peers/{peerId}");
        return await command.RequestAsync<Peer>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns a list of peers in the specified active room
    /// </summary>
    /// <param name="activeRoomId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/active-rooms/list-peers"/>
    /// <returns></returns>
    public static async Task<PeerList?> ListPeersAsync(
        string activeRoomId,
        string? userId = null,
        string? role = null,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ActiveRoomRestCommand($"{activeRoomId}/peers{filter(userId, role)}");
        return await command.RequestAsync<PeerList>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Updates a peer in the active room
    /// </summary>
    /// <param name="activeRoomId"></param>
    /// <param name="peerId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/active-rooms/update-a-peer"/>
    /// <returns></returns>
    public static async Task<Peer?> UpdatePeerAsync(
        string activeRoomId,
        string peerId,
        UpdateActiveRoomPeerRequest request,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ActiveRoomRestCommand($"{activeRoomId}/peers/{peerId}");
        return await command.RequestAsync<Peer>(
            HttpMethod.Post,
            httpClient,
            requestRecord: request,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Sends a message to all or specific peers in an active room
    /// </summary>
    /// <param name="activeRoomId"></param>
    /// <param name="message"></param>
    /// <param name="request"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/active-rooms/send-message/">
    /// <returns></returns>
    public static async Task<ActiveRoomResponse?> SendMessageAsync(
        string activeRoomId,
        ActiveRoomMessageRequest request,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        string url = $"{activeRoomId}/send-message";
        var command = new ActiveRoomRestCommand(url);
        var result = await command.RequestAsync<ActiveRoomResponse>(
            HttpMethod.Post,
            httpClient,
            requestRecord: request,
            cancellationToken: cancellationToken
        );
        return result;
    }

    /// <summary>
    /// Removes a spefic peer or role from an active room
    /// </summary>
    /// <param name="activeRoomId"></param>
    /// <param name="request"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/active-rooms/remove-peers"/>
    /// <returns></returns>
    public static async Task<ActiveRoomResponse?> RemovePeers(
        string activeRoomId,
        RemovePeerRequest request,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ActiveRoomRestCommand($"{activeRoomId}/remove-peers");
        return await command.RequestAsync<ActiveRoomResponse>(
            HttpMethod.Post,
            httpClient,
            requestRecord: request,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Ends a room and optionally locks it so that no peers may re-enter
    /// </summary>
    /// <param name="activeRoomId"></param>
    /// <param name="request"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/active-rooms/end-active-room"/>
    /// <returns></returns>
    public static async Task<ActiveRoomResponse?> EndRoom(
        string activeRoomId,
        EndRoomRequest request,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ActiveRoomRestCommand($"{activeRoomId}/end-room");
        return await command.RequestAsync<ActiveRoomResponse>(
            HttpMethod.Post,
            httpClient,
            requestRecord: request,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns a filter as query string params
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    private static string filter(string? userId, string? role)
    {
        return userId != null
            ? $"?user_id={userId}"
            : role != null
                ? $"?role={role}"
                : string.Empty;
    }
}
