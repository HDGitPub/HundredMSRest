using HundredMSRest.Tests.IntegrationTests.Core;

internal class RoomCodesTestSettings : TestSettings
{
    #region Attributes
    private const string ROOM_ID = "HundredMSRest:RoomCode:RoomId";

    #endregion

    #region Properties
    public string RoomId => _configuration[ROOM_ID];
    #endregion
}
