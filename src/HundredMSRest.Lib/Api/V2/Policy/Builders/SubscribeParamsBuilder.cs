using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

/// <summary>
/// Class <c>SubscibeParamsBuilder</c> Builds SubscribeParams class
/// </summary>
public sealed class SubscribeParamsBuilder
{
    #region Attributes
    private readonly SubscribeParams _subscribeParams;
    #endregion

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    public SubscribeParamsBuilder()
    {
        _subscribeParams = new SubscribeParams();
    }

    /// <summary>
    /// Adds MaxSubsBitRate
    /// </summary>
    /// <param name="maxSubsBitRate"></param>
    /// <returns></returns>
    public SubscribeParamsBuilder AddMaxSubsBitRate(int maxSubsBitRate)
    {
        _subscribeParams.maxSubsBitRate = maxSubsBitRate;
        return this;
    }

    /// <summary>
    /// Adds roles which can be subscribed to
    /// </summary>
    /// <param name="roleNames"></param>
    /// <returns></returns>
    public SubscribeParamsBuilder AddSubscribeToRoles(List<string> roleNames)
    {
        _subscribeParams.subscribeToRoles = roleNames;
        return this;
    }

    /// <summary>
    /// Adds subscribe degradation params
    /// </summary>
    /// <param name="packetLossThreshold"></param>
    /// <param name="degradeGracePeriodSeconds"></param>
    /// <param name="recoverGracePeriodSeconds"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public SubscribeParamsBuilder AddDegradation(
        int? packetLossThreshold = null,
        int? degradeGracePeriodSeconds = null,
        int? recoverGracePeriodSeconds = null
    )
    {
        if (packetLossThreshold is not null && packetLossThreshold < 1 || packetLossThreshold > 100)
            throw new ArgumentException(
                $"{nameof(packetLossThreshold)} {Strings.POLICY_INVALID_DEGRADATION_LOSS_THRESHOLD}"
            );
        if (
            degradeGracePeriodSeconds is not null && degradeGracePeriodSeconds < 1
            || degradeGracePeriodSeconds > 10
        )
            throw new ArgumentException(
                $"{nameof(degradeGracePeriodSeconds)} {Strings.POLICY_INVALID_DEGRADATION_GRACE_PERIOD}"
            );
        if (
            recoverGracePeriodSeconds is not null && recoverGracePeriodSeconds < 1
            || degradeGracePeriodSeconds > 10
        )
            throw new ArgumentException(
                $"{nameof(recoverGracePeriodSeconds)} {Strings.POLICY_INVALID_DEGRADATION_RECOVER_PERIOD}"
            );

        _subscribeParams.subscribeDegradation = new SubscribeDegradation()
        {
            packetLossThreshold = packetLossThreshold ?? 50,
            degradeGracePeriodSeconds = degradeGracePeriodSeconds ?? 1,
            recoverGracePeriodSeconds = recoverGracePeriodSeconds ?? 4
        };
        return this;
    }

    /// <summary>
    /// Returns a configured instance of SubscribeParams
    /// </summary>
    /// <returns></returns>
    public SubscribeParams Build()
    {
        return _subscribeParams;
    }
    #endregion
}
