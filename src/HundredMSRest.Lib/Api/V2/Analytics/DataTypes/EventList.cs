namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Record <c>EventList</c>
/// </summary>
public record EventList<T>
{
    public int limit { get; set; }
    public int total { get; set; }
    public string? next { get; set; }
    public IEnumerable<EventResponse<T>>? events { get; set; }
}
