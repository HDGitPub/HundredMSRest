using HundredMSRest.Lib.Api.V2.Recordings.DataTypes;
using HundredMSRest.Lib.Api.V2.Recordings.Requests;
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
    public RecordingRestCommand(string? urlExtension = null)
    {
        string baseRoute = "v2/recordings";
        BaseUrl = urlExtension is not null ? $"{baseRoute}/{urlExtension}" : baseRoute;
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
}
