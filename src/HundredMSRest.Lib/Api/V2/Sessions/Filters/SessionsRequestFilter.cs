using System.Text;
using HundredMSRest.Lib.Api.V2.Sessions.Requests;

namespace HundredMSRest.Lib.Api.V2.Sessions.Filters;

/// <summary>
/// Class <c>SessionsRequestFilter</c> Builds a new SessionsRequest filter
/// that represents a set of query parameters that can be sent to the API
/// </summary>
public class SessionsRequestFilter
{
    #region Attributes
    private readonly SessionsRequest _request;
    #endregion

    #region Methods
    /// <summary>
    /// Constructor
    /// </summary>
    public SessionsRequestFilter()
    {
        _request = new SessionsRequest();
    }

    /// <summary>
    /// Returns a new SessionsRequest filter
    /// </summary>
    /// <returns></returns>
    public string Filter()
    {
        var builder = new StringBuilder("?");
        if (_request.active is not null)
        {
            builder.Append($"active={_request.active?.ToString().ToLower()}&");
        }
        if (_request.room_id is not null)
        {
            builder.Append($"room_id={_request.room_id}&");
        }
        if (_request.before is not null)
        {
            builder.Append($"before={_request.before?.ToString("o")}&");
        }
        if (_request.after is not null)
        {
            builder.Append($"after={_request.after?.ToString("o")}&");
        }
        if (_request.limit is not null)
        {
            builder.Append($"limit={_request.limit}&");
        }
        return builder.ToString().TrimEnd('&');
    }

    /// <summary>
    /// Sets active property
    /// </summary>
    /// <param name="active"></param>
    /// <returns></returns>
    public SessionsRequestFilter AddActive(bool active)
    {
        _request.active = active;
        return this;
    }

    /// <summary>
    /// Sets active room id property
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    public SessionsRequestFilter AddRoomId(string roomId)
    {
        _request.room_id = roomId;
        return this;
    }

    /// <summary>
    /// Sets after date property. This value will be converted to utc
    /// if it is not explicitly set
    /// </summary>
    /// <param name="after"></param>
    /// <returns></returns>
    public SessionsRequestFilter AddAfter(DateTime after)
    {
        after = after.Kind != DateTimeKind.Utc ? after.ToUniversalTime() : after;
        _request.after = after;
        return this;
    }

    /// <summary>
    /// Sets before property. This value will be converted to utc
    /// if it is not explicitly set
    /// </summary>
    /// <param name="before"></param>
    /// <returns></returns>
    public SessionsRequestFilter AddBefore(DateTime before)
    {
        before = before.Kind != DateTimeKind.Utc ? before.ToUniversalTime() : before;
        _request.before = before;
        return this;
    }

    /// <summary>
    /// Sets limit property
    /// </summary>
    /// <param name="limit"></param>
    /// <returns></returns>
    public SessionsRequestFilter AddLimit(int limit)
    {
        _request.limit = limit;
        return this;
    }
    #endregion
}
