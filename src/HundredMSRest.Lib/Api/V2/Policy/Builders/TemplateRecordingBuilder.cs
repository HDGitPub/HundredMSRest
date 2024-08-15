using System.Runtime.InteropServices;
using HundredMSRest.Lib.Api.V2.Policy.DataTypes;

namespace HundredMSRest.Lib.Api.V2.Policy.Builders;

/// <summary>
/// Class <c>TemplateRecordingBuilder</c> Builds a template recording
/// </summary>
public sealed class TemplateRecordingBuilder
{
    #region Attributes
    private readonly TemplateRecording _templateRecording;
    #endregion

    #region Methods

    public TemplateRecordingBuilder(string name, string role)
    {
        _templateRecording = new TemplateRecording(name, role);
    }

    public TemplateRecordingBuilder AddMaxDuration(int maxDuration)
    {
        _templateRecording.maxDuration = maxDuration;
        return this;
    }

    public TemplateRecordingBuilder AddPresignDuration(int presignDuration)
    {
        _templateRecording.presignDuration = presignDuration;
        return this;
    }

    public TemplateRecordingBuilder AddThumbnails(
        int width,
        int height,
        int[]? offsets = null,
        int? fps = null
    )
    {
        _templateRecording.thumbnails = new Thumbnails
        {
            width = width,
            height = height,
            offsets = offsets,
            fps = fps
        };
        return this;
    }

    public TemplateRecordingBuilder AddCompositeRecording(
        bool custom,
        bool browser,
        bool autoStart,
        int autoStopTimeout,
        int width,
        int height
    )
    {
        _templateRecording.compositeRecording = new CompositeRecording
        {
            customComposite = custom ? new CustomComposite() { enabled = true } : null,
            browserComposite = browser
                ? new BrowserComposite()
                {
                    autoStart = autoStart,
                    autoStopTimeout = autoStopTimeout,
                    height = height,
                    width = width
                }
                : null
        };
        return this;
    }

    public TemplateRecordingBuilder AddTrackRecording(bool enabled)
    {
        _templateRecording.trackRecording = new TrackRecording() { enabled = enabled };
        return this;
    }

    public TemplateRecordingBuilder AddStreamRecording(int width, int height)
    {
        _templateRecording.streamRecording = new StreamRecording()
        {
            width = width,
            height = height
        };
        return this;
    }

    public TemplateRecording Build()
    {
        return _templateRecording;
    }

    #endregion
}
