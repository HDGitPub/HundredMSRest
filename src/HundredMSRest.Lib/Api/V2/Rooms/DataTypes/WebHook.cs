namespace HundredMSRest.Lib.Api.V2.Rooms.DataTypes;

/// <summary>
/// Record <c>WebHook</c>
/// </summary>
/// <param name="url"></param>
/// <param name="headers"></param>
public record WebHook
{
    public WebHook(string url)
    {
        this.url = url;
    }

    public string? url { get; set; }
    public Headers? headers { get; set; }
}
