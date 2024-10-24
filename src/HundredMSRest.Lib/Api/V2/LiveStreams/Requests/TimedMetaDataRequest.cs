using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.LiveStreams.Requests;

/// <summary>
/// Record <c>TimedMetaDataRequest</c>
/// </summary>
/// <param name="payload"></param>
/// <param name="duration"></param>
public record TimedMetaDataRequest(string payload, int duration) : RequestRecord;