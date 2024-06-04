using HundredMSRest.Lib.Api.V2.Policy.DataTypes;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

public sealed class HlsDestinationsBuilder
{
    #region Attributes
    private readonly HlsDestinations _hlsDestinations;
    #endregion

    #region Method
    public HlsDestinationsBuilder()
    {
        _hlsDestinations = new HlsDestinations("");
    }

    public HlsRecording? recording { get; set; }

    public HlsDestinationsBuilder AddMaxDuration(int maxDuration)
    {
        _hlsDestinations.maxDuration = maxDuration;
        return this;
    }

    public HlsDestinationsBuilder AddPlayListType(string playListType)
    {
        _hlsDestinations.playlistType = playListType;
        return this;
    }

    public HlsDestinationsBuilder AddNumPlayListSegmets(int numPlaylistSegments)
    {
        _hlsDestinations.numPlaylistSegments = numPlaylistSegments;
        return this;
    }

    public HlsDestinationsBuilder AddVideoFrameRate(int videoFrameRate)
    {
        _hlsDestinations.videoFrameRate = videoFrameRate;
        return this;
    }

    public HlsDestinationsBuilder AddEnableMetaDataInsertion(bool enableMetaDataInsertion)
    {
        _hlsDestinations.enableMetadataInsertion = enableMetaDataInsertion;
        return this;
    }

    public HlsDestinationsBuilder AddStaticUrl(bool enableStaticUrl)
    {
        _hlsDestinations.enableStaticUrl = enableStaticUrl;
        return this;
    }

    public HlsDestinationsBuilder AddAutoStopTimeout(int autoStopTimeout)
    {
        _hlsDestinations.autoStopTimeout = autoStopTimeout;
        return this;
    }

    public HlsDestinationsBuilder AddHlsLayers(int? width, int? height, int? videoBitrate, int? audioBitrate)
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

        public bool hlsVod { get; set; }
    public bool singleFilePerLayer { get; set; }
    public bool enableZipUpload { get; set; }
    public HlsLayer? layers { get; set; }
    public Thumbnail? thumbnails { get; set; }
    public int presignDuration { get; set; }

    public HlsDestinationsBuilder AddHlsRecording(bool? hlsVod,bool? singleFilePerLayer, bool? enableZipUpload,HlsLayer? layers,Thumbnail? thumbnails,int presignDuration)
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

    #endregion
}