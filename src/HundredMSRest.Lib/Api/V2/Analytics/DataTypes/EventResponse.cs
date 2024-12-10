namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Class <c>EventResponse</c>
/// </summary>
/// <typeparam name="T"></typeparam>
public class EventResponse<T>
{
    public string? version { get; set; }
    public string? id { get; set; }
    public string? timestamp { get; set; }
    public string? type { get; set; }
    public T? data { get; set; }
}
