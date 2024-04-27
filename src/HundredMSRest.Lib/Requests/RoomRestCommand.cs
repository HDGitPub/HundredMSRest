using HundredMSRest.Lib.Records;

namespace HundredMSRest.Lib.Requests
{
    /// <summary>
    /// Class <c>RoomRestCommand</c> 100MS Room specific rest commands
    /// </summary>
    public sealed class RoomRestCommand : RestCommand
    {
        private Commands id;
        #region Attributes
        public enum Commands
        {
            CreateRoom,
            GetRoomById,
            ListRooms
        }
        #endregion

        #region Methods

        /// <summary>
        /// Constructor takes RequestData and HttpMethod
        /// </summary>
        /// <param name="command"></param>
        /// <param name="data"></param>
        public RoomRestCommand(Commands command, IRestRequestData data,HttpMethod httpMethod) : base(data, httpMethod)
        {
            Id = command;
        }

        /// <summary>
        /// Constructor takes HttpMethod
        /// </summary>
        /// <param name="command"></param>
        /// <param name="httpMethod"></param>
        public RoomRestCommand(Commands command, HttpMethod httpMethod) : base(null, httpMethod)
        {
            Id = command;
        }

        /// <summary>
        /// Creates a new 100 MS room
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns>RoomRestCommand</returns>
        public static RoomRestCommand CreateRoom(string name,string description)
        {
            return new RoomRestCommand(Commands.CreateRoom,new CreateRoomRecord(name, description,""),HttpMethod.Post);
        }

        public static RoomRestCommand ListRooms()
        {
            return new RoomRestCommand(Commands.ListRooms, HttpMethod.Get);
        }

        #endregion

        #region Properties

        public Commands Id
        {
            get => id; 
            init => id = value;
        }

        #endregion
    }
}
