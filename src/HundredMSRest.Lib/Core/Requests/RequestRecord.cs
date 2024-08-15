using System.Text.Json;
using System.Text.Json.Serialization;
using HundredMSRest.Lib.Core.Interfaces;

namespace HundredMSRest.Lib.Core.Requests;

/// <summary>
/// Record <c>RequestRecord</c> is the base record for api request records
/// </summary>
public record RequestRecord : IRequestRecord
{
    protected static readonly JsonSerializerOptions RecordSerializerOptions =
        new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

    /// <summary>
    /// Returns a JSON representation of the record
    /// </summary>
    /// <returns></returns>
    public virtual string GetJSON()
    {
        return JsonSerializer.Serialize(this, this.GetType(), RecordSerializerOptions);
    }
}
