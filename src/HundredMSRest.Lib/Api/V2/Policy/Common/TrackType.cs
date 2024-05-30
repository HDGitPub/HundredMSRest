namespace HundredMSRest.Lib.Api.V2.Policy.Common;

public class TrackType(string value, string description)
{
    #region statics
    public static TrackType AUDIO => new("audio", "Audio Track");
    public static TrackType VIDEO => new("video", "Video Track");
    public static TrackType SCREEN => new("screen", "Screen Track");
    public static TrackType SIMULCAST => new("simulcast", "Simulcast Track");
    #endregion

    #region Attributes
    #endregion

    #region Properties
    public string Value { get; } = value;
    public string Description { get; } = description;
    #endregion
}
