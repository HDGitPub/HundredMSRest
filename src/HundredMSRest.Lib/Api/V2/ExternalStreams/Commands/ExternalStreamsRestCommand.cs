using HundredMSRest.Lib.Api.V2.ExternalStreams.DataTypes;
using HundredMSRest.Lib.Api.V2.ExternalStreams.Requests;
using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.ExternalStreams.Commands;

/// <summary>
/// Class <c>ExternalStreamsRestCommand></c> Provides external streaming functionality
/// </summary>
public sealed class ExternalStreamsRestCommand : RestCommand
{
    /// <summary>
    /// Constructor
    /// </summary>
    public ExternalStreamsRestCommand(string? urlParams = null)
    {
        BuildBaseRoute("v2/external-streams", urlParams);
    }

    /// <summary>
    /// Stops an external stream
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    public static async Task<ExternalStreamList> StopRoomStreamAsync(
        string roomId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ExternalStreamsRestCommand($"room/{roomId}/stop");
        return await command.RequestAsync<ExternalStreamList>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    public static async Task<ExternalStream> StopStreamAsync(
        string streamId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ExternalStreamsRestCommand($"{streamId}/stop");
        return await command.RequestAsync<ExternalStream>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Starts an External Stream
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="externalStream"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<ExternalStream> StartAsync(
        string roomId,
        StartExternalStreamRequest request,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ExternalStreamsRestCommand($"room/{roomId}/start");
        return await command.RequestAsync<ExternalStream>(
            HttpMethod.Post,
            httpClient,
            requestRecord: request,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns an ExternalStream
    /// </summary>
    /// <param name="streamId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<ExternalStream> GetAsync(
        string streamId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ExternalStreamsRestCommand(streamId);
        return await command.RequestAsync<ExternalStream>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns a list of ExternalStreams
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<ExternalStreamList> ListAsync(
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ExternalStreamsRestCommand();
        return await command.RequestAsync<ExternalStreamList>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }
}