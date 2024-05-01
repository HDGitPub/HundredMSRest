using HundredMSRest.Lib.Tokens;

namespace HundredMSRest.Lib.Interfaces;
/// <summary>
/// Interface <c>TokenService</c>
/// </summary>
internal interface ITokenService
{
    public ApiToken GenerateToken();
}
