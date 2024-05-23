namespace HundredMSRest.Lib.Api.V2.RoomCodes.DataTypes;

/// <summary>
/// Record <c>RoomCode</c> RoomCode record
/// </summary>
public record RoomCode
{
    public string? code { get; set; }
    public string? room_id { get; set; } 
    public string? role { get; set; }
    public bool? enabled { get; set; } = false;
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set;}
}