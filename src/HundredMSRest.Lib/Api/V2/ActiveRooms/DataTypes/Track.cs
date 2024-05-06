using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundredMSRest.Lib.Api.V2.ActiveRooms.DataTypes;

/// <summary>
/// Record <c>Track</c> Peer audio / video track
/// </summary>
public record Track
{
    public string? id { get; set; }
    public string? stream_id { get; set; }
    public bool? mute { get; set; }
    public string? type { get; set; }
    public string? source { get; set; }
    public string? started_at { get; set; }
    public string? description { get; set; }
}
