using HundredMSRest.Lib.Api.V2.Rooms.DataTypes;
using HundredMSRest.Lib.Api.V2.Rooms.Requests;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Lib.Api.V2.Rooms.Builders;

/// <summary>
/// Class <c>UpdateRoomRequestBuilder</c> Builds a new UpdateRoomRequest
/// </summary>
public class UpdateRoomRequestBuilder
{
    #region Attributes
    private readonly UpdateRoomRequest _request;
    #endregion

    #region Methods

    public UpdateRoomRequestBuilder()
    {
        _request = new UpdateRoomRequest();
    }

    /// <summary>
    /// Class <c>UpdateRoomRequest</c> Builds a new UpdateRoomRequest
    /// /// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/Rooms/update-a-room"/>
    /// </summary>
    /// <returns></returns>
    public UpdateRoomRequest Build()
    {
        return _request;
    }

    /// <summary>
    /// Updates room name
    /// </summary>
    /// <param name="name"></param>
    public UpdateRoomRequestBuilder AddName(string name)
    {
        _request.name = name;
        return this;
    }

    /// <summary>
    /// Updates room description
    /// </summary>
    /// <param name="description"></param>
    public UpdateRoomRequestBuilder AddDescription(string description)
    {
        _request.description = description;
        return this;
    }

    /// <summary>
    /// Updates room recording information
    /// </summary>
    /// <param name="enabled"></param>
    /// <param name=""></param>
    /// <returns></returns>
    public UpdateRoomRequestBuilder AddRecordingInfo(bool? enabled = null)
    {
        _request.recording_info = new RecordingInfo() { enabled = enabled };
        return this;
    }

    /// <summary>
    /// Adds recording storage related information. Type can be S3, GCP, R2, OSS. Location is the Name of the storage
    /// bucket in which you want to store all recordings. Prefix is the path prefix. Region is the cloud
    /// provider region.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="location">Name of the storage bucket in which you want to store all recordings</param>
    /// <param name="prefix"></param>
    /// <param name="region"></param>
    /// <returns></returns>
    public UpdateRoomRequestBuilder AddUploadInfo(
        StorageType type,
        string location,
        string? prefix = null,
        string? region = null
    )
    {
        if (_request.recording_info is null)
            throw new Exception(Strings.ROOM_INVALID_UPLOAD_CONFIG);

        _request.recording_info.upload_info = new UploadInfo(type.Value, location)
        {
            prefix = prefix,
            options = region is not null ? new Options(region) : null
        };

        if (
            _request.recording_info.upload_info.type == StorageType.S3.Value
            && _request.recording_info.upload_info.options is null
        )
        {
            throw new Exception(Strings.ROOM_INVALID_UPLOAD_S3_CONFIG);
        }
        return this;
    }

    /// <summary>
    /// Adds credentials for accessing the storage location
    /// </summary>
    /// <param name="key"></param>
    /// <param name="secret"></param>
    /// <returns></returns>
    public UpdateRoomRequestBuilder AddCredentials(string key, string secret)
    {
        if (_request.recording_info?.upload_info is null)
            throw new Exception(Strings.ROOM_INVALID_CREDENTIALS_CONFIG);

        _request.recording_info.upload_info.credentials = new Credentials(key, secret);
        return this;
    }

    /// <summary>
    /// Sets large room property
    /// </summary>
    /// <param name="largeRoom"></param>
    /// <returns></returns>
    public UpdateRoomRequestBuilder AddLargeRoom(bool largeRoom)
    {
        _request.large_room = largeRoom;
        return this;
    }

    /// <summary>
    /// Sets the size property
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public UpdateRoomRequestBuilder AddSize(int size)
    {
        _request.size = size;
        return this;
    }

    /// <summary>
    /// Sets the max duration seconds property
    /// </summary>
    /// <param name="maxDurationSeconds"></param>
    /// <returns></returns>
    public UpdateRoomRequestBuilder AddMaxDurationSeconds(int maxDurationSeconds)
    {
        _request.max_duration_seconds = maxDurationSeconds;
        return this;
    }

    /// <summary>
    /// Sets the polls property
    /// </summary>
    /// <param name="polls"></param>
    /// <returns></returns>
    public UpdateRoomRequestBuilder AddPolls(string[] polls)
    {
        _request.polls = polls;
        return this;
    }

    /// <summary>
    /// Sets the webhook property
    /// </summary>
    /// <param name="webHook"></param>
    /// <returns></returns>
    public UpdateRoomRequestBuilder AddWebHook(WebHook webHook)
    {
        _request.webhook = webHook;
        return this;
    }

    #endregion
}
