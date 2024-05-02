using HundredMSRest.Lib.Core.Tokens;

namespace HundredMSRest.Lib.Core.Interfaces;

/// <summary>
/// Interface <c>TokenService</c>
/// </summary>
internal interface ITokenService
{
    public ApiToken GenerateToken();
}
