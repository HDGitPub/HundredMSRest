using HundredMSRest.Lib.Enums;
using HundredMSRest.Lib.Interfaces;
using HundredMSRest.Lib.Providers;

namespace HundredMSRest.Lib.Services
{
    /// <summary>
    /// Class <c>TokenService</c> Provides tokens to a server or client for use with the 100MS API
    /// </summary>
    internal class HundredMSTokenService
    {
        /// <summary>
        /// Returns either an Authentication Token that can be used to join a room. Or returns
        /// a Management token that is used to access the 100MS rest api.
        /// </summary>
        /// <param name="tokenType">Requested Token Type</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IToken GetToken(HundredMSTokenType tokenType)
        {
            return tokenType switch
            {
                HundredMSTokenType.Authentication => new AuthTokenProvider().GenerateToken(),
                HundredMSTokenType.Management => new ManagementTokenProvider().GenerateToken(),
                _ => throw new Exception("Invalid token type request")
            };
        }
    }
}
