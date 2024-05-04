using HundredMSRest.Lib.Core.Interfaces;

namespace HundredMSRest.Lib.Core.Clients;

/// <summary>
/// Class <c>RestClient</c> Main rest api client
/// Provides connectivity to 100MS API V2
/// </summary>
internal class RestClient : IRestClient
{
    #region statics
    private static readonly HttpClient _httpInternalClient;
    private static readonly Uri _baseUri;
    #endregion

    #region Attributes
    private readonly HttpClient? _httpExternalClient;
    #endregion

    /// <summary>
    /// Creates a long lived HttpClient that uses a connection pool
    /// and can honor DNS changes
    /// <see cref="https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient-guidelines"/>
    /// </summary>
    /// <returns></returns>
    static RestClient()
    {
        _baseUri = new Uri("https://api.100ms.live");

        var socketHandler = new SocketsHttpHandler()
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(5)
        };

        _httpInternalClient = new(socketHandler) { BaseAddress = _baseUri };
    }

    #region Methods

    /// <summary>
    /// Constructor allows client to optionally pass in pre-configured HttpClient
    /// </summary>
    /// <param name="httpClient"></param>
    public RestClient(HttpClient? httpClient = null)
    {
        _httpExternalClient = httpClient;
        if (_httpExternalClient is not null)
        {
            _httpExternalClient.BaseAddress = _baseUri;
        }
    }

    /// <summary>
    /// Retrieves an instance of the current HttpClient
    /// </summary>
    /// <returns>HttpClient</returns>
    public HttpClient GetHttpClient()
    {
        return _httpExternalClient ?? _httpInternalClient;
    }

    #endregion
}
