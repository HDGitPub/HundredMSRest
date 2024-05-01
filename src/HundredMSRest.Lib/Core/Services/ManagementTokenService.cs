using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using HundredMSRest.Lib.Core.Interfaces;
using HundredMSRest.Lib.Core.Tokens;

namespace HundredMSRest.Lib.Core.Services;
/// <summary>
/// Class <c>ManagementTokenService</c> Provides management tokens
/// for connecting the 100MS Rest Api. These tokens should never be
/// exposed to client applications.
/// </summary>
public class ManagementTokenService : ITokenService
{
    #region Attributes
    private static string AppAccessKey;
    private static string AppSecretKey;
    #endregion

    #region Methods
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
    /// Generates management tokens for use with the 100MS
    /// rest API
    /// </summary>
    /// <see href="https://www.100ms.live/docs/get-started/v2/get-started/security-and-tokens#set-up-your-token-server">100 MS Token Server</see>
    /// <returns>A management token in IToken format</returns>
    public ApiToken GenerateToken()
    {
        //Map<String, Object> payload = new HashMap<>();
        //payload.put("access_key", "12345");
        //payload.put("type", "management");
        //payload.put("version", 2);
        //String token = Jwts.builder().setClaims(payload).setId(UUID.randomUUID().toString())
        //    .setExpiration(new Date(System.currentTimeMillis() + 86400 * 1000))
        //    .setIssuedAt(Date.from(Instant.ofEpochMilli(System.currentTimeMillis() - 60000)))
        //    .setNotBefore(new Date(System.currentTimeMillis()))
        //    .signWith(SignatureAlgorithm.HS256, "67890".getBytes()).compact();
        //var subject = new ClaimsIdentity(new[]
        //{
        //    new Claim("access_key", AppAccessKey),
        //    new Claim("type", "management"),
        //    new Claim("version","2"),
        //    new Claim("jti",Guid.NewGuid().ToString())
        //});
        var claims = new Dictionary<string, object>()
        {
            {"access_key", AppAccessKey},
            {"type", "management"},
            {"version", 2},
            {"jti", Guid.NewGuid().ToString()},
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSecretKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Claims = claims,
            Expires = DateTime.UtcNow.AddDays(1),// 86400 seconds = 1 day
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
