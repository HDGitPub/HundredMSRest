using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Recordings;

internal class RecordingsTestSettings : TestSettings
{
    #region Attributes
    private const string RECORDING_ID = "HundredMSRest:RecordingId";
    private const string RECORDING_ROOM_ID = "HundredMSRest:RecordingRoomId";
    #endregion

    #region Properties
    public string RecordingId => _configuration[RECORDING_ID];
    public string RecordingRoomId => _configuration[RECORDING_ROOM_ID];
    #endregion
}
