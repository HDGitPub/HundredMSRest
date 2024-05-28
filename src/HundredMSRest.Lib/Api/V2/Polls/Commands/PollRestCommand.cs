using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.Polls.Commands;

/// <summary>
/// Class <c>PollRestCommand></c> Provides Polling functionality
/// </summary>
public sealed class PollRestCommand : RestCommand
{
    public PollRestCommand(string? urlParams = null, string? filterParams = null)
    {
        BuildBaseRoute("v2/polls", urlParams, filterParams);
    }
}
