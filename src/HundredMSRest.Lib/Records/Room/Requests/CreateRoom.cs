namespace HundredMSRest.Lib.Records.Room.Requests;

/// <summary>
/// Record <c>CreateRoom</c> contains params for room creation
/// </summary>
/// <param name="name"></param>
/// <param name="description"></param>
/// <param name="template_id"></param>
public record CreateRoom(string name, string description, string template_id) : RequestRecord;
