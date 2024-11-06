using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.ExternalStreams;

internal class ExternalStreamTestSettings : TestSettings
{
    #region Attributes
    private const string STREAM_ID = "HundredMSRest:ExternalStream:Id";
    private const string ROOM_ID = "HundredMSRest:ExternalStream:RoomId";
    #endregion

    #region Methods
    public ExternalStreamTestSettings() { }
    #endregion

    #region Properties
    public string StreamId => _configuration[STREAM_ID];
    public string RoomId => _configuration[ROOM_ID];
    #endregion
}
