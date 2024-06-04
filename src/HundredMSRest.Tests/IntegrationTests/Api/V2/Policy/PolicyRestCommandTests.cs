using HundredMSRest.Lib.Api.V2.Policy.Commands;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Policy;

public class PolicyRestCommandTests
{
    private readonly PolicyTestSettings _settings;

    public PolicyRestCommandTests()
    {
        _settings = new PolicyTestSettings();
    }

    [Fact]
    public async Task Create_Policy_ReturnsPolicy()
    {
        PolicyRestCommand.CreateAsync();
    }
}