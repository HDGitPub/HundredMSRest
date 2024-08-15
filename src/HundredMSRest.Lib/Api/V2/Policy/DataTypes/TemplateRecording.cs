using System.Collections;
using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Requests;

public record TemplateRecording(string name, string role) : RequestRecord
{
    public int? maxDuration { get; set; }
    public int? presignDuration { get; set; }
    public Thumbnails? thumbnails { get; set; }
    public CompositeRecording? compositeRecording { get; set; }
    public TrackRecording? trackRecording { get; set; }
    public StreamRecording? streamRecording { get; set; }
}
