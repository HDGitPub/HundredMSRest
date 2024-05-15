using HundredMSRest.Lib.Api.V2.Common.Constants;

namespace HundredMSRest.Lib.Api.V2.Common.Builders;

/// <summary>
/// Class <c>AssetsTypeBuilder</c> builds an AssetsType
/// </summary>
public sealed class AssetsTypeBuilder
{
    #region Attributes
    private readonly AssetTypes _assetTypes;
    #endregion

    #region Methods
    /// <summary>
    /// Constructor
    /// </summary>
    public AssetsTypeBuilder()
    {
        _assetTypes = [];
    }

    /// <summary>
    /// Adds room-composite asset type
    /// </summary>
    /// <returns></returns>
    public AssetsTypeBuilder AddComposite()
    {
        _assetTypes.Add(AssetType.ROOM_COMPOSITE);
        return this;
    }

    /// <summary>
    /// Adds composite asset type
    /// </summary>
    /// <returns></returns>
    public AssetsTypeBuilder AddVod()
    {
        _assetTypes.Add(AssetType.ROOM_VOD);
        return this;
    }

    /// <summary>
    /// Adds chat asset type
    /// </summary>
    /// <returns></returns>
    public AssetsTypeBuilder AddChat()
    {
        _assetTypes.Add(AssetType.CHAT);
        return this;
    }

    /// <summary>
    /// Adds summary asset type
    /// </summary>
    /// <returns></returns>
    public AssetsTypeBuilder AddSummary()
    {
        _assetTypes.Add(AssetType.SUMMARY);
        return this;
    }

    /// <summary>
    /// Adds transcript asset type
    /// </summary>
    /// <returns></returns>
    public AssetsTypeBuilder AddTranscript()
    {
        _assetTypes.Add(AssetType.TRANSCRIPT);
        return this;
    }

    /// <summary>
    /// Returns a configured AssetsType object
    /// </summary>
    /// <returns></returns>
    public AssetTypes Build()
    {
        return _assetTypes;
    }
    #endregion
}
