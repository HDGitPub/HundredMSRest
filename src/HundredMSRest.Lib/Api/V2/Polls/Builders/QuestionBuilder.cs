using HundredMSRest.Lib.Api.V2.Polls.DataTypes;

/// <summary>
/// Class <c>QuestionBuilder</c>
/// </summary>
public sealed class QuestionBuilder
{
    #region Attributes
    private readonly Question _question;
    #endregion

    #region Methods
    public QuestionBuilder(int? index = null, string? text = null, string? format = null,bool? skippable = null)
    {
        _question = new Question()
        {
            index = index,
            text = text,
            format = format,
            skippable = skippable
        };
    }

    public QuestionBuilder AddAnswer(Answer answer)
    {
        _question.answer = answer;
        return this;
    }

    public QuestionBuilder AddOption(Option option)
    {
        _question.options ??= [];
        _question.options.Append(option);
        return this;
    }

    public Question Build()
    {
        return _question;
    }

    #endregion
}