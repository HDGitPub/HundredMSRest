﻿using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using HundredMSRest.Lib.Core.Common;
using HundredMSRest.Lib.Core.Interfaces;

namespace HundredMSRest.Lib.Core.Requests;

/// <summary>
/// Record <c>RequestRecord</c> is the base record for api request records
/// </summary>
public record RequestRecord : IRequestRecord
{
    private static readonly JsonSerializerOptions RecordSerializerOptions =
        new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            //PropertyNamingPolicy = new LowerCaseNamingPolicy()
        };

    /// <summary>
    /// Returns a JSON representation of the record
    /// </summary>
    /// <returns></returns>
    public string GetJSON()
    {
        return JsonSerializer.Serialize(this, this.GetType(), RecordSerializerOptions);
    }
}
