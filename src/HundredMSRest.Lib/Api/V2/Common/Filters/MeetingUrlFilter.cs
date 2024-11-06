using System.Text;

namespace HundredMSRest.Lib.Api.V2.Common.Filters;

/// <summary>
/// Class <c>MeetingUrlFilter</c>
/// </summary>
public sealed class MeetingUrlFilter
{
    #region Attributes
    private bool? _skipPreview { get; set; }
    private bool? _skipPreviewHeadful { get; set; }
    private string? _authToken { get; set; }
    private string? _uiMode { get; set; }
    private string? _name { get; set; }
    #endregion

    #region Methods
    public string Filter()
    {
        var builder = new StringBuilder("?");
        if (_skipPreview is not null)
        {
            builder.Append($"skip_preview={_skipPreview?.ToString().ToLower()}&");
        }
        if (_skipPreviewHeadful is not null)
        {
            builder.Append($"skip_preview_headful={_skipPreviewHeadful?.ToString().ToLower()}&");
        }
        if (_authToken is not null)
        {
            builder.Append($"auth_token={_authToken}&");
        }
        if (_uiMode is not null)
        {
            builder.Append($"ui_mode={_uiMode}&");
        }
        if (_name is not null)
        {
            builder.Append($"name={_name}&");
        }
        return builder.ToString().TrimEnd('&');
    }

    public MeetingUrlFilter AddSkipPreview(bool skipPreview)
    {
        this._skipPreview = skipPreview;
        return this;
    }

    public MeetingUrlFilter AddSkipPreviewHeadful(bool skipPreviewHeadful)
    {
        _skipPreviewHeadful = skipPreviewHeadful;
        return this;
    }

    public MeetingUrlFilter AddAuthToken(string authToken)
    {
        _authToken = authToken;
        return this;
    }

    public MeetingUrlFilter AddUIMode(string uiMode)
    {
        _uiMode = uiMode;
        return this;
    }

    public MeetingUrlFilter AddName(string name)
    {
        _name = name;
        return this;
    }
    #endregion
}
