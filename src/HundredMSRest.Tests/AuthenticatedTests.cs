namespace HundredMSRest.Tests;

using HundredMSRest.Lib.Core.Services;
using Microsoft.Extensions.Configuration;

/// <summary>
/// Class <c>AuthenticatedTests</c> Provides authentication info for unit tests
/// Use Developer credentials from development workspace.
/// </summary>
public class AuthenticatedTests
{
    #region Attributes

    private const string APP_ACCESSKEY = "HundredMSRest:AppAccessKey";
    private const string APP_SECRETKEY = "HundredMSRest:AppSecretKey";

    #endregion

    #region Methods
    public AuthenticatedTests()
    {
        var builder = new ConfigurationBuilder()
        .AddUserSecrets<AuthenticatedTests>();

        IConfiguration Configuration = builder.Build();
        ManagementTokenService.SetAppSecrets(Configuration[APP_ACCESSKEY],
                                             Configuration[APP_SECRETKEY]);
    }
    #endregion
}
