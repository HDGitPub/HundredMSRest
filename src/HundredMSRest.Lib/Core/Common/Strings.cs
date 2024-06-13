using System.Data;

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

    public const string POLICY_INVALID_AUDIO_BITRATE = "Audio bit rate must be between 16 - 128";
    public const string POLICY_INVALID_AUDIO_CODEC = "Audio codec must be OPUS";
    public const string POLICY_INVALID_VIDEO_BITRATE = "Video bit rate must be between 30 - 2000";
    public const string POLICY_INVALID_VIDEO_CODEC = "Video codec must be VP8";
    public const string POLICY_INVALID_VIDEO_FRAMERATE = "Video framerate must be between 1 - 30";
    public const string POLICY_INVALID_VIDEO_HEIGHT = "Video height must be between 50 - 1080";
    public const string POLICY_INVALID_VIDEO_WIDTH = "Video width must be between 50 - 1920";

    public const string POLICY_INVALID_SCREEN_BITRATE = "Screen bitrate must be between >= 500";
    public const string POLICY_INVALID_SCREEN_CODEC = "Video codec must be VP8";
    public const string POLICY_INVALID_SCREEN_FRAMERATE = "Screen framerate must be between 1 - 30";
    public const string POLICY_INVALID_SCREEN_HEIGHT = "Video height must be between 270 - 1080";
    public const string POLICY_INVALID_SCREEN_WIDTH = "Video width must be between 480 - 1920";
    public const string POLICY_INVALID_DEGRADATION_LOSS_THRESHOLD =
        "must be within the range: 1 - 100";
    public const string POLICY_INVALID_DEGRADATION_GRACE_PERIOD = "must be within range 1 - 10";
    public const string POLICY_INVALID_DEGRADATION_RECOVER_PERIOD = "must be within range 1 - 10";
    public const string POLICY_INVALID_ROLE_PRIORITY = "must be withing range 1 - 5";
    public const string POLICY_INVALID_REGION = "region must be (in, us, eu or auto)";
    public const string POLICY_INVALID_RTMPURL_COUNT = "rtmp urls has max count of 3";
    public const string INVALID_JSON_DESERIALIZATION =
        "Unable to deserialize json into object of type: ";
}
