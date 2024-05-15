using FluentAssertions;
using HundredMSRest.Lib.Api.V2.Recordings.Builders;
using HundredMSRest.Lib.Api.V2.Recordings.Commands;
using HundredMSRest.Lib.Api.V2.Recordings.DataTypes;
using HundredMSRest.Lib.Api.V2.Recordings.Filters;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Recordings;

/// <summary>
/// Class <c>RecordingsRestCommandTests</c> contains recording integration tests
/// </summary>
public class RecordingsRestCommandTests
{
    private readonly RecordingsTestSettings _settings;

    public RecordingsRestCommandTests()
    {
        _settings = new RecordingsTestSettings();
    }

    [Fact]
    public async void Get_Recording_ReturnsRecording()
    {
        // Arrange
        var recordingId = _settings.RecordingId;
        var expected = new { id = recordingId };

        // Act
        var result = await RecordingRestCommand.GetAsync(recordingId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Recording>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void Start_Recording_ReturnsRecording()
    {
        // Arrange
        var recordingRoomId = _settings.RecordingRoomId;
        var request = new RecordingRequestBuilder().AddResolution(1280, 720).Build();

        var expected = new { room_id = recordingRoomId };

        // Act
        var result = await RecordingRestCommand.StartRecordingAsync(recordingRoomId, request);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Recording>();
        result?.id.Should().NotBeNull();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void List_Recordings_ReturnsRecordings()
    {
        // Arrange
        var recordingRoomId = _settings.RecordingRoomId;
        var requestFilter = new RecordingRequestFilter().AddRoomId(recordingRoomId).Filter();

        // Act
        var result = await RecordingRestCommand.ListRecordingsAsync(requestFilter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RecordingList>();
        result?.data.Should().NotBeEmpty();
    }

    [Fact]
    public async void Stop_Room_Recording_ReturnsRecordings()
    {
        // Arrange
        var recordingRoomId = _settings.RecordingRoomId;

        // Act
        var result = await RecordingRestCommand.StopRecordingAsync(recordingRoomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RecordingList>();
        result?.data.Should().NotBeEmpty();
    }

    [Fact]
    public async void Stop_Recording_ById_ReturnsRecording()
    {
        // Arrange
        var recordingId = _settings.RecordingId;
        var expected = new { id = recordingId };

        // Act
        var result = await RecordingRestCommand.StopRecordingByIdAsync(recordingId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Recording>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void Pause_Recording_PausesRecording()
    {
        // Arrange
        var recordingRoomId = _settings.RecordingRoomId;
        var expected = new { room_id = recordingRoomId };

        // Act
        var result = await RecordingRestCommand.PauseRecordingAsync(recordingRoomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Recording>();
        result?.id.Should().NotBeNull();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void Resume_Recording_ResumesRecording()
    {
        // Arrange
        var recordingRoomId = _settings.RecordingRoomId;
        var expected = new { room_id = recordingRoomId };

        // Act
        var result = await RecordingRestCommand.ResumeRecordingAsync(recordingRoomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Recording>();
        result?.id.Should().NotBeNull();
        result.Should().BeEquivalentTo(expected);
    }
}
