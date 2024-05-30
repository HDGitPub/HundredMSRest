namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>SimulcastLayer</c> SimulcastLayer
/// </summary>
public record SimulcastLayer(int maxFramerate, long scaleResolutionDownBy, string rid)
{
    public int maxBitrate { get; set; }
}
