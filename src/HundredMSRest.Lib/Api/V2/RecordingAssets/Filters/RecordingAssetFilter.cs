using HundredMSRest.Lib.Core.Interfaces;
using System.Text;

namespace HundredMSRest.Lib.Api.V2.RecordingAssets.Filters;

/// <summary>
/// Class <c>RecordingAssetFilter</c> returns query param filter for retrieving recording assets
/// </summary>
public sealed class RecordingAssetFilter : IRequestFilter
{
    #region Attributes
    private string? _roomId;
    private string? _sessionId;
    private string? _status;
    private string? _start;
    private int? _limit;
    #endregion

    #region Methods

    /// <summary>
    /// Returns a query parameter filter string
    /// </summary>
    /// <returns></returns>
    public string Filter()
    {
        var builder = new StringBuilder("?");
        if (_roomId is not null)
        {
            builder.Append($"room_id={_roomId}&");
        }
        if (_sessionId is not null)
        {
            builder.Append($"session_id={_sessionId}&");
        }
        if (_status is not null)
        {
            builder.Append($"status={_status}&");
        }
        if (_start is not null)
        {
            builder.Append($"start={_start}&");
        }
        if (_limit is not null)
        {
            builder.Append($"limit={_limit}&");
        }
        return builder.ToString().TrimEnd('&');
    }

    /// <summary>
    /// Sets the room id filter
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    public RecordingAssetFilter AddRoomId(string roomId)
    {
        _roomId = roomId;
        return this;
    }

    /// <summary>
    /// Sets the session id filter
    /// </summary>
    /// <param name="sessionId"></param>
    /// <returns></returns>
    public RecordingAssetFilter AddSessionId(string sessionId)
    {
        _sessionId = sessionId;
        return this;
    }

    /// <summary>
    /// Sets the status filter
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public RecordingAssetFilter AddStatus(string status)
    {
        _status = status;
        return this;
    }

    /// <summary>
    /// Sets the start filter
    /// </summary>
    /// <param name="start"></param>
    /// <returns></returns>
    public RecordingAssetFilter AddStart(string start)
    {
        _start = start;
        return this;
    }

    /// <summary>
    /// Sets the limit filter
    /// </summary>
    /// <param name="limit"></param>
    /// <returns></returns>
    public RecordingAssetFilter AddLimit(int limit)
    {
        _limit = limit;
        return this;
    }

    #endregion
}
