using HundredMSRest.Lib.Api.V2.Recordings.Constants;

namespace HundredMSRest.Lib.Api.V2.Recordings.DataTypes;

/// <summary>
/// Record <c>Transcription</c>
/// </summary>
public class Transcription
{
    public bool? enabled { get; set; }
    public OutputModes? output_modes { get; set; }
    public string[]? custom_vocabulary { get; set; }
    public Summary? summary { get; set; }
}
