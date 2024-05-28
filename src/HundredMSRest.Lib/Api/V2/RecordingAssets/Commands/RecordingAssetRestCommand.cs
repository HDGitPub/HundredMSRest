using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Api.V2.RecordingAssets.DataTypes;
using HundredMSRest.Lib.Api.V2.RecordingAssets.Responses;
using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.RecordingAssets.Commands;

/// <summary>
/// Class <cRecordingAssetsRestCommand></c> Provides recording assets commands
/// </summary>
public sealed class RecordingAssetRestCommand : RestCommand
{
    #region Methods
    /// <summary>
    ///
    /// </summary>
    /// <param name="urlParams"></param>
    /// <param name="filterParams"></param>
    public RecordingAssetRestCommand(string? urlParams = null, string? filterParams = null)
    {
        BuildBaseRoute("v2/recording-assets", urlParams, filterParams);
    }

    /// <summary>
    /// Returns a room recording asset
    /// </summary>
    /// <param name="assetId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<RecordingAsset?> GetAsync(
        string assetId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RecordingAssetRestCommand(assetId);
        var result = await command.RequestAsync<RecordingAsset>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
        return result;
    }

    /// <summary>
    /// Returns a pre-signed url
    /// </summary>
    /// <param name="assetId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<PresignedUrl?> GetPreSignedUrlAsync(
        string assetId,
        int? duration = null,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var commandUrl = duration is not null
            ? $"{assetId}/presigned-url?presign_duration={duration}"
            : $"{assetId}/presigned-url";
        var command = new RecordingAssetRestCommand(commandUrl);
        var result = await command.RequestAsync<PresignedUrl>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
        return result;
    }

    /// <summary>
    /// Returns a list of recording assets
    /// </summary>
    /// <param name="assetId"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<RecordingAssetList?> ListAsync(
        string? filter = null,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new RecordingAssetRestCommand(filterParams: filter);
        var result = await command.RequestAsync<RecordingAssetList>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
        return result;
    }
    #endregion
}
