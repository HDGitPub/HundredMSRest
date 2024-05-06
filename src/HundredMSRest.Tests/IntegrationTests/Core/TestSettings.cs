using HundredMSRest.Lib.Core.Services;
using Microsoft.Extensions.Configuration;

namespace HundredMSRest.Tests.IntegrationTests.Core;

/// <summary>
/// Class <c>TestSettings</c> base settings class for tests
/// </summary>
internal class TestSettings
{
    #region Attributes
    private const string APP_ACCESSKEY = "HundredMSRest:AppAccessKey";
    private const string APP_SECRETKEY = "HundredMSRest:AppSecretKey";
    protected readonly IConfiguration _configuration;
    #endregion

    #region Methods
    public TestSettings()
    {
        var builder = new ConfigurationBuilder().AddUserSecrets<TestSettings>();

        _configuration = builder.Build();
        TokenService.SetAppSecrets(_configuration[APP_ACCESSKEY], _configuration[APP_SECRETKEY]);
    }
    #endregion
}
