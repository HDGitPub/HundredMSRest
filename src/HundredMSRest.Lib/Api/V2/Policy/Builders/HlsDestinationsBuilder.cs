using HundredMSRest.Lib.Api.V2.Policy.DataTypes;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

/// <summary>
/// Class <c>HlsDestinationsBuilder</c> Builds HlsDestinations class
/// </summary>
public sealed class HlsDestinationsBuilder
{
    #region Attributes
    private readonly HlsDestinations _hlsDestinations;
    #endregion

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name"></param>
    public HlsDestinationsBuilder(string name)
    {
        _hlsDestinations = new HlsDestinations(name);
    }

    /// <summary>
    /// Adds max duration
    /// </summary>
    /// <param name="maxDuration"></param>
    /// <returns></returns>
    public HlsDestinationsBuilder AddMaxDuration(int maxDuration)
    {
        _hlsDestinations.maxDuration = maxDuration;
        return this;
    }

    /// <summary>
    /// Adds playlist type
    /// </summary>
    /// <param name="playListType"></param>
    /// <returns></returns>
    public HlsDestinationsBuilder AddPlayListType(string playListType)
    {
        _hlsDestinations.playlistType = playListType;
        return this;
    }

    /// <summary>
    /// Adds num playlist segments
    /// </summary>
    /// <param name="numPlaylistSegments"></param>
    /// <returns></returns>
    public HlsDestinationsBuilder AddNumPlayListSegmets(int numPlaylistSegments)
    {
        _hlsDestinations.numPlaylistSegments = numPlaylistSegments;
        return this;
    }

    /// <summary>
    /// Adds VideoFrameRate
    /// </summary>
    /// <param name="videoFrameRate"></param>
    /// <returns></returns>
    public HlsDestinationsBuilder AddVideoFrameRate(int videoFrameRate)
    {
        _hlsDestinations.videoFrameRate = videoFrameRate;
        return this;
    }

    /// <summary>
    /// Adds EnabledMetaDataInsertion
    /// </summary>
    /// <param name="enableMetaDataInsertion"></param>
    /// <returns></returns>
    public HlsDestinationsBuilder AddEnableMetaDataInsertion(bool enableMetaDataInsertion)
    {
        _hlsDestinations.enableMetadataInsertion = enableMetaDataInsertion;
        return this;
    }

    /// <summary>
    /// Adds StaticUrl
    /// </summary>
    /// <param name="enableStaticUrl"></param>
    /// <returns></returns>
    public HlsDestinationsBuilder AddStaticUrl(bool enableStaticUrl)
    {
        _hlsDestinations.enableStaticUrl = enableStaticUrl;
        return this;
    }

    /// <summary>
    /// Adds autostoptimeout
    /// </summary>
    /// <param name="autoStopTimeout"></param>
    /// <returns></returns>
    public HlsDestinationsBuilder AddAutoStopTimeout(int autoStopTimeout)
    {
        _hlsDestinations.autoStopTimeout = autoStopTimeout;
        return this;
    }

    /// <summary>
    /// Adds Hlslayer configuration
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="videoBitrate"></param>
    /// <param name="audioBitrate"></param>
    /// <returns></returns>
    public HlsDestinationsBuilder AddHlsLayers(
        int? width,
        int? height,
        int? videoBitrate,
        int? audioBitrate
    )
    {
        var hlsLayer = new HlsLayer()
        {
            width = width,
            height = height,
            videoBitrate = videoBitrate,
            audioBitrate = audioBitrate
        };

        _hlsDestinations.layers = hlsLayer;
        return this;
    }

    /// <summary>
    /// Adds hls recording configuration
    /// </summary>
    /// <param name="hlsVod"></param>
    /// <param name="singleFilePerLayer"></param>
    /// <param name="enableZipUpload"></param>
    /// <param name="layers"></param>
    /// <param name="thumbnails"></param>
    /// <param name="presignDuration"></param>
    /// <returns></returns>
    public HlsDestinationsBuilder AddHlsRecording(
        bool? hlsVod,
        bool? singleFilePerLayer,
        bool? enableZipUpload,
        HlsLayer? layers,
        Thumbnail? thumbnails,
        int presignDuration
    )
    {
        var hlsRecording = new HlsRecording()
        {
            singleFilePerLayer = singleFilePerLayer,
            enableZipUpload = enableZipUpload ?? false,
            hlsVod = hlsVod,
            layers = layers,
            thumbnails = thumbnails,
            presignDuration = presignDuration
        };
        _hlsDestinations.recording = hlsRecording;
        return this;
    }

    /// <summary>
    /// Returns a configured instance of HlsDestinations class
    /// </summary>
    /// <returns></returns>
    public HlsDestinations Build()
    {
        return _hlsDestinations;
    }
    #endregion
}
