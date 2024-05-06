using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.ActiveRooms;

internal class ActiveRoomTestSettings : TestSettings
{
    #region Attributes
    private const string ACTIVE_ROOM_ID = "HundredMSRest:ActiveRoomId";
    private const string PEER_ID = "HundredMSRest:PeerId";
    private const string ROLE = "HundredMSRest:Role";
    private const string USER_ID = "HundredMSRest:UserId";
    #endregion

    #region Properties
    public string ActiveRoomId => _configuration[ACTIVE_ROOM_ID];
    public string PeerId => _configuration[PEER_ID];
    public string Role => _configuration[ROLE];
    public string UserId => _configuration[USER_ID];
    #endregion
}
