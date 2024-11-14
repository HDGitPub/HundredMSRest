using HundredMSRest.Lib.Api.V2.Analytics.DataTypes;
using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.Analytics.Commands;

/// <summary>
/// Class <c>AnalyticsRestCommand></c> Analytics APIs can be utilized to retrieve events
/// </summary>
public sealed class AnalyticsRestCommand : RestCommand
{
    /// <summary>
    /// Constructor
    /// </summary>
    public AnalyticsRestCommand(string? urlParams = null, string? filterParams = null)
    {
        BuildBaseRoute("v2/analytics", urlParams, filterParams);
    }

    /// <summary>
    /// Starts a live stream for a room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="request"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<EventList> GetAsync(
        string filter,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new AnalyticsRestCommand("events",filter);
        return await command.RequestAsync<EventList>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }
}
