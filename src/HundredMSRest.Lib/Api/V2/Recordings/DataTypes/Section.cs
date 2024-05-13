namespace HundredMSRest.Lib.Api.V2.Recordings.DataTypes;

/// <summary>
/// Record <c>Section</c>
/// </summary>
public record Section(string title, string? format)
{
    public string title { get; init; } =
        title.Length <= 100
            ? title
            : throw new ArgumentException(
                "Value must be less or equal to 100 characters",
                nameof(title)
            );
    public string format { get; init; } =
        format == "bullets" || format == "paragraph"
            ? format
            : throw new ArgumentException("Value must be bullets or paragraph", nameof(format));
}
