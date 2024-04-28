namespace HundredMSRest.Lib.Requests;

public class RestRequest
{
    #region Attributes
    protected string _route;
    #endregion

    #region Methods

    public RestRequest()
    {
    }

    public HttpMethod HttpMethod
    {
        get; set;
    }

    public void Request()
    {
        throw new NotImplementedException();
    }

    #endregion
}