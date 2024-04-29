namespace HundredMSRest.Lib.Interfaces;

using HundredMSRest.Lib.Tokens;

/// <summary>
/// Interface <c>TokenService</c>
/// </summary>
internal interface ITokenService
{
    public ApiToken GenerateToken();
}
