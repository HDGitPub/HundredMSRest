using HundredMSRest.Lib.Api.V2.Recordings.Constants;

namespace HundredMSRest.Lib.Api.V2.Common.DataTypes;

/// <summary>
/// Record <c>Transcription</c>
/// </summary>
public record Transcription(string name)
{
    public bool? enabled { get; set; }
    public OutputModes? output_modes { get; set; }
    public OutputModes? outputModes { get; set; }
    public string[]? custom_vocabulary { get; set; }
    public string[]? customVocabulary { get; set; }
    public Summary? summary { get; set; }
    public string[]? modes { get; set; }
    public string? role { get; set; }
}
