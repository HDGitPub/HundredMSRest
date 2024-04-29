namespace HundredMSRest.Lib.Services;

using HundredMSRest.Lib.Interfaces;

/// <summary>
/// Class <c>RestClient</c> Main rest api client
/// Provides connectivity to 100MS API V2
/// </summary>
public class RestClient : IRestClient
{
    #region Attributes

    private static HttpClient _httpClient;
    private static SocketsHttpHandler? _socketHandler;

    #endregion

    #region Methods

    /// <summary>
    /// Constructor allows client to optionally pass in pre-configured HttpClient
    /// </summary>
    /// <param name="httpClient"></param>
    public RestClient(HttpClient? httpClient = null)
    {
        if (httpClient is not null)
        {
            _httpClient = httpClient;
        }
        else if (_httpClient is null)
        {
            InitHttpClient();
        }
        _httpClient.BaseAddress = new Uri("https://api.100ms.live");
    }

    /// <summary>
    /// Creates a long lived HttpClient that uses a connection pool 
    /// and can honor DNS changes
    /// <see cref="https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient-guidelines"/>
    /// </summary>
    /// <returns></returns>
    public static void InitHttpClient()
    {
        _socketHandler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(5)
        };

        _httpClient = new HttpClient(_socketHandler);
    }

    /// <summary>
    /// Retrieves an instance of the current HttpClient
    /// </summary>
    /// <returns>HttpClient</returns>
    public HttpClient HttpClient => _httpClient;

    #endregion
}
