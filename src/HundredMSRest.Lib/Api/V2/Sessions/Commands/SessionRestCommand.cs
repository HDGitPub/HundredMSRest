using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.Sessions.Commands;

/// <summary>
/// Class <c>RoomRestCommand</c> 100MS Room specific rest commands
/// </summary>
public sealed class SessionRestCommand : RestCommand
{
    #region Methods    /// <summary>
    /// Constructor takes RequestData and HttpMethod
    /// </summary>
    public SessionRestCommand(string? urlExtension = null)
    {
        string baseRoute = "v2/session";
        BaseUrl = urlExtension is not null ? $"{baseRoute}/{urlExtension}" : baseRoute;
    }

    /// <summary>
    /// Returns a session
    /// </summary>
    /// <param name="sessionId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Session?> GetAsync(
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

    public static async Task<SessionList?> ListSessionsAsync(
        bool? active,
        string? roomId = null,
        string? after = null,
        string? before = null,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new SessionRestCommand($"{filter(userId, role)}");
        return await command.RequestAsync<SessionList>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    #endregion
}