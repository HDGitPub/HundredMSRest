using HundredMSRest.Lib.Interfaces;
using HundredMSRest.Lib.Records;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HundredMSRest.Lib.Requests
{
    /// <summary>
    /// Class <c>RoomRestRequest</c> Room specific API request
    /// </summary>
    internal class RoomRestRequest<T,R> : IRestRequest<T,R>
    {
        #region Attributes

        public string baseRoute = "https://api.100ms.live/v2/rooms";
        private readonly IRestClient _restClient;
        private readonly T? _t;
        private readonly HttpMethod _httpMethod;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public RoomRestRequest(T t, HttpMethod httpMethod, IRestClient restClient)
        {
            _t = t;
            _restClient = restClient;
            _httpMethod = httpMethod;
        }

        #region Methods

        public StringContent GetData(T t)
        {
            return new StringContent(t.ToString());
        }

        public async Task<R> RequestAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(_httpMethod, "https://api.100ms.live/v2/rooms");

            StringContent testContent = GetData(_t);
            R r = JsonSerializer.Deserialize<R>("{\"name\": \"new-room-1662723668\",\"description\" : \"test\"}");
            return r;
            //request.Headers.Add("Authorization", "Bearer <management_token>");
            //request.Content = new StringContent("{\"name\": \"new-room-1662723668\",\"description\": \"{roomDescription}\",\"template_id\": \"123456\"}");
            //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //HttpResponseMessage response = await _restClient.GetHttpClient().SendAsync(request);
            //response.EnsureSuccessStatusCode();

            //string responseBody = await response.Content.ReadAsStringAsync();
            //using (var stream = await response.Content.ReadAsStreamAsync())
            //{
            //    using (var streamReader = new StreamReader(stream))
            //    {
            //        using (var jsonTextReader = JsonTextReader(streamReader))
            //        {
            //            var customer = JsonSerializer.Deserialize<R>(jsonTextReader);

            //            // do something with the customer
            //            return customer;
            //        }
            //    }
            //}
        }

        #endregion
    }
}