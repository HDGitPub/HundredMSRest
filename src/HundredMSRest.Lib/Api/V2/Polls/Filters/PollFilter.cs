using HundredMSRest.Lib.Core.Interfaces;
using System.Text;

namespace HundredMSRest.Lib.Api.V2.Polls.Filters;

/// <summary>
/// Class <c>PollFilter</c>
/// </summary>
public sealed class PollFilter : IRequestFilter
{
    #region Attributes
    private string? _start { get; set; }
    private int? _limit { get; set; }
    private Boolean? _all { get; set; }
    private int? _question  {get; set; }
    #endregion

    #region Methods
    public string Filter()
    {
        var builder = new StringBuilder("?");
        if (_start is not null)
        {
            builder.Append($"start={_start}&");
        }
        if (_limit is not null)
        {
            builder.Append($"limit={_limit}&");
        }
        if (_all is not null)
        {
            builder.Append($"all={_all?.ToString().ToLower()}&");
        }
        if (_question is not null)
        {
            builder.Append($"question={_question}&");
        }
        return builder.ToString().TrimEnd('&');
    }

    public PollFilter AddStart(string start)
    {
        _start = start;
        return this;
    }

    public PollFilter AddLimit(int limit)
    {
        _limit = limit;
        return this;
    }

    public PollFilter AddAll(Boolean all)
    {
        _all = all;
        return this;
    }

    public PollFilter AddQuestion(int question)
    {
        _question = question;
        return this;
    }
    #endregion
}