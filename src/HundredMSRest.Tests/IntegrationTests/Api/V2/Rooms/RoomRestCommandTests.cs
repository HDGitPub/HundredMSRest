using FluentAssertions;
using HundredMSRest.Lib.Api.V2.Rooms.Builders;
using HundredMSRest.Lib.Api.V2.Rooms.Commands;
using HundredMSRest.Lib.Api.V2.Rooms.DataTypes;
using HundredMSRest.Lib.Api.V2.Rooms.Responses;
using HundredMSRest.Lib.Core.Common;
using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Rooms;

/// <summary>
/// Class <c>RoomTestCommandTests</c> Tests RoomRestComands against the 100MS rest api
/// </summary>
public class RoomRestCommandTests : AuthenticatedTests
{
    private string TestRoomName { get; init; }
    private string TestRoomDesc { get; init; }

    public RoomRestCommandTests()
    {
        TestRoomName = $"test-room-{DateTime.Now:hh-mm-ss}";
        TestRoomDesc = $"test-room-desc-{DateTime.Now:hh-mm-ss}";
    }

    [Fact]
    public async void Create_Room_ReturnsRoom()
    {
        // Arrange

        // Act
        var result = await RoomRestCommand.CreateRoomAsync(TestRoomName, TestRoomDesc, TemplateId);

        // Assert
        var expected = new
        {
            name = TestRoomName,
            description = TestRoomDesc,
            template_id = TemplateId
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
        var result = await RoomRestCommand.GetRoomAsync(RoomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Room>();
    }

    [Fact]
    public async void Update_Room_ReturnsRoom()
    {
        // Arrange
        var updateRoomRequest = new UpdateRoomRequestBuilder()
            .AddName(TestRoomName)
            .AddDescription(TestRoomDesc)
            .AddRecordingInfo()
            .AddUploadInfo(StorageType.S3, Bucket, region: Region.Aws.US_EAST_1)
            .AddCredentials(BucketAccessKey, BucketSecretKey)
            .Build();

        // Act
        var result = await RoomRestCommand.UpdateRoomAsync(RoomId, updateRoomRequest);

        var expected = new { name = TestRoomName, description = TestRoomDesc };

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Room>();
        result.Should().BeEquivalentTo(expected);
    }
}
