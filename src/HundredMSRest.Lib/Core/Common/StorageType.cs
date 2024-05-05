namespace HundredMSRest.Lib.Core.Common;

/// <summary>
/// Class <c>StorageType</c> represents cloud provider storage types
/// </summary>
/// <param name="value"></param>
/// <param name="description"></param>
public class StorageType(string value, string description)
{
    #region statics
    public static StorageType S3 => new("s3", "Amazon web services Storage");
    public static StorageType GCP => new("gs", "Google cloud platform storage");
    public static StorageType ALIBABA => new("oss", "Alibaba Cloud storage");
    public static StorageType R2 => new("r2", "Cloudflare storage");
    #endregion

    #region Attributes
    #endregion

    #region Properties
    public string Value { get; } = value;
    public string Description { get; } = description;
    #endregion
}
