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
    /// Retrieve a template
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    public static async Task<Template?> GetAsync(
        string templateId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand(templateId);
        return await command.RequestAsync<Template>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Lists templates
    /// </summary>
    /// <returns></returns>
    public static async Task<TemplateList?> ListAsync(
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand();
        return await command.RequestAsync<TemplateList>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
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

    /// <summary>
    /// Updates a template
    /// </summary>
    /// <param name="template"></param>
    /// <returns></returns>
    public static async Task<Template?> UpdateAsync(
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

    /// <summary>
    /// Retrieve a role
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    public static async Task<Role?> GetRoleAsync(
        string templateId,
        string roleName,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand($"{templateId}/roles/{roleName}");
        return await command.RequestAsync<Role>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Updates a role
    /// </summary>
    /// <param name="templateId"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public static async Task<Role?> UpdateRoleAsync(
        string templateId,
        Role role,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand($"{templateId}/roles/{role.name}");
        return await command.RequestAsync<Role>(
            HttpMethod.Post,
            httpClient,
            requestRecord: role,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Deletes a role
    /// </summary>
    /// <param name="templateId"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public static async Task<bool> DeleteRoleAsync(
        string templateId,
        string roleName,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand($"{templateId}/roles/{roleName}");
        await command.RequestAsync(
            HttpMethod.Delete,
            httpClient,
            cancellationToken: cancellationToken
        );
        return true;
    }

    /// <summary>
    /// Retrieves template settings
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    public static async Task<Settings?> GetSettingsAsync(
        string templateId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand($"{templateId}/settings");
        return await command.RequestAsync<Settings>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Updates template settings
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    public static async Task<Settings?> UpdateSettingsAsync(
        string templateId,
        Settings settings,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand($"{templateId}/settings");
        return await command.RequestAsync<Settings>(
            HttpMethod.Post,
            httpClient,
            requestRecord: settings,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Gets template destinations
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    public static async Task<Destinations?> GetDestinationsAsync(
        string templateId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand($"{templateId}/destinations");
        return await command.RequestAsync<Destinations>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Update template destinations
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    public static async Task<Destinations?> UpdateDestinationsAsync(
        string templateId,
        Destinations destinations,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand($"{templateId}/destinations");
        return await command.RequestAsync<Destinations>(
            HttpMethod.Post,
            httpClient,
            requestRecord: destinations,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Update template recording configuration
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    public static async Task<TemplateRecording?> UpdateRecordingAsync(
        string templateId,
        TemplateRecording templateRecording,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand($"{templateId}/recordings");
        return await command.RequestAsync<TemplateRecording>(
            HttpMethod.Post,
            httpClient,
            requestRecord: templateRecording,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Returns current template recording configuration
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    public static async Task<TemplateRecording?> GetRecordingAsync(
        string templateId,
        HttpClient? httpClient = null,
        CancellationToken cancellationToken = default
    )
    {
        var command = new PolicyRestCommand($"{templateId}/recordings");
        return await command.RequestAsync<TemplateRecording>(
            HttpMethod.Get,
            httpClient,
            cancellationToken: cancellationToken
        );
    }
}
