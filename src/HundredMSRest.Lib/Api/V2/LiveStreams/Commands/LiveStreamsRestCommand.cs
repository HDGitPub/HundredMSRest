using HundredMSRest.Lib.Api.V2.LiveStreams.DataTypes;
using HundredMSRest.Lib.Api.V2.LiveStreams.Requests;
using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.LiveStreams.Commands;

/// <summary>
/// Class <c>LiveStreamsRestCommand></c> Provides live streaming functionality
/// </summary>
public sealed class LiveStreamsRestCommand : RestCommand
{
    /// <summary>
    /// Constructor
    /// </summary>
    public LiveStreamsRestCommand(string? urlParams = null, string? filterParams = null)
    {
        BuildBaseRoute("v2/live-streams", urlParams,filterParams);
    }

    /// <summary>
    /// Starts a live stream for a room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="request"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<LiveStream> StartAsync(
        string roomId,
        StartLiveStreamRequest request,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new LiveStreamsRestCommand($"room/{roomId}/start");
        return await command.RequestAsync<LiveStream>(
            HttpMethod.Post,
            httpClient,
            requestRecord: request,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Stops all live streams running in a room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<LiveStreamList> StopAsync(
        string roomId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new LiveStreamsRestCommand($"room/{roomId}/stop");
        return await command.RequestAsync<LiveStreamList>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Stops a specified live stream for a room
    /// </summary>
    /// <param name="streamId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<LiveStream> StopByIdAsync(
        string streamId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new LiveStreamsRestCommand($"{streamId}/stop");
        return await command.RequestAsync<LiveStream>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Retrieves a live stream for a room
    /// </summary>
    /// <param name="streamId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<LiveStream> GetAsync(
        string streamId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new LiveStreamsRestCommand($"{streamId}");
        return await command.RequestAsync<LiveStream>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Lists live streams for a workspace
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<LiveStreamList> ListAsync(
        string? filter = null,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new LiveStreamsRestCommand(filterParams: filter);
        return await command.RequestAsync<LiveStreamList>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Send timed metadata for a running live stream.
    /// </summary>
    /// <param name="streamId"></param>
    /// <param name="request"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<LiveStream> SendTimedMetaData(
        string streamId,
        TimedMetaDataRequest request,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new LiveStreamsRestCommand($"{streamId}/timed-metadata");
        return await command.RequestAsync<LiveStream>(
            HttpMethod.Post,
            httpClient,
            requestRecord: request,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Pause recording that is running for the live stream.
    /// </summary>
    /// <param name="streamId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<LiveStream> PauseRecordingAsync(
        string streamId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new LiveStreamsRestCommand($"{streamId}/pause-recording");
        return await command.RequestAsync<LiveStream>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Resumes recording that was paused for a live stream
    /// </summary>
    /// <param name="streamId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<LiveStream> ResumeRecordingAsync(
        string streamId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new LiveStreamsRestCommand($"{streamId}/resume-recording");
        return await command.RequestAsync<LiveStream>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }
}