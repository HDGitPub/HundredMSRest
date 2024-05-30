namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>SubscribeDegradation</c> SubscribeDegradation
/// </summary>
public record SubscribeDegradation
{
    public int packetLossThreshold { get; set; }
    public int degradeGracePeriodSeconds { get; set; }
    public int recoverGracePeriodSeconds { get; set; }
}
