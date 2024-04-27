using HundredMSRest.Lib.Interfaces;

namespace HundredMSRest.Lib.Services
{
    /// <summary>
    /// Class <c>HundredMSManagementTokenProvider</c> Provides management tokens
    /// for connecting the 100MS Rest Api
    /// </summary>
    internal class HundredMSManagementTokenProvider : ITokenService
    {
        public IToken GenerateToken()
        {
            throw new NotImplementedException();
        }
    }
}
