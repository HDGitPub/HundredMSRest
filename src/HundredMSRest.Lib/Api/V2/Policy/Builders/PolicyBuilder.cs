using HundredMSRest.Lib.Api.V2.Policy.DataTypes;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

/// <summary>
/// Class <c>PolicyBuilder</c> Builds policy / template class
/// </summary>
public sealed class PolicyBuilder
{
    #region Attributes
    private readonly Template _template;
    #endregion

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    public PolicyBuilder()
    {
        _template = new Template();
    }

    /// <summary>
    /// Adds name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public PolicyBuilder AddName(string name)
    {
        _template.name = name;
        return this;
    }

    /// <summary>
    /// Adds a role to the policy
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public PolicyBuilder AddRole(Role role)
    {
        if (_template.roles is null)
            _template.roles = new Dictionary<string, Role>();
        if (role.name is not null)
        {
            _template.roles.Add(role.name, role);
        }
        return this;
    }

    /// <summary>
    /// Adds settings to the policy
    /// </summary>
    /// <param name="settings"></param>
    /// <returns></returns>
    public PolicyBuilder AddSettings(Settings settings)
    {
        _template.settings = settings;
        return this;
    }

    /// <summary>
    /// Adds destinations to the policy
    /// </summary>
    /// <param name="destinations"></param>
    /// <returns></returns>
    public PolicyBuilder AddDestinations(Destinations destinations)
    {
        _template.destinations = destinations;
        return this;
    }

    /// <summary>
    /// Returns a configured instance of template class
    /// </summary>
    /// <returns></returns>
    public Template Build()
    {
        return _template;
    }
    #endregion
}
