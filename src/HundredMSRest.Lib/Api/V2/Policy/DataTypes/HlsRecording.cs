namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>HlsRecording</c> HlsRecording
/// </summary>
public record HlsRecording
{
    public bool hlsVod { get; set; }
    public bool singleFilePerLayer { get; set; }
    public bool enableZipUpload { get; set; }
    public HlsLayer? layers { get; set; }
    public Thumbnail? thumbnails { get; set; }
    public int presignDuration { get; set; }
}
