namespace HundredMSRest.Lib.Interfaces;

/// <summary>
/// Interface <c>ITokenProvider</c>
/// </summary>
internal interface ITokenProvider
{
    IToken GenerateToken();
}
