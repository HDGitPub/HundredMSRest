namespace HundredMSRest.Lib.Api.V2.ActiveRooms.DataTypes;

/// <summary>
/// Record <c>ActiveRoom</c>
/// </summary>
public record ActiveRoom
{
    /// <summary>
    /// Unique identifier for the room
    /// </summary>
    public string? id { get; set; }

    /// <summary>
    /// Alias for the room
    /// </summary>
    public string? name { get; set; }

    /// <summary>
    /// Unique identifier for your account
    /// </summary>
    public string? customer_id { get; set; }

    /// <summary>
    /// Object of type session.This object contains an array of the unique identifier of the peers.
    /// </summary>
    public object? session { get; set; }
}
