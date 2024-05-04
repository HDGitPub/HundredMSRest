using FluentAssertions;
using HundredMSRest.Lib.Api.V2.Rooms.Commands;
using HundredMSRest.Lib.Api.V2.Rooms.DataTypes;
using HundredMSRest.Lib.Api.V2.Rooms.Requests;
using HundredMSRest.Lib.Api.V2.Rooms.Responses;
using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Rooms;

/// <summary>
/// Class <c>RoomTestCommandTests</c> Tests RoomRestComands against the 100MS rest api
/// </summary>
public class RoomRestCommandTests : AuthenticatedTests
{
    [Fact]
    public async void Create_Room_ReturnsRoom()
    {
        // Arrange
        string testTime = DateTime.Now.ToString("hh-mm-ss");
        string testName = $"test-room-{testTime}";
        string testDescription = "test room";

        // Act
        var result = await RoomRestCommand.CreateRoomAsync(testName, testDescription, TemplateId);

        // Assert
        Room r = new Room()
        {
            name = testTime,
            description = testDescription,
            template_id = TemplateId
        };

        result.Should().NotBeNull();
        result.Should().BeOfType<Room>();
        result.Should().BeEquivalentTo(r);
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
        string roomId = "663427e4f1f141ce73bc75ab";

        // Act
        var result = await RoomRestCommand.GetRoomAsync(roomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Room>();
    }

    [Fact]
    public async void Update_Room_ReturnsRoom()
    {
        // Arrange
        string testRoomId = "663427e4f1f141ce73bc75ab";

        //var room = new RoomUpdateBuilder()
        //              .UpdateName("").
        //              .UpdateDescription("")
        //              .UpdateRecordingInfo(true) // Add to enable recording
        //              .AddUploadInfo("location","type","prefix") // Add to store recordings off platform
        //              .AddCredentials("","") // storage access credentials

        var updateRoom = new UpdateRoomRequest()
        {
            name = "test name",
            description = "updated description",
            recording_info = new RecordingInfo()
            {
                enabled = false,
                upload_info = new UploadInfo("", "") { Credentials = new Credentials("", "") }
            }
        };

        // Act
        var result = await RoomRestCommand.UpdateRoomAsync(testRoomId, updateRoom);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Room>();
    }
}
