namespace HundredMSRest.Lib.Requests
{
    /// <summary>
    /// Class <c>HundredMSRestRoomRequest</c> Room specific API request
    /// </summary>
    public class HundredMSRestRoomRequest : HundredMSRequest
    {
        public HundredMSRestRoomRequest()
        {
            _route = "api/room";
        }
    }
}