using HundredMSRest.Lib.Api.V2.Polls.DataTypes;
using System.ComponentModel;

public sealed class PollBuilder
{
    private readonly Poll _poll;
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
}