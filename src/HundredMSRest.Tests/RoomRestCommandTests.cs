using HundredMSRest.Lib.Api.Rooms.Commands;
using HundredMSRest.Lib.Api.Rooms.DataTypes;
using HundredMSRest.Lib.Api.Rooms.Requests;
using HundredMSRest.Lib.Api.Rooms.Responses;

namespace HundredMSRest.Tests;

/// <summary>
/// Class <c>RoomTestCommandTests</c> Tests RoomRestComands against the 100MS rest api
/// </summary>
public class RoomRestCommandTests : AuthenticatedTests
{
    [Fact]
    public async void Create_Room_ReturnsRoom()
    {
        Room? room = await RoomRestCommand.CreateRoomAsync("name", "description", "");
        Assert.NotNull(room);
    }

    [Fact]
    public async void List_Rooms_ReturnsRooms()
    {
        RoomList? rooms = await RoomRestCommand.ListRoomsAsync();
        Assert.NotNull(rooms);
    }

    [Fact]
    public async void Get_Room_ReturnsRoom()
    {
        Room? room = await RoomRestCommand.GetRoomAsync("test-room");
        Assert.NotNull(room);
    }

    [Fact]
    public async void Update_Room_ReturnsRoom()
    {
        string testRoomId = "";
        var updateRoom = new UpdateRoomRequest()
        {
            name = "test name",
            description = "test description"
        };

        Room? room = await RoomRestCommand.UpdateRoomAsync(testRoomId,updateRoom);
        Assert.NotNull(room);
    }
}
