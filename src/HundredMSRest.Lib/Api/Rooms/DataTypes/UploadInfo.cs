namespace HundredMSRest.Lib.Api.Rooms.DataTypes;

/// <summary>
/// Record <c>UploadInfo</c>
/// </summary>
/// <param name="type"></param>
/// <param name="location"></param>
/// <param name="prefix"></param>
/// <param name="options"></param>
/// <param name="credentials"></param>
public record UploadInfo(
    string type,
    string location,
    string prefix,
    Options options,
    Credentials credentials
);
