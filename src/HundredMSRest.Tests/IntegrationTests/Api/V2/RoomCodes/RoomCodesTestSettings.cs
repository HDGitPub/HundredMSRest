using HundredMSRest.Tests.IntegrationTests.Core;

internal class RoomCodesTestSettings : TestSettings
{
    #region Attributes
    private const string ROOM_ID = "HundredMSRest:RoomCodes:RoomId";
    private const string ROOM_CODE = "HundredMSRest:RoomCodes:RoomCode";

    #endregion

    #region Properties
    public string RoomId => _configuration[ROOM_ID];
    public string RoomCode => _configuration[ROOM_CODE];
    #endregion
}
