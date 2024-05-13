using HundredMSRest.Lib.Api.V2.Recordings.Constants;

namespace HundredMSRest.Lib.Api.V2.Recordings.Builders;

/// <summary>
///
/// </summary>
public sealed class OutputModesBuilder
{
    #region Attributes
    private readonly OutputModes _outputModes;
    #endregion

    #region Methods
    public OutputModesBuilder()
    {
        _outputModes = [];
    }

    /// <summary>
    /// Adds plain text output
    /// </summary>
    /// <returns></returns>
    public OutputModesBuilder AddPlainText()
    {
        _outputModes.Add("txt");
        return this;
    }

    /// <summary>
    /// Adds subrip output
    /// </summary>
    /// <returns></returns>
    public OutputModesBuilder AddSubRip()
    {
        _outputModes.Add("srt");
        return this;
    }

    /// <summary>
    /// Adds json output
    /// </summary>
    /// <returns></returns>
    public OutputModesBuilder AddJson()
    {
        _outputModes.Add("json");
        return this;
    }

    /// <summary>
    /// Returns a configured OutputModes object
    /// </summary>
    /// <returns></returns>
    public OutputModes Build()
    {
        return _outputModes;
    }
    #endregion
}
