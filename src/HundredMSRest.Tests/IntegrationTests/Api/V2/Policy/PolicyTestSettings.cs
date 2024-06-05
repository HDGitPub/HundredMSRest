using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Policy;

internal class PolicyTestSettings : TestSettings
{
    #region Attributes
    private const string BUCKET = "HundredMSRest:Policy:Bucket";
    private const string BUCKET_ACCESSKEY = "HundredMSRest:Policy:BucketAccessKey";
    private const string BUCKET_SECRETKEY = "HundredMSRest:Policy:BucketSecretKey";
    #endregion

    #region Methods
    public PolicyTestSettings()
    {
        TemplateName = $"test-template-{DateTime.Now:hh-mm-ss}";
    }
    #endregion

    #region Properties
    public string TemplateName { get; init; }
    public string Bucket => _configuration[BUCKET];
    public string BucketAccessKey => _configuration[BUCKET_ACCESSKEY];
    public string BucketSecretKey => _configuration[BUCKET_SECRETKEY];
    #endregion
}
