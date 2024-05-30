namespace HundredMSRest.Lib.Api.V2.Common.DataTypes;

/// <summary>
/// Record <c>UploadInfo</c>
/// </summary>
/// <param name="type"></param>
/// <param name="location"></param>
/// <param name="prefix"></param>
/// <param name="options"></param>
/// <param name="credentials"></param>
/// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/Rooms/create-via-api#upload-info-arguments"/>
public record UploadInfo(string type, string location)
{
    public string? prefix { get; set; }
    public Credentials? credentials { get; set; }
    public Options? options { get; set; }
}
