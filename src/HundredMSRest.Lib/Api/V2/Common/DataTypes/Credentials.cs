using System.Runtime.InteropServices;

namespace HundredMSRest.Lib.Api.V2.Common.DataTypes;

/// <summary>
/// Record <c>Credentials</c> Cloud provider recording auth credentials
/// </summary>
/// <param name="key"></param>
public record Credentials(string key)
{
    public string? secret { get; set; }
    public string? secretKey { get; set; }
}
