using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.ExternalStreams.Requests;

/// <summary>
/// Record <c>StartExternalStreamRequest</c>
/// </summary>
/// <param name="rtmp_urls"></param>
public record StartExternalStreamRequest(string[] rtmp_urls) : RequestRecord
{
    public string? meeting_url {get;set;}
    public bool? recording {get;set;}
    public Resolution? resolution {get;set;}
    public string? destination {get;set;}
}