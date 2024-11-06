using HundredMSRest.Lib.Api.V2.Polls.DataTypes;
using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.Polls.Commands;

/// <summary>
/// Class <c>PollRestCommand></c> Provides Polling functionality
/// </summary>
public sealed class PollRestCommand : RestCommand
{
    public PollRestCommand(string? urlParams = null, string? filterParams = null)
    {
        BuildBaseRoute("v2/polls", urlParams, filterParams);
    }

    /// <summary>
    /// Creates a new Poll object
    /// </summary>
    /// <param name="poll"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Poll> CreateAsync(
        Poll poll,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PollRestCommand();
        return await command.RequestAsync<Poll>(
            HttpMethod.Post,
            httpClient,
            requestRecord: poll,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Update a Poll
    /// </summary>
    /// <param name="poll"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Poll> UpdateAsync(
        Poll poll,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PollRestCommand();
        return await command.RequestAsync<Poll>(
            HttpMethod.Post,
            httpClient,
            requestRecord: poll,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns a poll object
    /// </summary>
    /// <param name="pollId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Poll> GetAsync(
        string pollId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PollRestCommand(pollId);
        return await command.RequestAsync<Poll>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns sessions in which the specified poll was run
    /// </summary>
    /// <param name="pollId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<ResponseList<SessionResponse>> GetSessionsAsync(
        string pollId,
        string? filter = null,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PollRestCommand($"{pollId}/sessions", filter);
        return await command.RequestAsync<ResponseList<SessionResponse>>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns responses submitted by users for a given poll_id
    /// </summary>
    /// <param name="pollId"></param>
    /// <param name="filter"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<ResponseList<UserResponse>> GetResponsesAsync(
        string pollId,
        string? filter = null,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PollRestCommand($"{pollId}/responses", filter);
        return await command.RequestAsync<ResponseList<UserResponse>>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns a specific response submitted by a user
    /// </summary>
    /// <param name="pollId"></param>
    /// <param name="responseId"></param>
    /// <param name="filter"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<UserResponse> GetResponseAsync(
        string pollId,
        string responseId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PollRestCommand($"{pollId}/responses/{responseId}");
        return await command.RequestAsync<UserResponse>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns results for a specified poll.
    /// </summary>
    /// <param name="pollId"></param>
    /// <param name="responseId"></param>
    /// <param name="filter"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<PollResultList> GetResultsAsync(
        string pollId,
        string? filter = null,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PollRestCommand($"{pollId}/results", filter);
        return await command.RequestAsync<PollResultList>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns a result for a specified result id
    /// </summary>
    /// <param name="pollId"></param>
    /// <param name="resultId"></param>
    /// <param name="filter"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<PollResult> GetResultAsync(
        string pollId,
        string resultId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PollRestCommand($"{pollId}/results/{resultId}");
        return await command.RequestAsync<PollResult>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }
}
