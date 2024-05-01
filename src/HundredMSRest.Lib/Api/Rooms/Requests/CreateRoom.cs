using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.Rooms.Requests;

/// <summary>
/// Record <c>CreateRoom</c> contains params for room creation
/// </summary>
/// <param name="name"></param>
/// <param name="description"></param>
/// <param name="template_id"></param>
public record CreateRoom(string name, string description, string template_id) : RequestRecord;
