using HundredMSRest.Lib.Api.V2.Analytics.DataTypes;
using System.Text;

namespace HundredMSRest.Lib.Api.V2.Analytics.Filters;

/// <summary>
/// Class <c>EventFilter</c>
/// </summary>
public sealed class EventFilter
{
    #region Attributes
    private readonly string _roomId;
    private readonly List<string> _types;
    private string? _sessionId { get; set; }
    private string? _peerId { get; set; }
    private string? _userId { get; set; }
    private string? _beamId { get; set; }
    private bool? _error { get; set; }
    private string? _start { get; set; }
    private int? _limit { get; set; }
    #endregion

    #region Methods

    public EventFilter(string roomId)
    {
        _roomId = roomId;
        _types = new List<string>();
    }

    public string Filter()
    {
        var builder = new StringBuilder("?");
        builder.Append($"room_id={_roomId}&");
        
        if (_types.Count > 0)
        {
            _types.ForEach(t => builder.Append($"type={t}&"));
        }
        if (_sessionId is not null)
        {
            builder.Append($"session_id={_sessionId}&");
        }
        if (_peerId is not null)
        {
            builder.Append($"peer_id={_peerId}&");
        }
        if (_userId is not null)
        {
            builder.Append($"user_id={_userId}&");
        }
        if (_beamId is not null)
        {
            builder.Append($"beam_id={_beamId}&");
        }
        if (_error is not null)
        {
            builder.Append($"error={_error?.ToString().ToLower()}&");
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

    public EventFilter AddType(EventType eventType)
    {
        _types.Add(eventType.ToString());
        return this;
    }

    public EventFilter AddSessionId(string sessionId)
    {
        _sessionId = sessionId;
        return this;
    }

    public EventFilter AddPeerId(string peerId)
    {
        _peerId = peerId;
        return this;
    }

    public EventFilter AddUserId(string userId)
    {
        _userId = userId;
        return this;
    }

    public EventFilter AddBeamId(string beamId)
    {
        _beamId = beamId;
        return this;
    }

    public EventFilter AddError(bool error)
    {
        _error = error;
        return this;
    }

    public EventFilter AddStart(string start)
    {
        _start = start;
        return this;
    }

    public EventFilter AddLimit(int limit)
    {
        _limit = limit;
        return this;
    }

    #endregion
}
