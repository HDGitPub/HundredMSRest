using HundredMSRest.Lib.Core.Enums;
using HundredMSRest.Lib.Core.Tokens;

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
    /// Returns either an Authentication Token that can be used to join a room. Or returns
    /// a Management token that is used to access the 100MS rest api.
    /// </summary>
    /// <param name="tokenType">Requested Token Type</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    internal ApiToken GetToken(TokenType tokenType)
    {
        return tokenType switch
        {
            TokenType.Authentication => new AuthTokenService().GenerateToken(),
            TokenType.Management
                => new ManagementTokenService(AppAccessKey, AppSecretKey).GenerateToken(),
            _ => throw new Exception("Invalid token type request")
        };
    }
}
