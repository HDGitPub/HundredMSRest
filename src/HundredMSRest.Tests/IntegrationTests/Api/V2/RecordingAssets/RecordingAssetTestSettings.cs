using HundredMSRest.Tests.IntegrationTests.Core;

internal class RecordingAssetTestSettings : TestSettings
{
    #region Attributes
    private const string ASSET_ID = "HundredMSRest:AssetId";
    private const string ROOM_ID = "HundredMSRest:RoomId";
    private const string SESSION_ID = "HundredMSRest:SessionId";
    private const string STATUS = "HundredMSRest:Status";
    #endregion

    #region Properties
    public string AssetId => _configuration[ASSET_ID];
    public string RoomId => _configuration[ROOM_ID];
    public string SessionId => _configuration[SESSION_ID];
    public string Status => _configuration[STATUS];
    #endregion
}