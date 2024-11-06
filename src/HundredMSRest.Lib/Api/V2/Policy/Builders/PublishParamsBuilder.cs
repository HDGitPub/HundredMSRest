using HundredMSRest.Lib.Api.V2.Policy.Common;
using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

/// <summary>
/// Class <c>PublicParamsBuilder</c> Builds PublishParams class
/// </summary>
public sealed class PublishParamsBuilder
{
    #region Attributes
    private readonly PublishParams _publishParams;
    #endregion

    #region Methods
    /// <summary>
    /// Constructor
    /// </summary>
    public PublishParamsBuilder()
    {
        _publishParams = new PublishParams();
    }

    /// <summary>
    /// Adds Allowed track types
    /// </summary>
    /// <param name="trackTypes"></param>
    /// <returns></returns>
    public PublishParamsBuilder AddAllowedTracks(IEnumerable<TrackType>? trackTypes = null)
    {
        var tracks = new List<string>();
        if (trackTypes?.Count() > 0)
        {
            tracks = [];
            foreach (TrackType trackType in trackTypes)
            {
                tracks.Add(trackType.Value);
            }
        }

        _publishParams.allowed = tracks.Count > 0 ? tracks : null;
        return this;
    }

    /// <summary>
    /// Adds audio config
    /// </summary>
    /// <param name="bitRate"></param>
    /// <param name="codec"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public PublishParamsBuilder AddAudio(int? bitRate = null, string? codec = null)
    {
        if (bitRate is not null && bitRate < 16 || bitRate > 128)
            throw new ArgumentException(Strings.POLICY_INVALID_AUDIO_BITRATE);
        if (codec is not null && codec != Codec.OPUS)
            throw new ArgumentException(Strings.POLICY_INVALID_AUDIO_CODEC);

        _publishParams.audio = new AudioParams()
        {
            bitRate = bitRate ?? 32,
            codec = codec ?? Codec.OPUS
        };
        return this;
    }

    /// <summary>
    /// Adds video config
    /// </summary>
    /// <param name="bitRate"></param>
    /// <param name="frameRate"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="codec"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public PublishParamsBuilder AddVideo(
        int? bitRate = null,
        int? frameRate = null,
        int? width = null,
        int? height = null,
        string? codec = null
    )
    {
        if (bitRate is not null && bitRate < 30 || bitRate > 2000)
            throw new ArgumentException(Strings.POLICY_INVALID_VIDEO_BITRATE);
        if (codec is not null && codec != Codec.VP8)
            throw new ArgumentException(Strings.POLICY_INVALID_VIDEO_CODEC);
        if (frameRate is not null && frameRate < 1 && frameRate > 30)
            throw new ArgumentException(Strings.POLICY_INVALID_VIDEO_FRAMERATE);
        if (height is not null && height < 50 && height > 1080)
            throw new ArgumentException(Strings.POLICY_INVALID_VIDEO_HEIGHT);
        if (width is not null && width < 50 && width > 1920)
            throw new ArgumentException(Strings.POLICY_INVALID_VIDEO_WIDTH);

        _publishParams.video = new VideoParams()
        {
            bitRate = bitRate ?? 256,
            codec = codec ?? Codec.VP8,
            frameRate = frameRate ?? 25,
            height = height ?? 180,
            width = width ?? 320
        };
        return this;
    }

    /// <summary>
    /// Adds screen config
    /// </summary>
    /// <param name="bitRate"></param>
    /// <param name="frameRate"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="codec"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public PublishParamsBuilder AddScreen(
        int? bitRate = null,
        int? frameRate = null,
        int? width = null,
        int? height = null,
        string? codec = null
    )
    {
        if (bitRate is not null && bitRate < 500)
            throw new ArgumentException(Strings.POLICY_INVALID_SCREEN_BITRATE);
        if (codec is not null && codec != Codec.VP8)
            throw new ArgumentException(Strings.POLICY_INVALID_SCREEN_CODEC);
        if (frameRate is not null && frameRate < 1 && frameRate > 30)
            throw new ArgumentException(Strings.POLICY_INVALID_SCREEN_FRAMERATE);
        if (height is not null && height < 270 && height > 1080)
            throw new ArgumentException(Strings.POLICY_INVALID_SCREEN_HEIGHT);
        if (width is not null && width < 480 && width > 1920)
            throw new ArgumentException(Strings.POLICY_INVALID_SCREEN_WIDTH);

        _publishParams.screen = new ScreenParams()
        {
            bitRate = bitRate ?? 1024,
            codec = codec ?? Codec.VP8,
            frameRate = frameRate ?? 10,
            height = height ?? 720,
            width = width ?? 1280
        };
        return this;
    }

    /// <summary>
    /// Returns a configured instance of PublishParams
    /// </summary>
    /// <returns></returns>
    public PublishParams Build()
    {
        return _publishParams;
    }
    #endregion
}
