using HundredMSRest.Lib.Interfaces;

namespace HundredMSRest.Lib.Tokens
{
    /// <summary>
    /// This class is used for Room Authentication
    /// https://www.100ms.live/docs/get-started/v2/get-started/security-and-tokens
    /// </summary>
    public class C100MSAuthToken : IHundredMSToken
    {
        public string GetToken()
        {
            throw new NotImplementedException();
        }

        public void SetToken(string value)
        {
            throw new NotImplementedException();
        }
    }
}
