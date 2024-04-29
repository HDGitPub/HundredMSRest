namespace HundredMSRest.Lib.Records;

/// <summary>
/// Record <c>CreateRoomRecord</c> contains params for room creation
/// </summary>
/// <param name="name"></param>
/// <param name="description"></param>
/// <param name="template_id"></param>
public record CreateRoomRecord(string name, string description, string template_id) : RequestRecord;
