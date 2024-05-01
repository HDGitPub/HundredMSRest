namespace HundredMSRest.Lib.Core.Tokens;

/// <summary>
/// Base Class <c>ApiToken</c> is the base token for
/// Authentication and Mangement tokens
/// </summary>
/// <remarks>
/// Constructor that takes a json web token in string format
/// </remarks>
/// <param name="token"></param>
public class ApiToken(string token)
{
    /// <summary>
    /// Get a reference to the json web token string
    /// </summary>
    public string Token { get; } = token;
}