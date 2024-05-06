using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Rooms;

/// <summary>
///
/// </summary>
internal class RoomTestSettings : TestSettings
{
    #region Attributes
    private const string TEMPLATE_ID = "HundredMSRest:TemplateId";
    private const string ROOM_ID = "HundredMSRest:RoomId";
    private const string BUCKET = "HundredMSRest:Bucket";
    private const string BUCKET_ACCESSKEY = "HundredMSRest:BucketAccessKey";
    private const string BUCKET_SECRETKEY = "HundredMSRest:BucketSecretKey";
    #endregion

    #region Methods
    public RoomTestSettings()
    {
        RoomName = $"test-room-{DateTime.Now:hh-mm-ss}";
        RoomDescription = $"test-room-desc-{DateTime.Now:hh-mm-ss}";
    }
    #endregion

    #region Properties
    public string RoomName { get; }
    public string RoomDescription { get; }
    public string TemplateId => _configuration[TEMPLATE_ID];
    public string RoomId => _configuration[ROOM_ID];
    public string Bucket => _configuration[BUCKET];
    public string BucketAccessKey => _configuration[BUCKET_ACCESSKEY];
    public string BucketSecretKey => _configuration[BUCKET_SECRETKEY];
    #endregion
}
