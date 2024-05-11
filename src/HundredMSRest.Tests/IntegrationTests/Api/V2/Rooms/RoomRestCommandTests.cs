using FluentAssertions;
using HundredMSRest.Lib.Api.V2.Rooms.Builders;
using HundredMSRest.Lib.Api.V2.Rooms.Commands;
using HundredMSRest.Lib.Api.V2.Rooms.DataTypes;
using HundredMSRest.Lib.Api.V2.Rooms.Requests;
using HundredMSRest.Lib.Api.V2.Rooms.Responses;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Rooms;

/// <summary>
/// Class <c>RoomTestCommandTests</c> Tests RoomRestComands against the 100MS rest api
/// </summary>
public class RoomRestCommandTests
{
    private readonly RoomTestSettings _settings;

    public RoomRestCommandTests()
    {
        _settings = new RoomTestSettings();
    }

    [Fact]
    public async void Create_Room_ReturnsRoom()
    {
        // Arrange

        // Act
        var result = await RoomRestCommand.CreateRoomAsync(
            _settings.RoomName,
            _settings.RoomDescription,
            _settings.TemplateId
        );

        // Assert
        var expected = new
        {
            name = _settings.RoomName,
            description = _settings.RoomDescription,
            template_id = _settings.TemplateId
        };

        result.Should().BeOfType<Room>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void List_Rooms_ReturnsRooms()
    {
        // Arrange

        // Act
        var result = await RoomRestCommand.ListRoomsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RoomList>();
    }

    [Fact]
    public async void Get_Room_ReturnsRoom()
    {
        // Arrange

        // Act
        var result = await RoomRestCommand.GetRoomAsync(_settings.RoomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Room>();
    }

    [Fact]
    public async void Update_Room_ReturnsRoom()
    {
        // Arrange
        var updateRoomRequest = new UpdateRoomRequestBuilder()
            .AddName(_settings.RoomName)
            .AddDescription(_settings.RoomDescription)
            .AddRecordingInfo()
            .AddUploadInfo(StorageType.S3, _settings.Bucket, region: Region.Aws.US_EAST_1)
            .AddCredentials(_settings.BucketAccessKey, _settings.BucketSecretKey)
            .Build();

        // Act
        var result = await RoomRestCommand.UpdateRoomAsync(_settings.RoomId, updateRoomRequest);

        var expected = new { name = _settings.RoomName, description = _settings.RoomDescription };

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Room>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void EnableDisable_Room_ReturnsRoom()
    {
        // Arrange
        var enableDisableRoomRequest = new EnableDisableRoomRequest() { enabled = true };

        // Act
        var result = await RoomRestCommand.EnableDisableRoomAsync(
            _settings.RoomId,
            enableDisableRoomRequest
        );

        var expected = new { enabled = true };

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Room>();
        result.Should().BeEquivalentTo(expected);
    }
}
