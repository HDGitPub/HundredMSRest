using System.IdentityModel.Tokens.Jwt;
using System.Text;
using HundredMSRest.Lib.Core.Interfaces;
using HundredMSRest.Lib.Core.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace HundredMSRest.Lib.Core.Services;

/// <summary>
/// Class <c>ManagementTokenService</c> Provides management tokens
/// for connecting the 100MS Rest Api. These tokens should never be
/// exposed to client applications.
/// </summary>
internal class ManagementTokenService(string accessKey, string secretKey) : ITokenService
{
    #region Attributes
    private readonly string appAccessKey = accessKey;
    private readonly string appSecretKey = secretKey;
    #endregion

    #region Methods

    /// <summary>
    /// Generates management tokens for use with the 100MS
    /// rest API
    /// </summary>
    /// <see href="https://www.100ms.live/docs/get-started/v2/get-started/security-and-tokens#set-up-your-token-server">100 MS Token Server</see>
    /// <returns>A management token in IToken format</returns>
    public ApiToken GenerateToken()
    {
        var claims = new Dictionary<string, object>()
        {
            { "access_key", appAccessKey },
            { "type", "management" },
            { "version", 2 },
            { "jti", Guid.NewGuid().ToString() },
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSecretKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Claims = claims,
            Expires = DateTime.UtcNow.AddDays(1), // 86400 seconds = 1 day
            IssuedAt = DateTime.UtcNow,
            NotBefore = DateTime.UtcNow,
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        return new ManagementToken(jwtToken);
    }
    #endregion
}
