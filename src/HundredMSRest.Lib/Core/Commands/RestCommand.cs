using HundredMSRest.Lib.Core.Clients;
using HundredMSRest.Lib.Core.Interfaces;
using HundredMSRest.Lib.Core.Requests;
using HundredMSRest.Lib.Core.Services;
using HundredMSRest.Lib.Core.Tokens;

namespace HundredMSRest.Lib.Core.Commands;

/// <summary>
/// Class <c>RestCommand</c> is the base clas for rest commands
/// that are sent to the 100 MS Api
/// </summary>
public class RestCommand
{
    #region Attributes

    protected string _baseUrl = string.Empty;

    #endregion

    #region Methods

    /// <summary>
    /// Constructs a base route for the command
    /// </summary>
    /// <param name="baseRoute"></param>
    /// <param name="urlParams"></param>
    /// <param name="filterParams"></param>
    protected void BuildBaseRoute(
        string baseRoute,
        string? urlParams = null,
        string? filterParams = null
    )
    {
        _baseUrl = urlParams is not null ? $"{baseRoute}/{urlParams}" : baseRoute;
        if (urlParams is not null)
            return;

        _baseUrl = filterParams is not null ? $"{baseRoute}{filterParams}" : baseRoute;
    }

    /// <summary>
    /// Requests data from the 100MS api
    /// </summary>
    /// <typeparam name="R">Record data type</typeparam>
    /// <param name="token">Management Api Token</param>
    /// <param name="httpMethod">Http Method</param>
    /// <param name="url">Custom Endpoint Url</param>
    /// <param name="requestRecord">Record data</param>
    /// <param name="httpClient">Client provided HttpClient</param>
    /// <returns>Type R</returns>
    public async Task<R> RequestAsync<R>(
        HttpMethod httpMethod,
        HttpClient? httpClient = null,
        string? url = null,
        IRequestRecord? requestRecord = null,
        CancellationToken cancellationToken = default
    )
    {
        Token apiToken = new TokenService().GetManagementToken();
        var request = new RestRequest(
            apiToken.Value,
            httpMethod,
            url ?? BaseUrl,
            new RestClient(httpClient)
        );

        string? requestData = requestRecord?.GetJSON() ?? null;
        return await request.ExecuteAsync<R>(requestData, cancellationToken);
    }

    public async Task RequestAsync(
        HttpMethod httpMethod,
        HttpClient? httpClient = null,
        string? url = null,
        IRequestRecord? requestRecord = null,
        CancellationToken cancellationToken = default
    )
    {
        Token apiToken = new TokenService().GetManagementToken();
        var request = new RestRequest(
            apiToken.Value,
            httpMethod,
            url ?? BaseUrl,
            new RestClient(httpClient)
        );

        string? requestData = requestRecord?.GetJSON() ?? null;
        await request.ExecuteAsync(requestData, cancellationToken);
    }
    #endregion

    #region

    protected string BaseUrl
    {
        get => _baseUrl;
        set => _baseUrl = value;
    }

    #endregion
}
