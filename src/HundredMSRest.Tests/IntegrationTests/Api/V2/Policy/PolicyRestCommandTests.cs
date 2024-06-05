using FluentAssertions;
using HundredMSRest.Lib.Api.V2.Common.Builders;
using HundredMSRest.Lib.Api.V2.Policy.Builders;
using HundredMSRest.Lib.Api.V2.Policy.Commands;
using HundredMSRest.Lib.Api.V2.Policy.Common;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Policy;

public class PolicyRestCommandTests
{
    private readonly PolicyTestSettings _settings;

    public PolicyRestCommandTests()
    {
        _settings = new PolicyTestSettings();
    }

    [Fact]
    public async Task Create_Policy_ReturnsPolicy()
    {
        // Arrange
        string GUEST_ROLE = "guest";
        string HOST_ROLE = "host";

        IEnumerable<TrackType> hostAllowedTracks = new List<TrackType>()
        {
            TrackType.AUDIO,
            TrackType.VIDEO,
            TrackType.SCREEN,
        };
        IEnumerable<TrackType> guestAllowedTracks = new List<TrackType>()
        {
            TrackType.AUDIO,
            TrackType.VIDEO
        };

        // The associated role can share audio, video, and screen tracks
        var hostPublishParams = new PublishParamsBuilder()
            .AddAudio()
            .AddVideo(bitRate: 850, frameRate: 30, width: 720, height: 1280)
            .AddScreen(bitRate: 1000, frameRate: 10, width: 1280, height: 720)
            .AddAllowedTracks(hostAllowedTracks)
            .Build();

        var guestPublishParams = new PublishParamsBuilder()
            .AddAudio()
            .AddVideo(bitRate: 850, frameRate: 30, width: 1280, height: 720)
            .AddAllowedTracks(guestAllowedTracks)
            .Build();

        var hostPermissions = new PermissionsBuilder()
            .EnableHlsStreaming(false)
            .EnableRtmpStreaming(false)
            .EnableBrowserRecording(true)
            .EnableSendRoomState(true)
            .EnableRemoveOthers(true)
            .EnableMute(true)
            .EnableUnmute(true)
            .EnableChangeRole(true)
            .EnablePollWrite(true)
            .EnablePollRead(true)
            .EnableEndRoom(true)
            .Build();

        var guestPermissions = new PermissionsBuilder()
            .EnableHlsStreaming(false)
            .EnableRtmpStreaming(false)
            .EnableBrowserRecording(false)
            .EnableSendRoomState(true)
            .EnablePollWrite(true)
            .EnablePollRead(true)
            .Build();

        var subscribeParams = new SubscribeParamsBuilder()
            .AddMaxSubsBitRate(3200)
            .AddSubscribeToRoles(new List<string>() { HOST_ROLE, GUEST_ROLE })
            .AddDegradation(25)
            .Build();

        var hostRole = new RoleBuilder()
            .AddName(HOST_ROLE)
            .AddPriority(1)
            .AddPermissions(hostPermissions)
            .AddPublishParams(hostPublishParams)
            .AddSubscribeParams(subscribeParams)
            .AddMaxPeerCount(50) // 0, n, -1
            .Build();

        var guestRole = new RoleBuilder()
            .AddName(GUEST_ROLE)
            .AddPriority(2)
            .AddPermissions(guestPermissions)
            .AddPublishParams(guestPublishParams)
            .AddSubscribeParams(subscribeParams)
            .AddMaxPeerCount(50) // 0, n, -1
            .Build();

        var recordingInfo = new RecordingInfoBuilder()
            .AddUploadInfo(StorageType.S3, _settings.Bucket, region: Region.Aws.US_EAST_1)
            .AddCredentials(_settings.BucketAccessKey, _settings.BucketSecretKey)
            .Build();

        var settings = new SettingsBuilder()
            .AddRegion(Region.Geographic.UNITED_STATES)
            .AddRoomState(5, true, true)
            .AddRecordingInfo(recordingInfo)
            .Build();

        var rtmpDestinations = new RtmpDestinationsBuilder("test-rtmp-destination")
            .AddWidth(1080)
            .AddHeight(1920)
            .AddMaxDuration(1800)
            .AddRtmpUrls(new List<string>() { "aaa", "bbb", "ccc" })
            .AddAutoStopTimeout(5)
            .SetRecordingEnabled(true)
            .Build();

        var destinations = new DestinationsBuilder().AddRtmpDestinations(rtmpDestinations).Build();

        var template = new PolicyBuilder()
            .AddName(_settings.TemplateName)
            .AddRole(hostRole)
            .AddRole(guestRole)
            .AddSettings(settings)
            .AddDestinations(destinations)
            .Build();

        // Act
        var result = await PolicyRestCommand.CreateAsync(template);

        // Assert
        result.Should().NotBeNull();
    }
}
