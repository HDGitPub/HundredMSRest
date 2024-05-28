using FluentAssertions;
using HundredMSRest.Lib.Api.V2.RoomCodes.Commands;
using HundredMSRest.Lib.Api.V2.RoomCodes.DataTypes;

public class RoomCodesRestCommandTests
{
    private readonly RoomCodesTestSettings _settings;

    public RoomCodesRestCommandTests()
    {
        _settings = new RoomCodesTestSettings();
    }

    [Fact]
    public async void Create_RoomCode_ReturnsRoomCodeList()
    {
        // Arrange
        var roomId = _settings.RoomId;
        // Act
        var result = await RoomCodeRestCommand.CreateAsync(roomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RoomCodeList>();
    }
}
