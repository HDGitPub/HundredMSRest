using HundredMSRest.Tests.IntegrationTests.Core;

internal class RecordingAssetTestSettings : TestSettings
{
    #region Attributes
    private const string ASSET_ID = "HundredMSRest:RecordingAsset:Id";
    private const string RECORDING_ROOM_ID = "HundredMSRest:RecordingAsset:RoomId";
    private const string SESSION_ID = "HundredMSRest:RecordingAsset:SessionId";
    private const string STATUS = "HundredMSRest:RecordingAsset:Status";
    #endregion

    #region Properties
    public string AssetId => _configuration[ASSET_ID];
    public string RoomId => _configuration[RECORDING_ROOM_ID];
    public string SessionId => _configuration[SESSION_ID];
    public string Status => _configuration[STATUS];
    #endregion
}
