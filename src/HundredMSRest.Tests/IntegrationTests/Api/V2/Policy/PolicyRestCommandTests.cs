using FluentAssertions;
using HundredMSRest.Lib.Api.V2.Common.Builders;
using HundredMSRest.Lib.Api.V2.Policy.Builders;
using HundredMSRest.Lib.Api.V2.Policy.Commands;
using HundredMSRest.Lib.Api.V2.Policy.Common;
using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Policy;

public class PolicyRestCommandTests
{
    private readonly PolicyTestSettings _settings;

    public PolicyRestCommandTests()
    {
        _settings = new PolicyTestSettings();
    }

    // Policy template based tests
    [Fact]
    public async Task Create_Policy_ReturnsPolicy()
    {
        // Arrange
        string GUEST_ROLE = "guest";
        string HOST_ROLE = "host";
        string RECORDER_ROLE = "recorder";

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

        var recorderPublishParams = new PublishParamsBuilder().AddAllowedTracks().Build();

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

        var recorderPermissions = new PermissionsBuilder()
            .EnableHlsStreaming(true)
            .EnableRtmpStreaming(true)
            .EnableBrowserRecording(true)
            .EnableSendRoomState(true)
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

        var recorderRole = new RoleBuilder()
            .AddName(RECORDER_ROLE)
            .AddPriority(1)
            .AddPermissions(recorderPermissions)
            .AddSubscribeParams(subscribeParams)
            .Build();

        var recordingInfo = new RecordingInfoBuilder()
            .AddUploadInfo(
                StorageType.R2,
                _settings.Bucket,
                prefix: $"{Guid.NewGuid()}",
                accountId: _settings.AccountId,
                region: Region.Aws.US_EAST_1
            )
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
            .AddAutoStopTimeout(5)
            .SetRecordingEnabled(true)
            .Build();

        var destinations = new DestinationsBuilder().AddRtmpDestinations(rtmpDestinations).Build();

        var template = new PolicyBuilder()
            .AddName(_settings.TemplateName)
            .AddRole(hostRole)
            .AddRole(guestRole)
            .AddRole(recorderRole)
            .AddSettings(settings)
            .AddDestinations(destinations)
            .Build();

        var templateRecording = new TemplateRecordingBuilder(
            recorderRole.name ?? "default",
            RECORDER_ROLE
        )
            .AddCompositeRecording(false, true, false, 0, 1280, 720)
            .AddStreamRecording(1280, 720)
            .Build();

        // Act
        var result = await PolicyRestCommand.CreateAsync(template);
        // Assert
        result.Should().NotBeNull();
        if (result.id is not null)
        {
            var result2 = await PolicyRestCommand.UpdateRecordingAsync(
                result.id,
                templateRecording
            );
            result2.Should().NotBeNull();
        }
    }

    [Fact]
    public async Task Get_Policy_ReturnsPolicy()
    {
        // Arrange
        var templateId = _settings.TemplateId;

        // Act
        var result = await PolicyRestCommand.GetAsync(templateId);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task List_Policy_ReturnsAllPolicies()
    {
        // Act
        var result = await PolicyRestCommand.ListAsync();

        // Assert
        result.Should().NotBeNull();
        result?.data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Update_Policy_ReturnsPolicy()
    {
        // Arrange
        var templateId = _settings.TemplateId;
        var template = await PolicyRestCommand.GetAsync(templateId);

        // Act
        Role testRole = new RoleBuilder()
            .AddName("Test")
            .AddMaxPeerCount(10)
            .AddPriority(4)
            .Build();
        template?.roles.Add(testRole?.name, testRole);

        var result = await PolicyRestCommand.UpdateAsync(template);

        // Assert
        result.Should().NotBeNull();
    }

    // Role base tests
    [Fact]
    public async Task Get_Policy_Role_ReturnsPolicyRole()
    {
        // Arrange
        var templateId = _settings.TemplateId;
        var roleName = _settings.RoleName;

        // Act
        var result = await PolicyRestCommand.GetRoleAsync(templateId, roleName);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Update_Policy_Role_ReturnsPolicyRole()
    {
        // Arrange
        var templateId = _settings.TemplateId;
        var roleName = _settings.RoleName;

        // Act
        var role = await PolicyRestCommand.GetRoleAsync(templateId, roleName);
        if (role is not null)
        {
            role.maxPeerCount = _settings.MaxPeerCount;
        }

        var result = await PolicyRestCommand.UpdateRoleAsync(templateId, role);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Delete_Policy_Role_ReturnsPolicyRole()
    {
        // Arrange
        var templateId = _settings.TemplateId;
        var roleName = _settings.RoleName;

        // Act
        var result = await PolicyRestCommand.DeleteRoleAsync(templateId, roleName);

        // Assert
        result.Should().BeTrue();
    }
}
