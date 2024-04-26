using HundredMSRest.Lib.Services;

namespace HundredMSRest.Tests
{
    public class RoomServiceTests
    {
        [Fact]
        public void Test_RoomService_Connect()
        {
            bool result = true;
            RoomService roomService = new RoomService();

            Assert.False(result);
        }
    }
}
