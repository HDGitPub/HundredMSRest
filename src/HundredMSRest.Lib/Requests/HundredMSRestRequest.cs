namespace HundredMSRest.Lib.Requests
{
    public class HundredMSRequest
    {
        #region Attributes
        protected string _route;
        #endregion

        #region Methods
        public C100MSRequest()
        {
        }

        public HttpMethod HttpMethod
        {
            get;set;
        }

        #endregion
    }
}