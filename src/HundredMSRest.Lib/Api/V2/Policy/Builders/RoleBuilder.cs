using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

public sealed class RoleBuilder
{
    #region Attributes
    private readonly Role _role;
    #endregion

    #region Methods
    public RoleBuilder()
    {
        _role = new Role();
    }

    public RoleBuilder AddName(string name)
    {
        _role.name = name;
        return this;
    }

    public RoleBuilder AddPublishParams(PublishParams publishParams)
    {
        _role.publishParams = publishParams;
        return this;
    }

    public RoleBuilder AddSubscribeParams(SubscribeParams subscribeParams)
    {
        _role.subscribeParams = subscribeParams;
        return this;
    }

    public RoleBuilder AddPermissions(Permissions permissions)
    {
        _role.permissions = permissions;
        return this;
    }

    public RoleBuilder AddPriority(int priority)
    {
        if (priority < 1 || priority > 5)
            throw new ArgumentOutOfRangeException(
                $"{nameof(priority)} {Strings.POLICY_INVALID_ROLE_PRIORITY}"
            );

        _role.priority = priority;
        return this;
    }

    public RoleBuilder AddMaxPeerCount(int maxPeerCount)
    {
        _role.maxPeerCount = maxPeerCount;
        return this;
    }

    public Role Build()
    {
        return _role;
    }
    #endregion
}
