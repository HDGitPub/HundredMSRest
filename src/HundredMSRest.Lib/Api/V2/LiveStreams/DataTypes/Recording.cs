namespace HundredMSRest.Lib.Api.V2.LiveStreams.DataTypes;

/// <summary>
/// Record <c>Recording</c>
/// </summary>
public record Recording
{
    public bool hls_vod { get; set; }
    public bool single_file_per_layer { get; set; }
}
