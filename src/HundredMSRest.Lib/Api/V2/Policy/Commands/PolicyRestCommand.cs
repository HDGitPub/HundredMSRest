using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.Policy.Commands;

/// <summary>
/// Class <c>PolicyRestCommand></c> Provides Policy Template functionality
/// </summary>
public sealed class PolicyRestCommand : RestCommand
{
    public PolicyRestCommand(string? urlParams = null, string? filterParams = null)
    {
        BuildBaseRoute("v2/templates", urlParams, filterParams);
    }
}
