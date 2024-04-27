using HundredMSRest.Lib.Requests;
using HundredMSRest.Lib.Services;

namespace HundredMSRest.Tests
{
    public class RoomServiceTests
    {
        [Fact]
        public async void Test_RoomService_Connect()
        {
            bool result = true;

            RoomService roomService = new RoomService();
            await roomService.ExecuteAsync(RoomRestCommand.CreateRoom("name","description"));

            Assert.False(result);
        }
    }
}
