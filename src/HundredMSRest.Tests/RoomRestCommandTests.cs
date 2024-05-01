using HundredMSRest.Lib.Api.Rooms.Commands;
using HundredMSRest.Lib.Api.Rooms.DataTypes;

namespace HundredMSRest.Tests;

/// <summary>
/// Class <c>RoomTestCommandTests</c> Tests RoomRestComands against the 100MS rest api
/// </summary>
public class RoomRestCommandTests : AuthenticatedTests
{
    [Fact]
    public async void Create_Room_ReturnsRoom()
    {
        Room room = await RoomRestCommand.CreateRoomAsync("name", "description");
        Assert.NotNull(room);
    }

    [Fact]
    public async void List_Rooms_ReturnsRooms()
    {
        List<Room> rooms = await RoomRestCommand.ListRoomsAsync();
        Assert.NotNull(rooms);
    }
}
