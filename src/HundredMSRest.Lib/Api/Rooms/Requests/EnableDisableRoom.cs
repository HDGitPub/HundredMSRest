using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.Rooms.Requests;
public record EnableDisableRoom : RequestRecord
{
    public bool enabled { get; set; }
}
