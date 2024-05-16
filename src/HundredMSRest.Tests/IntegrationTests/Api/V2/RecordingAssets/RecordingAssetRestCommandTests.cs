using FluentAssertions;
using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Api.V2.RecordingAssets.Commands;
using HundredMSRest.Lib.Api.V2.RecordingAssets.DataTypes;
using HundredMSRest.Lib.Api.V2.RecordingAssets.Filters;
using HundredMSRest.Lib.Api.V2.RecordingAssets.Responses;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.RecordingAssets;
public class RecordingAssetRestCommandTests
{
    private readonly RecordingAssetTestSettings _settings;
    public RecordingAssetRestCommandTests()
    {
        _settings = new RecordingAssetTestSettings();
    }

    [Fact]
    public async void Get_RecordingAsset_ReturnsRecordingAsset()
    {
        // Arrange
        var assetId = _settings.AssetId;
        var expected = new { id = assetId };

        // Act
        var result = await RecordingAssetRestCommand.GetAsync(assetId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RecordingAsset>();
        result?.path.Should().NotBeNullOrEmpty();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void Get_PresignedUrl_ReturnsPresignedUrl()
    {
        // Arrange
        var assetId = _settings.AssetId;
        var expected = new { id = assetId };

        // Act
        var result = await RecordingAssetRestCommand.GetPreSignedUrlAsync(assetId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<PresignedUrl>();
        result?.url.Should().NotBeNullOrEmpty();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void Get_PresignedUrl_Duration_ReturnsPresignedUrl()
    {
        // Arrange
        var assetId = _settings.AssetId;
        var expected = new { id = assetId };
        var duration = 20;

        // Act
        var result = await RecordingAssetRestCommand.GetPreSignedUrlAsync(assetId,duration);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<PresignedUrl>();
        result?.url.Should().NotBeNullOrEmpty();
        result?.expiry.Should().Be(duration);
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void List_RecordingAssets_ReturnsRecordingAssets()
    {
        // Arrange

        // Act
        var result = await RecordingAssetRestCommand.ListAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RecordingAssetList>();
        result?.data.Should().NotBeEmpty();
    }

    [Fact]
    public async void List_RecordingAssets_FilterByRoomId_ReturnsRecordingAssets()
    {
        // Arrange
        var roomId = _settings.RoomId;
        var filter = new RecordingAssetFilter().AddRoomId(roomId).Filter();

        // Act
        var result = await RecordingAssetRestCommand.ListAsync(filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RecordingAssetList>();
        result?.data.Should().NotBeEmpty();
    }

    [Fact]
    public async void List_RecordingAssets_FilterBySession_ReturnsRecordingAssets()
    {
        // Arrange
        var sessionId = _settings.SessionId;
        var filter = new RecordingAssetFilter().AddSessionId(sessionId).Filter();

        // Act
        var result = await RecordingAssetRestCommand.ListAsync(filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RecordingAssetList>();
        result?.data.Should().NotBeEmpty();
    }

    [Fact]
    public async void List_RecordingAssets_FilterByStatus_ReturnsRecordingAssets()
    {
        // Arrange
        var status = _settings.Status;
        var filter = new RecordingAssetFilter().AddStatus(status).Filter();

        // Act
        var result = await RecordingAssetRestCommand.ListAsync(filter);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<RecordingAssetList>();
        result?.data.Should().NotBeEmpty();
    }
}
