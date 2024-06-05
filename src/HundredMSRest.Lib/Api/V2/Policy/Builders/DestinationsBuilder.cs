using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Api.V2.Policy.DataTypes;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

/// <summary>
/// Class <c>DestinationsBuilder</c> Builds destinations config class
/// </summary>
public sealed class DestinationsBuilder
{
    #region Attributes
    private readonly Destinations _destinations;
    #endregion

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    public DestinationsBuilder()
    {
        _destinations = new Destinations();
    }

    /// <summary>
    /// Add RtmpDestinations for social media sites
    /// </summary>
    /// <param name="rtmpDestinations"></param>
    /// <returns></returns>
    public DestinationsBuilder AddRtmpDestinations(RtmpDestinations rtmpDestinations)
    {
        _destinations.rtmpDestinations ??= new Dictionary<string, RtmpDestinations>();
        _destinations.rtmpDestinations.Add(rtmpDestinations.name, rtmpDestinations);
        return this;
    }

    /// <summary>
    /// Adds Hls destinations
    /// </summary>
    /// <param name="hlsDestinations"></param>
    /// <returns></returns>
    public DestinationsBuilder AddHlsDestinations(HlsDestinations hlsDestinations)
    {
        _destinations.hlsDestinations ??= new Dictionary<string, HlsDestinations>();
        _destinations.hlsDestinations.Add(hlsDestinations.name, hlsDestinations);
        return this;
    }

    /// <summary>
    /// Add transcription configuration
    /// </summary>
    /// <param name="transcription"></param>
    /// <returns></returns>
    public DestinationsBuilder AddTranscription(Transcription transcription)
    {
        _destinations.transcriptions ??= new Dictionary<string, Transcription>();
        _destinations.transcriptions.Add(transcription.name, transcription);
        return this;
    }

    /// <summary>
    /// Returns a configured instance of Destinations class
    /// </summary>
    /// <returns></returns>
    public Destinations Build()
    {
        return _destinations;
    }
    #endregion
}
