using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Sessions;

internal class SessionsTestSettings : TestSettings
{
    #region Attributes
    private const string SESSION_ID = "HundredMSRest:Sessions:Id";
    private const string SESSION_ROOM_ID = "HundredMSRest:Sessions:RoomId";
    #endregion

    #region Properties
    public string SessionId => _configuration[SESSION_ID];
    public string SessionRoomId => _configuration[SESSION_ROOM_ID];
    #endregion
}
