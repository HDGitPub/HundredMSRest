namespace HundredMSRest.Lib.Services;

using HundredMSRest.Lib.Enums;
using HundredMSRest.Lib.Tokens;

/// <summary>
/// Class <c>TokenService</c> Provides tokens to a server or client for use with the 100MS API
/// </summary>
internal class TokenService
{
    /// <summary>
    /// Returns either an Authentication Token that can be used to join a room. Or returns
    /// a Management token that is used to access the 100MS rest api.
    /// </summary>
    /// <param name="tokenType">Requested Token Type</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public ApiToken GetToken(TokenType tokenType)
    {
        return tokenType switch
        {
            TokenType.Authentication => new AuthTokenService().GenerateToken(),
            TokenType.Management => new ManagementTokenService().GenerateToken(),
            _ => throw new Exception("Invalid token type request")
        };
    }
}