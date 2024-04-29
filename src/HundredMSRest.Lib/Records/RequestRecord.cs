using System.Text.Json;

namespace HundredMSRest.Lib.Records;

/// <summary>
/// Record <c>RequestRecord</c> is the base record for room specific request records
/// </summary>
public record RequestRecord
{
    public string GetJSON() => JsonSerializer.Serialize(this);
}
