namespace HundredMSRest.Lib.Interfaces;

/// <summary>
/// Interface <c>IRestClient</c>
/// </summary>
internal interface IRestClient
{
    HttpClient? GetHttpClient();
}
