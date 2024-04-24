using HundredMSRest.Lib.Interfaces;

namespace HundredMSRest.Lib.Services
{
    /// <summary>
    /// 100MS Rest Client Class
    /// Provides connectivity to 100MS API V2
    /// </summary>
    public sealed class HundredMSRestClient : IHundredMSRestClient
    {
        #region Attributes
        public HttpClient HttpClient { get; }

        #endregion

        #region Methods

        public HundredMSRestClient(HttpClient? httpClient = null)
        {
            HttpClient = httpClient ?? GetHttpClient();
        }

        public HttpClient GetHttpClient()
        {
            return new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = false
            });
        }
        #endregion
    }
}
