using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.V2.Sessions.Requests;

/// <summary>
/// Class <c>SessionsRequest</c>
/// </summary>
public record SessionsRequest : RequestRecord
{
    /// <summary>
    /// Flag to fetch the list of active room sessions.
    /// </summary>
    public bool? active {get;set;}

    /// <summary>
    /// etch the list of sessions created in the room specified.
    /// </summary>
    public string? room_id {get;set;}

    /// <summary>
    /// Check for sessions started with a timestamp greater than or equal to "after"
    /// </summary>
    public string? after{get;set;}
    /// <summary>
    /// Check for sessions started with a timestamp less than or equal to "after"
    /// </summary>
    public string? before {get;set;}

    /// <summary>
    /// Determines the number of session objects to be included in response.
    /// Allowed values: Min: 10, Max: 100
    /// </summary>
    public int? limit {get;set;} = 10;
}