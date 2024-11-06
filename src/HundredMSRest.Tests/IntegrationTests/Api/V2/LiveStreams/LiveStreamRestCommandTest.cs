using FluentAssertions;
using HundredMSRest.Lib.Api.V2.LiveStreams.Commands;
using HundredMSRest.Lib.Api.V2.LiveStreams.DataTypes;
using HundredMSRest.Lib.Api.V2.LiveStreams.Filters;
using HundredMSRest.Lib.Api.V2.LiveStreams.Requests;
using HundredMSRest.Lib.Api.V2.Recordings.Builders;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.LiveStreams;

public class LiveStreamRestCommandTests
{
    private readonly LiveStreamTestSettings _settings;

    public LiveStreamRestCommandTests()
    {
        _settings = new LiveStreamTestSettings();
    }

    [Fact]
    public async void Start_LiveStream_ReturnsLiveStream()
    {
        // Arrange
        var roomId = _settings.RoomId;

        var request = new StartLiveStreamRequest();
        request.meeting_url = _settings.MeetingUrl;
        request.recording = new Recording() { hls_vod = false, single_file_per_layer = false };
        var transcription = new TranscriptionBuilder("TestTranscript")
            .AddEnabled(true)
            .AddSummary(true, "TestSummary", 0.1f)
            .Build();

        request.transcription = transcription;

        // Act
        var result = await LiveStreamsRestCommand.StartAsync(roomId, request);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<LiveStream>();
    }

    [Fact]
    public async void Stop_LiveStream_ReturnsLiveStreamList()
    {
        // Arrange
        var roomId = _settings.RoomId;

        // Act
        var result = await LiveStreamsRestCommand.StopAsync(roomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<LiveStreamList>();
    }

    [Fact]
    public async void Get_LiveStream_ReturnsLiveStream()
    {
        // Arrange
        var streamId = _settings.StreamId;

        // Act
        var result = await LiveStreamsRestCommand.GetAsync(streamId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<LiveStream>();
    }

    [Fact]
    public async void List_LiveStreams_ReturnsLiveStreamList()
    {
        // Act
        var result = await LiveStreamsRestCommand.ListAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<LiveStreamList>();
    }

    [Fact]
    public async void List_LiveStreams_ByFilter_ReturnsLiveStreamList()
    {
        // Arrange
        var filter = new LiveStreamFilter()
            .AddLimit(_settings.Limit)
            .AddRoomId(_settings.RoomId)
            .Filter();

        // Act
        var result = await LiveStreamsRestCommand.ListAsync(filter);

        // Assert
        result.Should().NotBeNull();
        result.limit.Should().Be(_settings.Limit);
        result.Should().BeOfType<LiveStreamList>();
    }

    [Fact]
    public async void Stop_LiveStream_ById_ReturnsLiveStream()
    {
        // Arrange
        var streamId = _settings.StreamId;

        var expected = new LiveStream() { id = streamId };

        // Act
        var result = await LiveStreamsRestCommand.StopByIdAsync(streamId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<LiveStream>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void Send_LiveStream_TimedMetaData_ReturnsLiveStream()
    {
        // Arrange
        var streamId = _settings.StreamId;
        var payload = _settings.Payload;
        var duration = _settings.Duration;

        var request = new TimedMetaDataRequest(payload, duration);

        // Act
        var result = await LiveStreamsRestCommand.SendTimedMetaData(streamId, request);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<LiveStream>();
    }

    [Fact]
    public async void Pause_LiveStream_Recording_ReturnsLiveStream()
    {
        // Arrange
        var streamId = _settings.StreamId;

        // Act
        var result = await LiveStreamsRestCommand.PauseRecordingAsync(streamId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<LiveStream>();
    }

    [Fact]
    public async void Resume_LiveStream_Recording_ReturnsLiveStream()
    {
        // Arrange
        var streamId = _settings.StreamId;

        // Act
        var result = await LiveStreamsRestCommand.ResumeRecordingAsync(streamId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<LiveStream>();
    }
}
