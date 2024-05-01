namespace HundredMSRest.Lib.Core.Interfaces;

/// <summary>
/// Interface <c>IRestClient</c>
/// </summary>
internal interface IRestClient
{
    HttpClient? HttpClient { get; }
}
