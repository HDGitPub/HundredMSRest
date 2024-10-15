using HundredMSRest.Lib.Api.V2.Polls.DataTypes;
using System.ComponentModel;

/// <summary>
/// Class <c>PollBuilder</c>
/// </summary>
public sealed class PollBuilder
{
    #region Attributes
    private readonly Poll _poll;
    #endregion

    #region Methods
    public PollBuilder(string? title = null,int? duration = null,bool? anonymous = null)
    {
        _poll = new Poll()
        {
            Title = title,
            duration = duration
        };
    }

    public PollBuilder AddQuestion(Question question)
    {
        _poll.questions ??= [];
        _poll.questions.Append(question);
        return this;
    }

    public Poll Build()
    {
        return _poll;
    }
    #endregion
}