﻿using HundredMSRest.Lib.Api.Rooms.DataTypes;
using HundredMSRest.Lib.Core.Requests;

namespace HundredMSRest.Lib.Api.Rooms.Requests;

/// <summary>
/// Record <c>UpdateRoomRequest</c>
/// </summary>
public record UpdateRoomRequest : RequestRecord
{
    public string? name { get; set; }
    public string? description { get; set; }
    public RecordingInfo? recording_info { get; set; }
}
