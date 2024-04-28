using HundredMSRest.Lib.Interfaces;

namespace HundredMSRest.Lib.Services
{
    /// <summary>
    /// Class <c>ManagementTokenService</c> Provides management tokens
    /// for connecting the 100MS Rest Api. These tokens should never be
    /// exposed to client applications.
    /// </summary>
    internal class ManagementTokenService : ITokenService
    {
        #region Attributes
        private static string AppAccessKey;
        private static string AppSecretKey;
        #endregion

        /// <summary>
        /// Set top level api credentials. These values are used to generate
        /// management tokens. Insure that these values are stored securely. 
        /// Server side code should retrieve these values from AWS Secrets manager 
        /// or some similar secure storage and pass via this method.
        /// </summary>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        public static void SetAppSecrets(string accessKey,string secretKey)
        {
            AppAccessKey = accessKey;
            AppSecretKey = secretKey;
        }

        public IToken GenerateToken()
        {
        }
    }
}
