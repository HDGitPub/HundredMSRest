namespace HundredMSRest.Lib.Api.V2.Policy.DataTypes;

/// <summary>
/// Record <c>SubscribeParams</c> SubscribeParams
/// </summary>
public record SubscribeParams
{
    public int maxSubsBitRate { get; set; }
    public IEnumerable<string>? subscribeToRoles { get; set; }
    public SubscribeDegradation? subscribeDegradation { get; set; }
}
