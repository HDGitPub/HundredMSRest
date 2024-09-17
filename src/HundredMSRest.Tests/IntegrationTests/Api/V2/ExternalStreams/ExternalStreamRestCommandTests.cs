using FluentAssertions;
using HundredMSRest.Lib.Api.V2.ExternalStreams.Commands;
using HundredMSRest.Lib.Api.V2.ExternalStreams.DataTypes;
using HundredMSRest.Lib.Api.V2.ExternalStreams.Requests;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.ExternalStreams;

public class ExternalStreamRestCommandTests
{
    private readonly ExternalStreamTestSettings _settings;

    public ExternalStreamRestCommandTests()
    {
        _settings = new ExternalStreamTestSettings();
    }

    [Fact]
    public async void Start_ExternalStream_ReturnsExternalStream()
    {
        // Arrange
        var roomId = _settings.RoomId;

        var rtmp_urls = new string[] {""};
        var request = new StartExternalStreamRequest(rtmp_urls);

        // Act
        var result = await ExternalStreamsRestCommand.StartAsync(roomId,request);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ExternalStreamList>();
    }

    [Fact]
    public async void Stop_ExternalStream_Room_ReturnsExternalStreamList()
    {
        // Arrange
        var roomId = _settings.RoomId;

        // Act
        var result = await ExternalStreamsRestCommand.StopRoomStreamAsync(roomId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ExternalStreamList>();
    }

    [Fact]
    public async void Stop_ExternalStream_Stream_ReturnsExternalStreamList()
    {
        // Arrange
        var streamId = _settings.StreamId;

        // Act
        var result = await ExternalStreamsRestCommand.StopStreamAsync(streamId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ExternalStream>();
    }

    [Fact]
    public async void Get_ExternalStream_ReturnsExternalStream()
    {
        // Arrange
        var streamId = _settings.StreamId;

        // Act
        var result = await ExternalStreamsRestCommand.GetAsync(streamId);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async void List_ExternalStream_ReturnsExternalStreamList()
    {
        // Arrange

        // Act
        var result = await ExternalStreamsRestCommand.ListAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ExternalStreamList>();
        result.data.Should().NotBeNull();
    }
}