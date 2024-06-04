using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Api.V2.Policy.DataTypes;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

public sealed class DestinationsBuilder
{
    #region Attributes
    private readonly Destinations _destinations;
    #endregion

    #region Method

    public DestinationsBuilder()
    {
        _destinations = new Destinations();
    }

    public DestinationsBuilder AddRtmpDestinations(string name, int? width,int? height, int? maxDuration,string[]? rtmpUrls,bool? recordingEnabled, int autoStopTimeout)
    {
        var rtmpDestinations = new RtmpDestinations(name)
        {
            width = width,
            height = height,
            maxDuration = maxDuration, 
            rtmpUrls = rtmpUrls,
            recordingEnabled = recordingEnabled,
            autoStopTimeout = autoStopTimeout
        };

        _destinations.rtmpDestinations = rtmpDestinations;
        return this;
    }

    public DestinationsBuilder AddHlsDestinations(HlsDestinations hlsDestinations)
    {
        _destinations.hlsDestinations = hlsDestinations;
        return this;
    }

    public DestinationsBuilder AddTranscription(Transcription transcription)
    {
        _destinations.transcriptions = transcription;
        return this;
    }
    #endregion
}