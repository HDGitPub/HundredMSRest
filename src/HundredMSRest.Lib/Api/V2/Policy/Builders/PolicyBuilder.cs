using HundredMSRest.Lib.Api.V2.Policy.DataTypes;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

public sealed class PolicyBuilder
{
    #region Attributes
    private readonly Template _template;
    #endregion

    #region Methods
    public PolicyBuilder()
    {
        _template = new Template();
    }

    public PolicyBuilder AddName(string name)
    {
        _template.name = name;
        return this;
    }

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

    public PolicyBuilder AddSettings(Settings settings)
    {
        _template.settings = settings;
        return this;
    }

    public PolicyBuilder AddDestinations(Destinations destinations)
    {
        _template.destinations = destinations;
        return this;
    }

    public Template Build()
    {
        return _template;
    }
    #endregion
}
