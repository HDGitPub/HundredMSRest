using System.Net.Http.Headers;

namespace HundredMSRest.Lib.Services
{
    /// <summary>
    /// Class <c>HundredMSRoomService</c> Provides Room specific functionality
    /// </summary>
    public class RoomService
    {
        private readonly HundredMSRestClient _restClient;
        public RoomService(HttpClient? httpClient = null)
        {
            _restClient = new HundredMSRestClient(httpClient);
        }

        public async void GetAsync(HundredMSRestClient client)
        {
            // set values on the request
            //HttpRequestMessage httpRequestMessage = new HttpRequestMessage(request.HttpMethod, request.Route);
            //var mt = new MediaTypeWithQualityHeaderValue("application/json");
            //httpRequestMessage.Headers.Accept.Add(mt);
            //var response = await client.GetHttpClient().SendAsync(request);

            //using (var stream = await response.Content.ReadAsStreamAsync())
            //{
            //    using (var streamReader = new StreamReader(stream))
            //    {
            //        using (var jsonTextReader = new JsonTextReader(streamReader))
            //        {
            //            var customer = new JsonSerializer().Deserialize<Customer>(jsonTextReader);

            //            // do something with the customer
            //        }
            //    }
            //}
        }


        public void PostAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "");
            var mt = new MediaTypeWithQualityHeaderValue("application/json");

            request.Headers.Accept.Add(mt);
        }
    }
}
