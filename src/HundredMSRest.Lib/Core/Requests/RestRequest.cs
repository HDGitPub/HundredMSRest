using System.Net.Http.Headers;
using System.Text.Json;
using HundredMSRest.Lib.Core.Interfaces;

namespace HundredMSRest.Lib.Core.Requests;

/// <summary>
/// Class <c>RestRequest</c> Base 100MS Api request class
/// </summary>
/// <param name="token"></param>
/// <param name="httpMethod"></param>
/// <param name="url"></param>
/// <param name="restClient"></param>
public class RestRequest(string token, HttpMethod httpMethod, string url, IRestClient restClient)
    : IRestRequest
{
    #region Attributes
    private readonly HttpMethod _httpMethod = httpMethod;
    private readonly string _url = url;
    private readonly IRestClient _restClient = restClient;
    private readonly string _bearerToken = $"Bearer {token}";
    private const string AUTH_HEADER = "Authorization";
    #endregion

    #region Methods

    /// <summary>
    /// Executes a rest request against the 100MS Api
    /// </summary>
    /// <typeparam name="R">Return record type</typeparam>
    /// <param name="requestData">Request record data</param>
    /// <returns>Type R</returns>
    public async Task<R?> ExecuteAsync<R>(
        string? requestData,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequestMessage request = new(_httpMethod, _url);
        request.Headers.Add(AUTH_HEADER, _bearerToken);
        if (requestData is not null)
        {
            request.Content = new StringContent(requestData);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        using HttpResponseMessage response = await _restClient
            .GetHttpClient()
            .SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync(cancellationToken);
        R? result = JsonSerializer.Deserialize<R>(jsonResponse);

        return result;
    }

    #endregion
}
