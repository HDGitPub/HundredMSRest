using HundredMSRest.Lib.Api.V2.Policy.Common;

namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>PublishParams</c> PublishParams
/// </summary>
public record PublishParams
{
    public IEnumerable<TrackType>? allowed { get; set; }
    public AudioParams? audio { get; set; }
    public VideoParams? video { get; set; }
    public ScreenParams? screen { get; set; }
}
