using HundredMSRest.Lib.Api.V2.Common.DataTypes;

namespace HundredMSRest.Lib.Api.V2.RecordingAssets.DataTypes;

/// <summary>
/// Record <c>RecordingAssetList</c> A list of recording assets
/// </summary>
/// <param name="limit"></param>
/// <param name="data"></param>
/// <param name="last"></param>
public record RecordingAssetList(int limit, RecordingAsset[] data, string last);
