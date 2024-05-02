namespace HundredMSRest.Lib.Core.Tokens;

/// <summary>
/// Class <c>ManagementToken</c> is used to connect to the 100 MS rest API
/// to perform management API operations. The core token is a JSON Web Token
/// </summary>
internal class ManagementToken(string token) : ApiToken(token) { }
