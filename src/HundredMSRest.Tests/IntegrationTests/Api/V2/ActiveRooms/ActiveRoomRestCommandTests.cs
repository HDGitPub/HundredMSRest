using FluentAssertions;
using HundredMSRest.Lib.Api.V2.ActiveRooms.Commands;
using HundredMSRest.Lib.Api.V2.ActiveRooms.DataTypes;
using HundredMSRest.Lib.Api.V2.ActiveRooms.Requests;
using HundredMSRest.Lib.Api.V2.Common.DataTypes;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.ActiveRooms;

/// <summary>
/// Class <c>ActiveRoomRestCommandTests</c> Tests ActiveRoom commands against the 100MS rest api
/// </summary>
public class ActiveRoomRestCommandTests
{
    private readonly ActiveRoomTestSettings _settings;

    public ActiveRoomRestCommandTests()
    {
        _settings = new ActiveRoomTestSettings();
    }

    [Fact]
    public async void Get_ActiveRoom_ReturnsActiveRoom()
    {
        // Arrange
        var expected = new { id = _settings.ActiveRoomId };

        // Act
        var result = await ActiveRoomRestCommand.GetAsync(_settings.ActiveRoomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ActiveRoom>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void Get_Peer_ReturnsPeer()
    {
        // Arrange
        string peerId = _settings.PeerId;

        var expected = new { id = _settings.PeerId };

        // Act
        var result = await ActiveRoomRestCommand.GetPeerAsync(_settings.ActiveRoomId, peerId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Peer>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void ListPeers_ReturnsPeers()
    {
        // Arrange

        // Act
        var result = await ActiveRoomRestCommand.ListPeersAsync(_settings.ActiveRoomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<PeerList>();
        result?.peers.Should().NotBeNull();
    }

    [Fact]
    public async void ListPeers_ByUserId_ReturnsPeers()
    {
        // Arrange
        string userId = _settings.UserId;

        // Act
        var result = await ActiveRoomRestCommand.ListPeersAsync(_settings.ActiveRoomId, userId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<PeerList>();
        result?.peers.Should().NotBeNull();
    }

    [Fact]
    public async void Update_Peer_Name_UpdatesPeer()
    {
        // Arrange
        string peerId = _settings.PeerId;
        string newPeerName = "NewPeerName";
        var request = new UpdateActiveRoomPeerRequest() { name = newPeerName };

        var expected = new { name = newPeerName };

        // Act
        var result = await ActiveRoomRestCommand.UpdatePeerAsync(
            _settings.ActiveRoomId,
            peerId,
            request
        );

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Peer>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void Update_Peer_Role_UpdatesPeer()
    {
        // Arrange
        string peerId = _settings.PeerId;
        string newRole = _settings.Role;
        var request = new UpdateActiveRoomPeerRequest() { role = newRole };
        var expected = new { role = newRole };

        // Act
        var result = await ActiveRoomRestCommand.UpdatePeerAsync(
            _settings.ActiveRoomId,
            peerId,
            request
        );

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Peer>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void SendMessage_ToAllPeers_ReturnsResponse()
    {
        // Arrange
        var request = new ActiveRoomMessageRequest()
        {
            role = "host",
            message = "test message",
            type = "chat"
        };

        var expected = new { message = "message sent" };

        // Act
        var result = await ActiveRoomRestCommand.SendMessageAsync(_settings.ActiveRoomId, request);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ActiveRoomResponse>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void SendMessage_ToPeer_ReturnsResponse()
    {
        // Arrange
        string peerId = _settings.PeerId;
        var request = new ActiveRoomMessageRequest()
        {
            peer_id = peerId,
            message = "test message",
            type = "chat"
        };

        var expected = new { message = "message sent" };

        // Act
        var result = await ActiveRoomRestCommand.SendMessageAsync(_settings.ActiveRoomId, request);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ActiveRoomResponse>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void RemovePeers_ById_ReturnsResponse()
    {
        // Arrange
        string peerId = _settings.PeerId;
        var request = new RemovePeerRequest() { peer_id = peerId, reason = "test reason" };

        var expected = new { message = "peer remove request submitted" };

        // Act
        var result = await ActiveRoomRestCommand.RemovePeers(_settings.ActiveRoomId, request);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ActiveRoomResponse>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void RemovePeers_ByRole_ReturnsResponse()
    {
        // Arrange
        string role = _settings.Role;
        var request = new RemovePeerRequest() { role = role, reason = "test reason" };

        var expected = new { message = "peer remove request submitted" };

        // Act
        var result = await ActiveRoomRestCommand.RemovePeers(_settings.ActiveRoomId, request);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ActiveRoomResponse>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void End_ActiveRoom_EndsActiveRoom()
    {
        // Arrange
        var request = new EndRoomRequest() { reason = "Ending Room", @lock = false };

        // Act
        var result = await ActiveRoomRestCommand.EndRoom(_settings.ActiveRoomId, request);

        var expected = new { message = "session is ending" };

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ActiveRoomResponse>();
        result.Should().BeEquivalentTo(expected);
    }
}
