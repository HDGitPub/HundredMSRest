namespace HundredMSRest.Lib.Api.Rooms.DataTypes;

/// <summary>
/// Record <c>RecordingInfo</c>
/// </summary>
/// <param name="enabled"></param>
/// <param name="upload_info"></param>
public record RecordingInfo(bool enabled, UploadInfo upload_info);
