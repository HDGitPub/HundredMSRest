using HundredMSRest.Lib.Api.V2.ExternalStreams.DataTypes;


/// <summary>
/// Class <c>DestinationsBuilder</c> Builds destinations config class
/// </summary>
public sealed class ExternalStreamBuilder
{
    #region Attributes
    private readonly ExternalStream _externalStream;
    #endregion

    #region Methods

    public ExternalStreamBuilder()
    {
        _externalStream = new ExternalStream();
    }

    public ExternalStreamBuilder AddRtmpUrls(string[] urls)
    {
        _externalStream.rtmp_urls = urls;
        return this;
    }

    public ExternalStreamBuilder AddRecording(bool enabled)
    {
        _externalStream.recording = enabled;
        return this;
    }

    public ExternalStreamBuilder AddMeetingUrl(string meetingUrl)
    {
        _externalStream.meeting_url = meetingUrl;
        return this;
    }

    public ExternalStreamBuilder AddResolution(int width, int height)
    {
        _externalStream.resolution = new Resolution(width,height);
        return this;
    }

    public ExternalStream Build()
    {
        return _externalStream;
    }
    #endregion
}