using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
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

    public static async Task<Template?> CreateAsync(
        Template template,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand();
        return await command.RequestAsync<Template>(
            HttpMethod.Post,
            httpClient,
            cancellationToken: cancellationToken
        );
    }
}
