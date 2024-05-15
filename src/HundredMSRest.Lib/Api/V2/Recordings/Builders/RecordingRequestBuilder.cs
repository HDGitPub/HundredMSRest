using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Api.V2.Recordings.DataTypes;
using HundredMSRest.Lib.Api.V2.Recordings.Requests;

namespace HundredMSRest.Lib.Api.V2.Recordings.Builders;

/// <summary>
/// Class <c>RecordingRequestBuilder</c> builds a recording request
/// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/recordings/start-recording-for-room"/>
/// </summary>
public sealed class RecordingRequestBuilder
{
    #region Attributes
    private readonly RecordingRequest _request;
    #endregion

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    public RecordingRequestBuilder()
    {
        _request = new RecordingRequest();
    }

    /// <summary>
    /// Add a meeting url
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public RecordingRequestBuilder AddMeetingUrl(string meetingUrl)
    {
        _request.meeting_url = meetingUrl;
        return this;
    }

    /// <summary>
    /// Add a recording resolution
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public RecordingRequestBuilder AddResolution(int width, int height)
    {
        _request.resolution = new Resolution(width, height);
        return this;
    }

    /// <summary>
    /// Add a destination
    /// </summary>
    /// <param name="destination"></param>
    /// <returns></returns>
    public RecordingRequestBuilder AddDestination(string destination)
    {
        _request.destination = destination;
        return this;
    }

    /// <summary>
    /// Specify audio only recording
    /// </summary>
    /// <param name="audioOnly"></param>
    /// <returns></returns>
    public RecordingRequestBuilder AddAudioOnly(bool audioOnly)
    {
        _request.audio_only = audioOnly;
        return this;
    }

    /// <summary>
    /// Add a transcription
    /// </summary>
    /// <returns></returns>
    public RecordingRequestBuilder AddTranscription(Transcription transcription)
    {
        _request.transcription = transcription;
        return this;
    }

    /// <summary>
    /// Returns a configured RecordingRequest object
    /// </summary>
    /// <returns></returns>
    public RecordingRequest Build()
    {
        // todo: validate rules
        return _request;
    }
    #endregion
}
