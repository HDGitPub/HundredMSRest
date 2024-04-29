namespace HundredMSRest.Tests;

using HundredMSRest.Lib.Services;
using HundredMSRest.Lib.Tokens;

/// <summary>
/// Class <c>TokenServiceTests</c> Tests management and authentication token generation
/// </summary>
public class TokenServiceTests : AuthenticatedTests
{
    [Fact]
    public void Get_ManagementToken_ReturnsToken()
    {
        ApiToken managementToken = new ManagementTokenService().GenerateToken();
        Assert.NotNull(managementToken);
    }
}
