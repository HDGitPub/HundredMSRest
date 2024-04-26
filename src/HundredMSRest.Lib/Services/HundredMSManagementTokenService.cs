using HundredMSRest.Lib.Interfaces;

namespace HundredMSRest.Lib.Services
{
    /// <summary>
    /// Class <c>C100MSManagementTokenProvider</c> Provides management tokens
    /// for connecting the 100MS Rest Api
    /// </summary>
    public class HundredMSManagementTokenProvider : IHundredMSTokenService
    {
        public IHundredMSToken GenerateToken()
        {
            throw new NotImplementedException();
        }
    }
}
