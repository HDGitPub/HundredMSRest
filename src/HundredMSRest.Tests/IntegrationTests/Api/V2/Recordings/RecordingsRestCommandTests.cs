using System.Text.Json;
using HundredMSRest.Lib.Api.V2.Recordings.Builders;
using HundredMSRest.Lib.Api.V2.Recordings.Constants;

namespace HundredMSRest.Tests.IntegrationTests.Api.V2.Recordings;

public class RecordingsRestCommandTests
{
    private readonly RecordingsTestSettings _settings;

    public RecordingsRestCommandTests()
    {
        _settings = new RecordingsTestSettings();
    }

    [Fact]
    public async void Get_Recording_ReturnsRecording()
    {
        // Arrange

        // Assert
    }
}
