namespace HundredMSRest.Lib.Api.V2.Rooms.DataTypes;

/// <summary>
/// Record <c>UploadInfo</c>
/// </summary>
/// <param name="type"></param>
/// <param name="location"></param>
/// <param name="prefix"></param>
/// <param name="options"></param>
/// <param name="credentials"></param>
/// <see href="https://www.100ms.live/docs/server-side/v2/api-reference/Rooms/create-via-api#upload-info-arguments"/>
public record UploadInfo
{
    public UploadInfo(string type, string location)
    {
        Type = type;
        Location = location;
    }

    public string Type { get; set; }
    public string Location { get; set; }
    public string? Prefix { get; set; }
    public Credentials? Credentials { get; set; }
    public Options? Options { get; set; }
}
