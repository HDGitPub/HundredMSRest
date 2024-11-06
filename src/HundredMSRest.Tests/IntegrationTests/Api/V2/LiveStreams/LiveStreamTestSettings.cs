using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.LiveStreams;

internal class LiveStreamTestSettings : TestSettings
{
    #region Attributes
    private const string STREAM_ID = "HundredMSRest:LiveStream:Id";
    private const string ROOM_ID = "HundredMSRest:LiveStream:RoomId";
    private const string MEETING_URL = "HundredMSRest:LiveStream:MeetingUrl";
    private const string LIMIT = "HundredMSRest:LiveStream:Limit";
    private const string PAYLOAD = "HundredMSRest:LiveStream:Payload";
    private const string DURATION = "HundredMSRest:LiveStream:Duration";
    #endregion

    #region Methods
    public LiveStreamTestSettings() { }
    #endregion

    #region Properties
    public string StreamId => _configuration[STREAM_ID];
    public string RoomId => _configuration[ROOM_ID];
    public string MeetingUrl => _configuration[MEETING_URL];
    public string Payload => _configuration[PAYLOAD];
    public int Duration => int.Parse(_configuration[DURATION]);
    public int Limit => int.Parse(_configuration[LIMIT]);
    #endregion
}
