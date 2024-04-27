using HundredMSRest.Lib.Records;

namespace HundredMSRest.Lib.Requests
{
    /// <summary>
    /// Represents rest commands that are sent to the 100 MS Api
    /// </summary>
    public class RestCommand
    {
        #region Attributes

        protected readonly IRestRequestData? _data;
        protected readonly HttpMethod _httpMethod;

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">Request data to pass to the 100MS Api</param>
        public RestCommand(IRestRequestData? data,HttpMethod httpMethod)
        {
            _data = data;
            _httpMethod = httpMethod;
        }

        /// <summary>
        /// Returns IRestRequestData
        /// </summary>
        /// <returns>IRestRequestData data</returns>
        public IRestRequestData? Data
        {
            get
            {
                return _data;
            }
        }

        public HttpMethod HttpMethod
        {
            get
            {
                return _httpMethod;
            }
        }

        #endregion

    }
}
