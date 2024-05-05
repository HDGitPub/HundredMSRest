namespace HundredMSRest.Tests.IntegrationTests.Core;

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
    private const string APP_TEMPLATE_ID = "HundredMSRest:TemplateId";
    private const string ROOM_ID = "HundredMSRest:RoomId";
    private const string BUCKET = "HundredMSRest:Bucket";
    private const string BUCKET_ACCESSKEY = "HundredMSRest:BucketAccessKey";
    private const string BUCKET_SECRETKEY = "HundredMSRest:BucketSecretKey";
    private readonly IConfiguration _configuration;
    #endregion

    #region Methods
    public AuthenticatedTests()
    {
        var builder = new ConfigurationBuilder().AddUserSecrets<AuthenticatedTests>();

        _configuration = builder.Build();
        TokenService.SetAppSecrets(_configuration[APP_ACCESSKEY], _configuration[APP_SECRETKEY]);
    }

    public string TemplateId => _configuration[APP_TEMPLATE_ID];
    public string RoomId => _configuration[ROOM_ID];
    public string Bucket => _configuration[BUCKET];
    public string BucketAccessKey => _configuration[BUCKET_ACCESSKEY];
    public string BucketSecretKey => _configuration[BUCKET_SECRETKEY];
    #endregion
}
