using System.Text;
using HundredMSRest.Lib.Core.Interfaces;

namespace HundredMSRest.Lib.Api.V2.Sessions.Filters;

/// <summary>
/// Class <c>SessionsRequestFilter</c> Builds a new SessionsRequest filter
/// that represents a set of query parameters that can be sent to the API
/// </summary>
public class SessionsRequestFilter : IRequestFilter
{
    #region Attributes
    public bool? _active;

    /// <summary>
    /// etch the list of sessions created in the room specified.
    /// </summary>
    public string? _room_id;

    /// <summary>
    /// Check for sessions started with a timestamp greater than or equal to "after"
    /// </summary>
    public DateTime? _after;

    /// <summary>
    /// Check for sessions started with a timestamp less than or equal to "after"
    /// </summary>
    public DateTime? _before;

    /// <summary>
    /// Determines the number of session objects to be included in response.
    /// Allowed values: Min: 10, Max: 100
    /// </summary>
    public int? _limit;
    #endregion

    #region Methods

    /// <summary>
    /// Returns a new SessionsRequest filter
    /// </summary>
    /// <returns></returns>
    public string Filter()
    {
        var builder = new StringBuilder("?");
        if (_active is not null)
        {
            builder.Append($"active={_active?.ToString().ToLower()}&");
        }
        if (_room_id is not null)
        {
            builder.Append($"room_id={_room_id}&");
        }
        if (_before is not null)
        {
            builder.Append($"before={_before?.ToString("o")}&");
        }
        if (_after is not null)
        {
            builder.Append($"after={_after?.ToString("o")}&");
        }
        if (_limit is not null)
        {
            builder.Append($"limit={_limit}&");
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
        _active = active;
        return this;
    }

    /// <summary>
    /// Sets active room id property
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    public SessionsRequestFilter AddRoomId(string roomId)
    {
        _room_id = roomId;
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
        _after = after;
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
        _before = before;
        return this;
    }

    /// <summary>
    /// Sets limit property
    /// </summary>
    /// <param name="limit"></param>
    /// <returns></returns>
    public SessionsRequestFilter AddLimit(int limit)
    {
        _limit = limit;
        return this;
    }
    #endregion
}
