using System.Text;
using HundredMSRest.Lib.Core.Interfaces;

namespace HundredMSRest.Lib.Api.V2.Recordings.Filters;

/// <summary>
/// Class <c>RecordingsRequestFilter</c> recordings request filter
/// </summary>
public class RecordingRequestFilter : IRequestFilter
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
    /// Returns a query parameter filter
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
    /// Set room id property
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    public RecordingRequestFilter AddRoomId(string roomId)
    {
        _roomId = roomId;
        return this;
    }

    /// <summary>
    /// Set session id property
    /// </summary>
    /// <param name="sessionId"></param>
    /// <returns></returns>
    public RecordingRequestFilter AddSessionId(string sessionId)
    {
        _sessionId = sessionId;
        return this;
    }

    /// <summary>
    /// Sets status property
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public RecordingRequestFilter AddStatus(string status)
    {
        _status = status;
        return this;
    }

    /// <summary>
    /// Sets start property
    /// </summary>
    /// <param name="start"></param>
    /// <returns></returns>
    public RecordingRequestFilter AddStart(string start)
    {
        _start = start;
        return this;
    }

    /// <summary>
    /// Sets limit property
    /// </summary>
    /// <param name="limit"></param>
    /// <returns></returns>
    public RecordingRequestFilter AddLimit(int limit)
    {
        _limit = limit;
        return this;
    }
    #endregion
}
