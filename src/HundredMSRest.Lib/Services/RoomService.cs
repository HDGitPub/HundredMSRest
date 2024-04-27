using HundredMSRest.Lib.Interfaces;
using HundredMSRest.Lib.Records;
using HundredMSRest.Lib.Requests;
using System.Net.Http.Headers;

namespace HundredMSRest.Lib.Services
{
    /// <summary>
    /// Class <c>RoomService</c> Provides Room specific functionality
    /// </summary>
    public class RoomService
    {
        private readonly RestClient _restClient;
        
        public RoomService(HttpClient? httpClient = null)
        {
            _restClient = new RestClient(httpClient);
        }

        private IRestRequest<IRestRequestData, IRestResponseData> GetRequest(RoomRestCommand restCommand)
        {
            return restCommand.Id switch
            {
                RoomRestCommand.Commands.CreateRoom => new RoomRestRequest<IRestRequestData, IRestResponseData>(restCommand.Data, restCommand.HttpMethod, _restClient),
                _ => throw new NotImplementedException()
            };
        }

        public Task<IRestResponseData> ExecuteAsync(RoomRestCommand restCommand)
        {
            return GetRequest(restCommand).RequestAsync();
        }
    }
}
