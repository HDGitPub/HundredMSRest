using System.Text;
using HundredMSRest.Lib.Core.Interfaces;

namespace HundredMSRest.Lib.Api.V2.Rooms.Filters;

/// <summary>
/// Class <c>RoomsRequestFilter</c> filter for rooms list request
/// </summary>
public sealed class RoomsRequestFilter : IRequestFilter
{
    #region Attributes
    private bool? _enabled;
    private string? _name;
    private string? _templateId;
    private DateTime? _start;
    private DateTime? _after;
    private DateTime? _before;
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
        if (_name is not null)
        {
            builder.Append($"name={_name}&");
        }
        if (_templateId is not null)
        {
            builder.Append($"template_id={_templateId}&");
        }
        if (_enabled is not null)
        {
            builder.Append($"enabled={_enabled?.ToString().ToLower()}&");
        }
        if (_start is not null)
        {
            builder.Append($"start={_start?.ToString("o")}&");
        }
        if (_after is not null)
        {
            builder.Append($"after={_after?.ToString("o")}&");
        }
        if (_before is not null)
        {
            builder.Append($"before={_before?.ToString("o")}&");
        }
        if (_limit is not null)
        {
            builder.Append($"limit={_limit}&");
        }
        return builder.ToString().TrimEnd('&');
    }

    /// <summary>
    /// Sets the enabled filter
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public RoomsRequestFilter AddEnabled(bool enabled)
    {
        _enabled = enabled;
        return this;
    }

    /// <summary>
    /// Sets the name filter
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public RoomsRequestFilter AddName(string name)
    {
        _name = name;
        return this;
    }

    /// <summary>
    /// Sets the template id filter
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    public RoomsRequestFilter AddTemplateId(string templateId)
    {
        _templateId = templateId;
        return this;
    }

    /// <summary>
    /// Sets the start filter
    /// </summary>
    /// <param name="start"></param>
    /// <returns></returns>
    public RoomsRequestFilter AddStart(DateTime start)
    {
        start = start.Kind != DateTimeKind.Utc ? start.ToUniversalTime() : start;
        _start = start;
        return this;
    }

    /// <summary>
    /// Sets the after filter
    /// </summary>
    /// <param name="after"></param>
    /// <returns></returns>
    public RoomsRequestFilter AddAfter(DateTime after)
    {
        after = after.Kind != DateTimeKind.Utc ? after.ToUniversalTime() : after;
        _after = after;
        return this;
    }

    /// <summary>
    /// Sets the before filter
    /// </summary>
    /// <param name="before"></param>
    /// <returns></returns>
    public RoomsRequestFilter AddBefore(DateTime before)
    {
        before = before.Kind != DateTimeKind.Utc ? before.ToUniversalTime() : before;
        _before = before;
        return this;
    }

    /// <summary>
    /// Sets the limit filter
    /// </summary>
    /// <param name="limit"></param>
    /// <returns></returns>
    public RoomsRequestFilter AddLimit(int limit)
    {
        _limit = limit;
        return this;
    }

    #endregion
}
