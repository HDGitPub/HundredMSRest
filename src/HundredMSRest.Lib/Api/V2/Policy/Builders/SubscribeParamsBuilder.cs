using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

public sealed class SubscribeParamsBuilder
{
    #region Attributes
    private readonly SubscribeParams _subscribeParams;
    #endregion

    #region Methods
    public SubscribeParamsBuilder()
    {
        _subscribeParams = new SubscribeParams();
    }

    public SubscribeParamsBuilder AddMaxSubsBitRate(int maxSubsBitRate)
    {
        _subscribeParams.maxSubsBitRate = maxSubsBitRate;
        return this;
    }

    public SubscribeParamsBuilder AddSubscribeToRoles(List<string> roleNames)
    {
        _subscribeParams.subscribeToRoles = roleNames;
        return this;
    }

    public SubscribeParamsBuilder AddDegradation(
        int? packetLossThreshold,
        int? degradeGracePeriodSeconds,
        int? recoverGracePeriodSeconds
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

    public SubscribeParams Build()
    {
        return _subscribeParams;
    }
    #endregion
}
