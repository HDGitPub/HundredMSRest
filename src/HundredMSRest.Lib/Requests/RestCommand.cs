namespace HundredMSRest.Lib.Requests;

using HundredMSRest.Lib.Records;
using System.Text.Json;

/// <summary>
/// Represents rest commands that are sent to the 100 MS Api
/// </summary>
public class RestCommand
{
    #region Attributes

    protected readonly HttpMethod _httpMethod;
    protected string _baseUrl;

    #endregion

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data">Request data to pass to the 100MS Api</param>
    public RestCommand(HttpMethod httpMethod)
    {
        _httpMethod = httpMethod;
        _baseUrl = "https://api.100ms.live/v2";
    }

    public HttpMethod HttpMethod
    {
        get
        {
            return _httpMethod;
        }
    }

    public async Task<R> RequestAsync<R>()
    {
        HttpRequestMessage request = new HttpRequestMessage(_httpMethod, "https://api.100ms.live/v2/rooms");
        R r = JsonSerializer.Deserialize<R>("{\"name\": \"new-room-1662723668\",\"description\" : \"test\"}");
        return r;
    }

    public async Task<R> RequestAsync<R>(string customUrl)
    {
        HttpRequestMessage request = new HttpRequestMessage(_httpMethod, $"{_baseUrl}{customUrl}");
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

    public async Task<R> RequestAsync<R>(RequestRecord data)
    {
        HttpRequestMessage request = new HttpRequestMessage(_httpMethod, _baseUrl);

        StringContent testContent = new StringContent(data.ToString());
        R r = JsonSerializer.Deserialize<R>("{\"name\": \"new-room-1662723668\",\"description\" : \"test\"}");
        return r;
    }

    #endregion
}
