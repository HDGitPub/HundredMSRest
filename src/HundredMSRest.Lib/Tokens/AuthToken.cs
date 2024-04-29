namespace HundredMSRest.Lib.Tokens;

/// <summary>
/// Class <c>AuthToekn</c> is used for 100MS api Room Authentication only
/// <see href="https://www.100ms.live/docs/get-started/v2/get-started/security-and-tokens">Authentication Tokens</see>
/// </summary>
internal class AuthToken(string token) : ApiToken(token)
{
}
