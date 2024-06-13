namespace HundredMSRest.Lib.Core.Interfaces;

/// <summary>
/// Interface <c>IRestRequest</c>
/// </summary>
internal interface IRestRequest
{
    Task<R> ExecuteAsync<R>(string? requestData, CancellationToken cancellationToken = default);
}
