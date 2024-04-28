using HundredMSRest.Lib.Records;
using HundredMSRest.Lib.Requests;

namespace HundredMSRest.Tests
{
    public class RoomServiceTests
    {
        [Fact]
        public async void Test_RoomService_Connect()
        {
            bool result = true;
            //RoomService roomService = new RoomService();
            Room srs = await RoomRestCommand.CreateRoomAsync("name", "description");
            //Room r = await roomService.ExecuteAsync(RoomRestCommand.CreateRoom("name","description"));
            Assert.False(result);
        }
    }
}
