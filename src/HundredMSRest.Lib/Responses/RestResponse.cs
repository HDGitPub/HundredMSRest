using System.Net;
using System.Net.Http.Headers;

namespace HundredMSRest.Lib.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class RestResponse
    {
        public HttpStatusCode StatusCode { get; }
        public string Content { get; }
        public HttpResponseHeaders Headers { get; }
        public RestResponse(HttpStatusCode statusCode, string content, HttpResponseHeaders headers = null)
        {
            StatusCode = statusCode;
            Content = content;
            Headers = headers;
        }
    }
}