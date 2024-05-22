using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Recordings;

internal class RecordingsTestSettings : TestSettings
{
    #region Attributes
    private const string RECORDING_ID = "HundredMSRest:Recording:Id";
    private const string RECORDING_ROOM_ID = "HundredMSRest:Recording:RoomId";
    #endregion

    #region Properties
    public string RecordingId => _configuration[RECORDING_ID];
    public string RecordingRoomId => _configuration[RECORDING_ROOM_ID];
    #endregion
}
