using FluentAssertions;
using HundredMSRest.Lib.Api.V2.Analytics.Commands;
using HundredMSRest.Lib.Api.V2.Analytics.DataTypes;
using HundredMSRest.Lib.Api.V2.Analytics.Filters;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Analytics;

public class AnalyticsRestCommandTests
{
    private readonly AnalyticsTestSettings _settings;

    public AnalyticsRestCommandTests()
    {
        _settings = new AnalyticsTestSettings();
    }

    [Fact]
    public async void Get_Track_Events_ReturnsTrackEvents()
    {
        // Arrange
        var roomId = _settings.RoomId;
        var filter = new EventFilter(roomId)
            .AddType(EventType.TRACK_ADD_SUCCESS)
            .AddType(EventType.TRACK_REMOVE_SUCCESS)
            .AddType(EventType.TRACK_UPDATE_SUCCESS)
            .Filter();

        // Act
        var result = await AnalyticsRestCommand.GetAsync<TrackEvent>(filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<EventList<TrackEvent>>();
        result?.events.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async void Get_Recording_Events_ReturnsRecordingEvents()
    {
        // Arrange
        var roomId = _settings.RoomId;
        var filter = new EventFilter(roomId).AddType(EventType.BEAM_RECORDING_SUCCESS).Filter();

        // Act
        var result = await AnalyticsRestCommand.GetAsync<RecordingEvent>(filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<EventList<RecordingEvent>>();
        result?.events.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async void Get_Error_Events_ReturnsErrorEvents()
    {
        // Arrange
        var roomId = _settings.RoomId;
        var filter = new EventFilter(roomId)
            .AddType(EventType.CLIENT_CONNECT_FAILED)
            .AddType(EventType.CLIENT_JOIN_FAILED)
            .AddType(EventType.CLIENT_PUBLISH_FAILED)
            .AddType(EventType.CLIENT_SUBSCRIBE_FAILED)
            .AddType(EventType.CLIENT_DISCONNECTED)
            .Filter();

        // Act
        var result = await AnalyticsRestCommand.GetAsync<ErrorEvent>(filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<EventList<ErrorEvent>>();
        result?.events.Should().HaveCountGreaterThan(0);
    }
}
