using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Analytics;

internal class AnalyticsTestSettings : TestSettings
{
    #region Attributes
    private const string ROOM_ID = "HundredMSRest:Analytics:RoomId";
    #endregion

    #region Methods
    public AnalyticsTestSettings() { }
    #endregion

    #region Properties
    public string RoomId => _configuration[ROOM_ID];
    #endregion
}
