using System.IdentityModel.Tokens.Jwt;
using System.Text;
using HundredMSRest.Lib.Core.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace HundredMSRest.Lib.Core.Services;

/// <summary>
/// Class <c>TokenService</c> Provides tokens to a server or client for use with the 100MS API
/// </summary>
public class TokenService
{
    #region Attributes
    private static string AppAccessKey = string.Empty;
    private static string AppSecretKey = string.Empty;
    #endregion

    /// <summary>
    /// Set top level api credentials. These values are used to generate
    /// management tokens. Insure that these values are stored securely.
    /// Server side code should retrieve these values from AWS Secrets manager
    /// or some similar secure storage and pass via this method.
    /// </summary>
    /// <param name="accessKey"></param>
    /// <param name="secretKey"></param>
    public static void SetAppSecrets(string accessKey, string secretKey)
    {
        AppAccessKey = accessKey;
        AppSecretKey = secretKey;
    }

    /// <summary>
    /// Returns an authentication token that can be used to join a 100ms room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="role"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    internal Token GetAuthToken(string roomId, string role, string userId)
    {
        var claims = new Dictionary<string, object>()
        {
            { "type", "app" },
            { "room_id", roomId },
            { "role", role },
            { "user_id", userId },
        };
        return _GenerateToken(claims);
    }

    /// <summary>
    /// Returns a management token that can be used to access the 100ms rest api
    /// </summary>
    /// <returns></returns>
    internal Token GetManagementToken()
    {
        var claims = new Dictionary<string, object>() { { "type", "management" } };
        return _GenerateToken(claims);
    }

    /// <summary>
    /// Utility method that generates JWT tokens
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    private Token _GenerateToken(Dictionary<string, object> claims)
    {
        claims.Add("access_key", AppAccessKey);
        claims.Add("jti", Guid.NewGuid().ToString());
        claims.Add("version", 2);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSecretKey));
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
}
