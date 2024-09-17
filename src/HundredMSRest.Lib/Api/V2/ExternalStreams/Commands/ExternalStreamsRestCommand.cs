using HundredMSRest.Lib.Api.V2.ExternalStreams.DataTypes;
using HundredMSRest.Lib.Core.Commands;
using System.Diagnostics.Contracts;

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
    /// Starts an external stream
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    public static async Task<ExternalStream> Start(
        string roomId,
        ExternalStream externalStream,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new ExternalStreamsRestCommand($"room/{roomId}/start");
        return await command.RequestAsync<ExternalStream>(
            HttpMethod.Post,
            httpClient,
            requestRecord: externalStream,
            cancellationToken: cancellationToken
        );
    }
}