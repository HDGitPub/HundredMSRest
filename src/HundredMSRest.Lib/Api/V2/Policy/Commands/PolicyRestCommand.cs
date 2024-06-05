using HundredMSRest.Lib.Api.V2.Policy.DataTypes;
using HundredMSRest.Lib.Core.Commands;

namespace HundredMSRest.Lib.Api.V2.Policy.Commands;

/// <summary>
/// Class <c>PolicyRestCommand></c> Provides Policy Template functionality
/// </summary>
public sealed class PolicyRestCommand : RestCommand
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="urlParams"></param>
    /// <param name="filterParams"></param>
    public PolicyRestCommand(string? urlParams = null, string? filterParams = null)
    {
        BuildBaseRoute("v2/templates", urlParams, filterParams);
    }

    /// <summary>
    /// Creates a new policy template
    /// </summary>
    /// <param name="template"></param>
    /// <param name="httpClient"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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
            requestRecord: template,
            cancellationToken: cancellationToken
        );
    }
}
