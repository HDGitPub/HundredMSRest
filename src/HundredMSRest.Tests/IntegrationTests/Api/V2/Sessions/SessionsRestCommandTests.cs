using FluentAssertions;
using HundredMSRest.Lib.Api.V2.Sessions.Commands;
using HundredMSRest.Lib.Api.V2.Sessions.DataTypes;
using HundredMSRest.Lib.Api.V2.Sessions.Filters;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Sessions;

public class SessionsRestCommandTests
{
    private readonly SessionsTestSettings _settings;

    public SessionsRestCommandTests()
    {
        _settings = new SessionsTestSettings();
    }

    [Fact]
    public async Task Get_Session_ReturnsSession()
    {
        // Arrange
        var expected = new { id = _settings.SessionId };

        // Act
        var result = await SessionRestCommand.GetAsync(_settings.SessionId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Session>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task List_Sessions_ByRoom_ReturnsSessions()
    {
        // Arrange
        var filter = new SessionsRequestFilter().AddRoomId(_settings.SessionRoomId).Filter();

        // Act
        var result = await SessionRestCommand.ListSessionsAsync(filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<SessionList>();
    }

    [Fact]
    public async Task List_Sessions_AfterDate_ReturnsSessions()
    {
        var after = new DateTime(2024, 05, 7, 2, 30, 0);

        // Arrange
        var filter = new SessionsRequestFilter().AddAfter(after).Filter();

        // Act
        var result = await SessionRestCommand.ListSessionsAsync(filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<SessionList>();
    }

    [Fact]
    public async Task List_Sessions_BeforeDate_ReturnsSessions()
    {
        var before = new DateTime(2024, 05, 6, 6, 30, 0);

        // Arrange
        var filter = new SessionsRequestFilter().AddBefore(before).Filter();

        // Act
        var result = await SessionRestCommand.ListSessionsAsync(filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<SessionList>();
    }
}
