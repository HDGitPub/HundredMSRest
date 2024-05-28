using HundredMSRest.Lib.Api.V2.Common.DataTypes;
using HundredMSRest.Lib.Api.V2.Recordings.Constants;

namespace HundredMSRest.Lib.Api.V2.Recordings.Builders;

/// <summary>
/// Class <c>TranscriptionBuilder</c> builds transcriptions
/// </summary>
public sealed class TranscriptionBuilder
{
    #region Attributes
    private readonly Transcription _transcription;
    #endregion

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    public TranscriptionBuilder()
    {
        _transcription = new Transcription();
    }

    /// <summary>
    /// Adds enabled
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public TranscriptionBuilder AddEnabled(bool enabled)
    {
        _transcription.enabled = enabled;
        return this;
    }

    /// <summary>
    /// Adds output modes. Values can be txt, srt, or json
    /// </summary>
    /// <param name="outputModes"></param>
    /// <returns></returns>
    public TranscriptionBuilder AddOutputModes(OutputModes outputModes)
    {
        _transcription.output_modes = outputModes;
        _transcription.outputModes = outputModes;
        return this;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="vocabulary"></param>
    /// <returns></returns>
    public TranscriptionBuilder AddCustomVocabulary(string[] vocabulary)
    {
        _transcription.custom_vocabulary = vocabulary;
        _transcription.customVocabulary = vocabulary;
        return this;
    }

    /// <summary>
    /// Adds a transcription summary
    /// </summary>
    /// <param name="enabled"></param>
    /// <param name="context"></param>
    /// <param name="temparature"></param>
    /// <returns></returns>
    public TranscriptionBuilder AddSummary(bool enabled, string context, float temparature)
    {
        _transcription.summary = new Summary()
        {
            enabled = enabled,
            context = context,
            temperature = temparature
        };

        return this;
    }

    /// <summary>
    /// Adds a section to the summary
    /// </summary>
    /// <param name="title"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public TranscriptionBuilder AddSection(string title, string format)
    {
        if (_transcription.summary is null)
            throw new Exception("Summary is required before adding sections");

        _transcription.summary.sections ??= [];
        _transcription.summary.sections = _transcription.summary.sections.Append<Section>(
            new Section(title, format)
        );

        return this;
    }
    #endregion
}
