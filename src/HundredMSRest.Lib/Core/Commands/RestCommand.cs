using HundredMSRest.Lib.Core.Clients;
using HundredMSRest.Lib.Core.Enums;
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

    protected string _baseUrl;

    #endregion

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data">Request data to pass to the 100MS Api</param>
    public RestCommand()
    {
        _baseUrl = string.Empty;
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
    public async Task<R?> RequestAsync<R>(HttpMethod httpMethod, HttpClient? httpClient = null, string? url = null, RequestRecord? requestRecord = null, CancellationToken cancellationToken = default)
    {
        ApiToken apiToken = new TokenService().GetToken(TokenType.Management);
        RestRequest request = new(apiToken.Token,
                                  httpMethod,
                                  url ?? BaseUrl,
                                  new RestClient(httpClient));

        string? requestData = requestRecord?.GetJSON() ?? null;
        return await request.ExecuteAsync<R>(requestData, cancellationToken);
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
