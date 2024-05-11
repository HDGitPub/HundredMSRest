using System.IdentityModel.Tokens.Jwt;
using System.Text;
using HundredMSRest.Lib.Core.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace HundredMSRest.Lib.Core.Interfaces;

/// <summary>
/// Class <c>BaseTokenService</c> Base class for token services
/// </summary>
/// <param name="accessKey"></param>
/// <param name="secretKey"></param>
internal class BaseTokenService(string accessKey, string secretKey)
{
    #region Attributes
    private readonly string appAccessKey = accessKey;
    private readonly string appSecretKey = secretKey;
    #endregion

    #region Methods

    protected Token _GenerateToken(Dictionary<string, object> claims)
    {
        claims.Add("access_key", appAccessKey);
        claims.Add("jti", Guid.NewGuid().ToString());
        claims.Add("version", 2);

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
        return new Token(jwtToken);
    }
    #endregion
}
