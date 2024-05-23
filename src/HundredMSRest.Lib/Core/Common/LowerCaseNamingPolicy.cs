using System.Text.Json;

namespace HundredMSRest.Lib.Core.Common;

public class LowerCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToLower();
}
