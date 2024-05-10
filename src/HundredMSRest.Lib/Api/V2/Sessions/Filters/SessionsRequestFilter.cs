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
    /// Returns a new SessionsRequest
    /// </summary>
    /// <returns></returns>
    public string Filter()
    {
        return _request.ToString();
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
    /// Sets after property
    /// </summary>
    /// <param name="after"></param>
    /// <returns></returns>
    public SessionsRequestFilter AddAfter(string after)
    {
        _request.after = after;
        return this;
    }

    /// <summary>
    /// Sets before property
    /// </summary>
    /// <param name="before"></param>
    /// <returns></returns>
    public SessionsRequestFilter AddBefore(string before)
    {
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
