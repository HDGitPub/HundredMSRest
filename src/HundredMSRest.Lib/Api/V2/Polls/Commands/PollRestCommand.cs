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
}
