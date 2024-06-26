using HundredMSRest.Lib.Api.V2.Sessions.DataTypes;
using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.Sessions.Commands;

/// <summary>
/// Class <c>RoomRestCommand</c> 100MS Room specific rest commands
/// </summary>
public sealed class SessionRestCommand : RestCommand
{
    #region Methods

    /// <summary>
    /// Constructor takes RequestData and HttpMethod
    /// </summary>
    public SessionRestCommand(string? urlParams = null, string? filterParams = null)
    {
        BuildBaseRoute("v2/sessions", urlParams, filterParams);
    }

    /// <summary>
    /// Returns a session
    /// </summary>
    /// <param name="sessionId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/Sessions/retrieve-a-session"/>
    /// <returns></returns>
    public static async Task<Session> GetAsync(
        string sessionId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new SessionRestCommand(sessionId);
        return await command.RequestAsync<Session>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns a list of sessions based on filter criteria
    /// </summary>
    /// <param name="filter">Query string filter parameters</param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/Sessions/list-sessions"/>
    /// <example>
    /// Example:
    /// <code>
    /// var result = SessionRestCommand.ListSessionsAsync("filter")
    /// </code>
    /// <remarks>This method returns a list of sessions based on filter criteria</remarks>
    /// <returns></returns>
    public static async Task<SessionList> ListSessionsAsync(
        string? filter = null,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new SessionRestCommand(filterParams: filter);
        return await command.RequestAsync<SessionList>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    #endregion
}
