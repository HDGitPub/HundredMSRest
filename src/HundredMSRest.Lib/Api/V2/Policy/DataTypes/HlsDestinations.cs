namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>HlsDestinations</c> HlsDestinations
/// </summary>
public record HlsDestinations(string name)
{
    public int maxDuration { get; set; }
    public HlsLayer? layers { get; set; }
    public string? playlistType { get; set; }
    public int numPlaylistSegments { get; set; }
    public int videoFrameRate { get; set; }
    public bool enableMetadataInsertion { get; set; }
    public bool enableStaticUrl { get; set; }
    public HlsRecording? recording { get; set; }
    public int autoStopTimeout { get; set; }
}
