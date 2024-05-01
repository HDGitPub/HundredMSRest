namespace HundredMSRest.Lib.Core.Interfaces;

/// <summary>
/// Interface <c>IRestRequest</c>
/// </summary>
internal interface IRestRequest<T, R>
{
    StringContent GetData(T t);
    Task<R> RequestAsync();
}
