using System.Text;

namespace HundredMSRest.Lib.Api.V2.LiveStreams.Filters;

/// <summary>
/// Class <c>LiveStreamFilter</c>
/// </summary>
public sealed class LiveStreamFilter
{
    #region Attributes
    private string? _roomId { get; set; }
    private string? _sessionId { get; set; }
    private string? _status { get; set; }
    private int? _start { get; set; }
    private int? _limit { get; set; }
    #endregion

    #region Methods
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

    public LiveStreamFilter AddStart(int start)
    {
        _start = start;
        return this;
    }

    public LiveStreamFilter AddLimit(int limit)
    {
        _limit = limit;
        return this;
    }

    public LiveStreamFilter AddRoomId(string roomId)
    {
        _roomId = roomId;
        return this;
    }

    public LiveStreamFilter AddSessionId(string sessionId)
    {
        _sessionId = sessionId;
        return this;
    }

    public LiveStreamFilter AddStatus(string status)
    {
        _status = status;
        return this;
    }

    #endregion
}
