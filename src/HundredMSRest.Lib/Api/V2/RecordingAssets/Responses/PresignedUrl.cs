namespace HundredMSRest.Lib.Api.V2.RecordingAssets.Responses;

/// <summary>
/// Record <c>PresignedUrlResponse</c>
/// </summary>
public record PresignedUrl(string id, string path, string url, int expiry);
