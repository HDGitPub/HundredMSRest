using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Policy;

internal class PolicyTestSettings : TestSettings
{
    #region Attributes
    private const string BUCKET = "HundredMSRest:Policy:Bucket";
    private const string BUCKET_ACCESSKEY = "HundredMSRest:Policy:BucketAccessKey";
    private const string BUCKET_SECRETKEY = "HundredMSRest:Policy:BucketSecretKey";
    private const string TEMPLATE_ID = "HundredMSRest:Policy:TemplateId";
    private const string ROLE_NAME = "HundredMSRest:Policy:RoleName";
    private const string MAX_PEER_COUNT = "HundredMSRest:Policy:MaxPeerCount";
    private const string ACCOUNT_ID = "HundredMSRest:Policy:AccountId";
    #endregion

    #region Methods
    public PolicyTestSettings()
    {
        TemplateName = $"test-template-{DateTime.Now:hh-mm-ss}";
    }
    #endregion

    #region Properties
    public string TemplateName { get; init; }
    public string TemplateId => _configuration[TEMPLATE_ID];
    public string RoleName => _configuration[ROLE_NAME];
    public string Bucket => _configuration[BUCKET];
    public int MaxPeerCount => int.Parse(_configuration[MAX_PEER_COUNT]);
    public string BucketAccessKey => _configuration[BUCKET_ACCESSKEY];
    public string BucketSecretKey => _configuration[BUCKET_SECRETKEY];
    public string AccountId => _configuration[ACCOUNT_ID];
    #endregion
}
