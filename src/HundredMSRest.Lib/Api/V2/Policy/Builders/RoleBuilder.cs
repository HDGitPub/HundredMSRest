using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

/// <summary>
/// Class <c>RoleBuilder</c> Builds Role class
/// </summary>
public sealed class RoleBuilder
{
    #region Attributes
    private readonly Role _role;
    #endregion

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    public RoleBuilder()
    {
        _role = new Role();
    }

    /// <summary>
    /// Adds name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public RoleBuilder AddName(string name)
    {
        _role.name = name;
        return this;
    }

    /// <summary>
    /// Adds Publish params
    /// </summary>
    /// <param name="publishParams"></param>
    /// <returns></returns>
    public RoleBuilder AddPublishParams(PublishParams publishParams)
    {
        _role.publishParams = publishParams;
        return this;
    }

    /// <summary>
    /// Adds subscription params
    /// </summary>
    /// <param name="subscribeParams"></param>
    /// <returns></returns>
    public RoleBuilder AddSubscribeParams(SubscribeParams subscribeParams)
    {
        _role.subscribeParams = subscribeParams;
        return this;
    }

    /// <summary>
    /// Adds Role permissions
    /// </summary>
    /// <param name="permissions"></param>
    /// <returns></returns>
    public RoleBuilder AddPermissions(Permissions permissions)
    {
        _role.permissions = permissions;
        return this;
    }

    /// <summary>
    /// Adds Role priority
    /// </summary>
    /// <param name="priority"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public RoleBuilder AddPriority(int priority)
    {
        if (priority < 1 || priority > 5)
            throw new ArgumentOutOfRangeException(
                $"{nameof(priority)} {Strings.POLICY_INVALID_ROLE_PRIORITY}"
            );

        _role.priority = priority;
        return this;
    }

    /// <summary>
    /// Adds MaxPeerCount
    /// </summary>
    /// <param name="maxPeerCount"></param>
    /// <returns></returns>
    public RoleBuilder AddMaxPeerCount(int maxPeerCount)
    {
        _role.maxPeerCount = maxPeerCount;
        return this;
    }

    /// <summary>
    /// Returns a configured instance of Role class
    /// </summary>
    /// <returns></returns>
    public Role Build()
    {
        return _role;
    }
    #endregion
}
