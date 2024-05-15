using HundredMSRest.Lib.Api.V2.Recordings.DataTypes;
using HundredMSRest.Lib.Api.V2.Recordings.Requests;
using HundredMSRest.Lib.Api.V2.Sessions.Commands;
using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.Recordings.Commands;

/// <summary>
/// Class <c>RecordingRestCommand</c> Provides room recording commands
/// </summary>
public class RecordingRestCommand : RestCommand
{
    /// <summary>
    /// Constructor takes custom url extension
    /// </summary>
    public RecordingRestCommand(string? urlParams = null, string? filterParams = null)
    {
        string baseRoute = "v2/recordings";
        BaseUrl = urlParams is not null ? $"{baseRoute}/{urlParams}" : baseRoute;
        if (urlParams is not null)
            return;

        BaseUrl = filterParams is not null ? $"{baseRoute}{filterParams}" : baseRoute;
    }

    /// <summary>
    /// Returns a specific recording
    /// </summary>
    /// <param name="recordingId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Recording?> GetAsync(
        string recordingId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RecordingRestCommand(recordingId);
        return await command.RequestAsync<Recording>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Starts recording a room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="request"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Recording?> StartRecordingAsync(
        string roomId,
        RecordingRequest request,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RecordingRestCommand($"room/{roomId}/start");
        return await command.RequestAsync<Recording>(
            HttpMethod.Post,
            httpClient,
            requestRecord: request,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Stops all recordings in a room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<RecordingList?> StopRecordingAsync(
        string roomId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RecordingRestCommand($"room/{roomId}/stop");
        return await command.RequestAsync<RecordingList>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Stops a recording by recording id
    /// </summary>
    /// <param name="recordingId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Recording?> StopRecordingByIdAsync(
        string recordingId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RecordingRestCommand($"{recordingId}/stop");
        return await command.RequestAsync<Recording>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Pause a recording by recording id
    /// </summary>
    /// <param name="recordingId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Recording?> PauseRecordingAsync(
        string recordingId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RecordingRestCommand($"{recordingId}/pause");
        return await command.RequestAsync<Recording>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Resumes a recording by recording id
    /// </summary>
    /// <param name="recordingId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Recording?> ResumeRecordingAsync(
        string recordingId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RecordingRestCommand($"{recordingId}/resume");
        return await command.RequestAsync<Recording>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns a list of recordings
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<RecordingList?> ListRecordingsAsync(
        string filter,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new SessionRestCommand(filterParams: filter);
        return await command.RequestAsync<RecordingList>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }
}
