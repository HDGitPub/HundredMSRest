﻿namespace HundredMSRest.Lib.Records.Room.DataTypes;
public record Room(string id,
string name,
bool enabled,
string description,
string customer_id,
bool recording_source_template,
RecordingInfo recording_info,
string template_id,
string template,
string region,
DateTime created_at,
string key,
DateTime updated_at,
bool large_room, int size,
int max_duration_seconds,
string[] polls,
WebHook webhook);
