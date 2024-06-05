using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

/// <summary>
/// Class <c>HlsDestinationsBuilder</c> Builds HlsDestinations class
/// </summary>
public sealed class RtmpDestinationsBuilder
{
    #region Attributes
    private readonly RtmpDestinations _rtmpDestinations;
    #endregion

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name"></param>
    public RtmpDestinationsBuilder(string name)
    {
        _rtmpDestinations = new RtmpDestinations(name);
    }

    /// <summary>
    /// Adds width
    /// </summary>
    /// <param name="width"></param>
    /// <returns></returns>
    public RtmpDestinationsBuilder AddWidth(int width)
    {
        _rtmpDestinations.width = width;
        return this;
    }

    /// <summary>
    /// Adds height
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public RtmpDestinationsBuilder AddHeight(int height)
    {
        _rtmpDestinations.height = height;
        return this;
    }

    /// <summary>
    /// Adds MaxDuration
    /// </summary>
    /// <param name="maxDuration"></param>
    /// <returns></returns>
    public RtmpDestinationsBuilder AddMaxDuration(int maxDuration)
    {
        _rtmpDestinations.maxDuration = maxDuration;
        return this;
    }

    /// <summary>
    /// Adds Rtmp urls
    /// </summary>
    /// <param name="rtmpUrls"></param>
    /// <returns></returns>
    public RtmpDestinationsBuilder AddRtmpUrls(IEnumerable<string> rtmpUrls)
    {
        if (rtmpUrls.Count() > 3)
            throw new ArgumentException(Strings.POLICY_INVALID_RTMPURL_COUNT);
        _rtmpDestinations.rtmpUrls = rtmpUrls;
        return this;
    }

    /// <summary>
    /// Adds Recording enabled
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public RtmpDestinationsBuilder SetRecordingEnabled(bool enabled)
    {
        _rtmpDestinations.recordingEnabled = enabled;
        return this;
    }

    /// <summary>
    /// Adds AutoStopTimeout
    /// </summary>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public RtmpDestinationsBuilder AddAutoStopTimeout(int timeout)
    {
        _rtmpDestinations.autoStopTimeout = timeout;
        return this;
    }

    /// <summary>
    /// Returns a configured instance of RtmpDestinations
    /// </summary>
    /// <returns></returns>
    public RtmpDestinations Build()
    {
        return _rtmpDestinations;
    }
    #endregion
}
