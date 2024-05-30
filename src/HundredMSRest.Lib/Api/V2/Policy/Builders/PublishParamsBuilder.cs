using HundredMSRest.Lib.Api.V2.Policy.Common;
using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

public sealed class PublishParamsBuilder
{
    #region Attributes
    private readonly PublishParams _publishParams;
    #endregion

    #region Methods
    public PublishParamsBuilder()
    {
        _publishParams = new PublishParams();
    }

    public PublishParamsBuilder AddAllowedTracks(IEnumerable<TrackType> trackTypes)
    {
        _publishParams.allowed = trackTypes;
        return this;
    }

    public PublishParamsBuilder AddAudio(int? bitrate = null, string? codec = null)
    {
        if (bitrate is not null && bitrate < 16 || bitrate > 128)
            throw new Exception(Strings.POLICY_INVALID_AUDIO_BITRATE);
        if (codec is not null && codec != Codec.OPUS)
            throw new Exception(Strings.POLICY_INVALID_AUDIO_CODEC);

        _publishParams.audio = new AudioParams()
        {
            bitRate = bitrate ?? 32,
            codec = codec ?? Codec.OPUS
        };
        return this;
    }

    public PublishParamsBuilder AddVideo(
        int? bitrate,
        string? codec = null,
        int? frameRate = null,
        int? height = null,
        int? width = null
    )
    {
        if (bitrate is not null && bitrate < 30 || bitrate > 2000)
            throw new Exception(Strings.POLICY_INVALID_VIDEO_BITRATE);
        if (codec is not null && codec != Codec.VP8)
            throw new Exception(Strings.POLICY_INVALID_VIDEO_CODEC);
        if (frameRate is not null && frameRate < 1 && frameRate > 30)
            throw new Exception(Strings.POLICY_INVALID_VIDEO_FRAMERATE);
        if (height is not null && height < 50 && height > 1080)
            throw new Exception(Strings.POLICY_INVALID_VIDEO_HEIGHT);
        if (width is not null && width < 50 && width > 1920)
            throw new Exception(Strings.POLICY_INVALID_VIDEO_WIDTH);

        _publishParams.video = new VideoParams()
        {
            bitRate = bitrate ?? 256,
            codec = codec ?? Codec.VP8,
            frameRate = frameRate ?? 25,
            height = height ?? 180,
            width = width ?? 320
        };
        return this;
    }

    public PublishParamsBuilder AddScreen(
        int? bitrate,
        string? codec = null,
        int? frameRate = null,
        int? height = null,
        int? width = null
    )
    {
        if (bitrate is not null && bitrate >= 500)
            throw new Exception(Strings.POLICY_INVALID_SCREEN_BITRATE);
        if (codec is not null && codec != Codec.VP8)
            throw new Exception(Strings.POLICY_INVALID_SCREEN_CODEC);
        if (frameRate is not null && frameRate < 1 && frameRate > 30)
            throw new Exception(Strings.POLICY_INVALID_SCREEN_FRAMERATE);
        if (height is not null && height < 270 && height > 1080)
            throw new Exception(Strings.POLICY_INVALID_SCREEN_HEIGHT);
        if (width is not null && width < 480 && width > 1920)
            throw new Exception(Strings.POLICY_INVALID_SCREEN_WIDTH);

        _publishParams.screen = new ScreenParams()
        {
            bitRate = bitrate ?? 1024,
            codec = codec ?? Codec.VP8,
            frameRate = frameRate ?? 10,
            height = height ?? 720,
            width = width ?? 1280
        };
        return this;
    }

    public PublishParams Build()
    {
        return _publishParams;
    }
    #endregion
}
