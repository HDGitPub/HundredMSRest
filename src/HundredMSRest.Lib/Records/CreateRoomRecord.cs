namespace HundredMSRest.Lib.Records
{
    public record CreateRoomRecord(string name, string description, string template_id) : IRestRequestData;
}
