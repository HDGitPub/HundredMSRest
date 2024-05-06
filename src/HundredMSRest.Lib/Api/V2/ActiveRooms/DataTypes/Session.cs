namespace HundredMSRest.Lib.Api.V2.ActiveRooms.DataTypes;

/// <summary>
/// Record <c>Session</c>
/// </summary>
public record Session
{
    /// <summary>
    /// Unique identifier for the session
    /// </summary>
    public string? id { get; set; }

    /// <summary>
    /// Timestamp when the session started
    /// </summary>
    public DateTime? created_at { get; set; }

    /// <summary>
    /// This object contains an array of the unique identifier of the peers
    /// </summary>
    public string[]? peers { get; set; }
}
