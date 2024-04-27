namespace HundredMSRest.Lib.Records
{
    /// <summary>
    /// Room Record Type
    /// Represents a 100 MS room
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="enabled"></param>
    /// <param name="description"></param>
    /// <param name="customer_id"></param>
    /// <param name="app_id"></param>
    /// <param name="template_id"></param>
    /// <param name="template"></param>
    /// <param name="region"></param>
    /// <param name="created_at"></param>
    /// <param name="updated_at"></param>
    public record Room(string id,
        string name,
        bool enabled,
        string description,
        string customer_id,
        string app_id,
        string template_id,
        string template,
        string region,
        DateTime created_at,
        DateTime updated_at) : IRestResponseData
    {
        public void GetSomeData()
        {
            throw new NotImplementedException();
        }
    }
}
