using FluentAssertions;
using HundredMSRest.Lib.Api.V2.Polls.Commands;
using HundredMSRest.Lib.Api.V2.Polls.DataTypes;
using HundredMSRest.Lib.Api.V2.Polls.Filters;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Polls;

public class PollRestCommandTests
{
    private readonly PollRestCommandTestSettings _settings;

    public PollRestCommandTests()
    {
        _settings = new PollRestCommandTestSettings();
    }

    [Fact]
    public async void Create_Poll_ReturnsPoll()
    {
        // Arrange
        var option1 = new Option()
        {
            index = 1,
            text = "Option1",
            weight = 1
        };

        var answer1 = new Answer()
        {
            hidden = false,
            text = "Answer1",
            options = [option1],
            trim = true,
            @case = false
        };

        var question1 = new QuestionBuilder(1,"Test Question 1","text",false)
            .AddAnswer(answer1)
            .AddOption(option1)
            .Build();

        var poll = new PollBuilder("TestPoll",1,true)
            .AddQuestion(question1)
            .Build();

        // Act
        var result = await PollRestCommand.CreateAsync(poll);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Poll>();
    }

    [Fact]
    public async void Update_Poll_ReturnsPoll()
    {
        // Arrange
        var pollId = _settings.PollId;
        var updateTitle = $"Updated Title-{DateTime.Now.ToString("yyyy-MM-dd")}";
        var updateDuration = new Random(100).Next();

        // Act
        var poll = await PollRestCommand.GetAsync(pollId);
        poll.duration = updateDuration;
        poll.Title = updateTitle;
        
        var result = await PollRestCommand.UpdateAsync(poll);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Poll>();
        result.duration.Should().Be(updateDuration);
        result.Title.Should().Be(updateTitle);
    }

    [Fact]
    public async void Get_Poll_ReturnsPoll()
    {
        // Arrange
        var pollId = _settings.PollId;

        // Act
        var result = await PollRestCommand.GetAsync(pollId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Poll>();
    }

    [Fact]
    public async void Get_Poll_Sessions_ReturnsSessions()
    {
        // Arrange
        var pollId = _settings.PollId;

        // Act
        var result = await PollRestCommand.GetSessionsAsync(pollId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ResponseList<SessionResponse>>();
    }

    [Fact]
    public async void Get_Poll_Sessions_ByFilter_ReturnsSessions()
    {
        // Arrange
        var pollId = _settings.PollId;
        var filter = new PollFilter()
            .AddAll(true)
            .Filter();
        
        // Act
        var result = await PollRestCommand.GetSessionsAsync(pollId,filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ResponseList<SessionResponse>>();
    }

    [Fact]
    public async void Get_Poll_Response_ReturnsResponse()
    {
        // Arrange
        var pollId = _settings.PollId;
        var responseId = _settings.ResponseId;

        // Act
        var result = await PollRestCommand.GetResponseAsync(pollId,responseId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<UserResponse>();
    }

    [Fact]
    public async void Get_Poll_Responses_ReturnsResponses()
    {
        // Arrange
        var pollId = _settings.PollId;

        // Act
        var result = await PollRestCommand.GetResponsesAsync(pollId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ResponseList<UserResponse>>();
    }

    [Fact]
    public async void Get_Poll_Responses_ByFilter_ReturnsResponses()
    {
        // Arrange
        var pollId = _settings.PollId;
        var filter = new PollFilter().AddAll(true).Filter();

        // Act
        var result = await PollRestCommand.GetResponsesAsync(pollId,filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ResponseList<UserResponse>>();
    }

    [Fact]
    public async void Get_Poll_Result_ReturnsResult()
    {
        // Arrange
        var pollId = _settings.PollId;
        var resultId = _settings.ResultId;

        // Act
        var result = await PollRestCommand.GetResultAsync(pollId,resultId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<PollResult>();
    }

    [Fact]
    public async void Get_Poll_Results_ReturnsResults()
    {
        // Arrange
        var pollId = _settings.PollId;

        // Act
        var result = await PollRestCommand.GetResultsAsync(pollId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<PollResultList>();
    }

    [Fact]
    public async void Get_Poll_Results_ByFilter_ReturnsResults()
    {
        // Arrange
        var pollId = _settings.PollId;
        var filter = new PollFilter().AddAll(true).Filter();

        // Act
        var result = await PollRestCommand.GetResultsAsync(pollId,filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<PollResultList>();
    }
}