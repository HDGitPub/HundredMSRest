using FluentAssertions;
using HundredMSRest.Lib.Api.V2.RoomCodes.Commands;
using HundredMSRest.Lib.Api.V2.RoomCodes.DataTypes;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.RoomCodes;

public class RoomCodesRestCommandTests
{
    private readonly RoomCodesTestSettings _settings;

    public RoomCodesRestCommandTests()
    {
        _settings = new RoomCodesTestSettings();
    }

    [Fact]
    public async Task Create_RoomCode_ReturnsRoomCodeList()
    {
        // Arrange
        var roomId = _settings.RoomId;
        // Act
        var result = await RoomCodeRestCommand.CreateAsync(roomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RoomCodeList>();
        result?.data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Create_RoleRoomCode_ReturnsRoomCodeList()
    {
        // Arrange
        var roomId = _settings.RoomId;
        var role = "guest";

        // Act
        var result = await RoomCodeRestCommand.CreateRoleRoomCodeAsync(roomId, role);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RoomCode>();
        result?.code.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task List_RoomCodes_ReturnsRoomCodes()
    {
        // Arrange
        var roomId = _settings.RoomId;
        // Act
        var result = await RoomCodeRestCommand.ListAsync(roomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RoomCodeList>();
    }

    [Fact]
    public async Task Update_RoomCode_ReturnsRoomCode()
    {
        // Arrange
        var roomCode = _settings.RoomCode;
        var enabled = false;
        // Act
        var result = await RoomCodeRestCommand.UpdateAsync(roomCode, enabled);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RoomCodeList>();
    }
}
