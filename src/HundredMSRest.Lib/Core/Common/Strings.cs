namespace HundredMSRest.Lib.Core.Common;

/// <summary>
/// Class <c>Strings</c> string constants
/// </summary>
internal class Strings
{
    public const string ROOM_INVALID_UPLOAD_S3_CONFIG =
        "Invalid Upload configuration. Options region is required for S3";

    public const string ROOM_INVALID_UPLOAD_CONFIG =
        "Builder error. Add RecordingInfo before adding UploadInfo.";

    public const string ROOM_INVALID_CREDENTIALS_CONFIG =
        "Builder error. Add UploadInfo before adding credentials.";
}
