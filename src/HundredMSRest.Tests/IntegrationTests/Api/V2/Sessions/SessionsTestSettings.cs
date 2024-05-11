using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Sessions;

internal class SessionsTestSettings : TestSettings
{
    #region Attributes
    private const string SESSION_ID = "HundredMSRest:SessionId";
    private const string SESSION_ROOM_ID = "HundredMSRest:SessionRoomId";
    #endregion

    #region Properties
    public string SessionId => _configuration[SESSION_ID];
    public string SessionRoomId => _configuration[SESSION_ROOM_ID];
    #endregion
}
