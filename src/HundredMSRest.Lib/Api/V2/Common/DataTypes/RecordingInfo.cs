namespace HundredMSRest.Lib.Api.V2.Common.DataTypes;

/// <summary>
/// Record <c>RecordingInfo</c>
/// </summary>
/// <param name="enabled"></param>
/// <param name="upload_info"></param>
public record RecordingInfo
{
    public bool? enabled { get; set; }
    public UploadInfo? upload_info { get; set; }
    public UploadInfo? upload { get; set; }
}
