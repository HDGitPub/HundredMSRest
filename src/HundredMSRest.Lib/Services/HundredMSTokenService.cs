using HundredMSRest.Lib.Enums;
using HundredMSRest.Lib.Interfaces;

namespace HundredMSRest.Lib.Services
{
    /// <summary>
    /// Class <c>C100MSTokenService</c> Provides tokens to a server or client for use with the 100MS API
    /// </summary>
    public class HundredMSTokenService
    {
        /// <summary>
        /// Returns either an Authentication Token that can be used to join a room. Or returns
        /// a Management token that is used to access the 100MS rest api.
        /// </summary>
        /// <param name="tokenType">Requested Token Type</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IHundredMSToken GetToken(HundredMSTokenType tokenType)
        {
            return tokenType switch
            {
                HundredMSTokenType.Authentication => new C100MSAuthTokenProvider().GenerateToken(),
                HundredMSTokenType.Management => new C100MSManagementTokenProvider().GenerateToken(),
                _ => throw new Exception("Invalid token type request")
            };
        }
    }
}
