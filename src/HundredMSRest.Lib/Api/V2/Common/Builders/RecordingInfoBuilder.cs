using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Core.Common;

namespace HundredMSRest.Lib.Api.V2.Common.Builders;

/// <summary>
/// Class <c>RecordingInfoBuilder</c> Builds RecordingInfo configuration class
/// </summary>
public sealed class RecordingInfoBuilder
{
    #region Attributes
    private readonly RecordingInfo _recordingInfo;
    #endregion

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    public RecordingInfoBuilder()
    {
        _recordingInfo = new RecordingInfo();
    }

    /// <summary>
    /// Enabled
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public RecordingInfoBuilder SetEnabled(bool enabled)
    {
        _recordingInfo.enabled = enabled;
        return this;
    }

    /// <summary>
    /// Adds cloud provider config
    /// </summary>
    /// <param name="type"></param>
    /// <param name="location"></param>
    /// <param name="prefix"></param>
    /// <param name="region"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public RecordingInfoBuilder AddUploadInfo(
        StorageType type,
        string location,
        string? prefix = null,
        string? accountId = null,
        string? region = null
    )
    {
        var uploadInfo = new UploadInfo(type.Value, location) { prefix = prefix };

        if (accountId is not null || region is not null)
        {
            uploadInfo.options = new Options { region = region, account_id = accountId };
        }

        _recordingInfo.upload = uploadInfo;

        if (
            _recordingInfo.upload.type == StorageType.S3.Value
            && _recordingInfo.upload.options is null
        )
        {
            throw new Exception(Strings.ROOM_INVALID_UPLOAD_S3_CONFIG);
        }
        return this;
    }

    /// <summary>
    /// Adds cloud storage provider secrets
    /// </summary>
    /// <param name="key"></param>
    /// <param name="secret"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public RecordingInfoBuilder AddCredentials(string key, string secretKey)
    {
        if (_recordingInfo?.upload is null)
            throw new Exception(Strings.ROOM_INVALID_CREDENTIALS_CONFIG);

        _recordingInfo.upload.credentials = new Credentials(key) { secretKey = secretKey };
        return this;
    }

    /// <summary>
    /// Returns instance of RecordingInfo
    /// </summary>
    /// <returns></returns>
    public RecordingInfo Build()
    {
        return _recordingInfo;
    }
    #endregion
}
