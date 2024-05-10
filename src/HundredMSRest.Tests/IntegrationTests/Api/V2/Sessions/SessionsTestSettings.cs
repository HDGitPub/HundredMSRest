using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Sessions;

internal class SessionsTestSettings : TestSettings
{
    #region Attributes
    private const string SESSION_ID = "HundredMSRest:SessionId";
    #endregion

    #region Properties
    public string SessionId => _configuration[SESSION_ID];
    #endregion
}
