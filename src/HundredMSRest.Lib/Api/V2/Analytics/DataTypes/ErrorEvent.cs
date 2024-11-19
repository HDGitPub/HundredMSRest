namespace HundredMSRest.Lib.Api.V2.Analytics.DataTypes;

/// <summary>
/// Record <c>ErrorEvent</c>
/// </summary>
public record ErrorEvent : Event
{
    public string? user_id { get; set; }
    public string? user_name { get; set; }
    public string? account_id { get; set; }
    public string? room_name { get; set; }
    public string? template_id { get; set; }
    public string? role { get ; set;}
    public string? error_code { get; set; }
    public string? error_name { get; set; }
    public string? error_message {get; set; }
    public string? error_description { get; set; }
    public string? domain { get; set; }
    public bool? is_terminal { get; set; }
    public string? action { get; set; }
    public Audio? audio { get; set; }
    public Video? video { get; set; }
    public Devices? devices { get; set; }
    public Agent? agent { get; set; }
}