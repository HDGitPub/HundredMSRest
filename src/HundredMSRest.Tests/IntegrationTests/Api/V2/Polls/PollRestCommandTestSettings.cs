using HundredMSRest.Tests.IntegrationTests.Core;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Polls;

internal class PollRestCommandTestSettings : TestSettings
{
    #region Attributes
    private const string POLL_ID = "HundredMSRest:Poll:Id";
    private const string RESPONSE_ID = "HundredMSRest:Poll:ResponseId";
    private const string RESULT_ID = "HundredMSRest:Poll:ResultId";
    #endregion

    #region Methods
    public PollRestCommandTestSettings() { }
    #endregion

    #region Properties
    public string PollId => _configuration[POLL_ID];
    public string ResponseId => _configuration[RESPONSE_ID];
    public string ResultId => _configuration[RESULT_ID];
    #endregion
}
