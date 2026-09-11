
public sealed class CitationKeyScheme
{

    public const string Default = "[auth][year][shorttitle]";

    public string Template { get; }

    public CitationKeyScheme(string? template = null)
        => Template = string.IsNullOrWhiteSpace(template) ? Default : template!;

    
    /// ###
    public string BaseKey(CslDocument doc)
    {
            /// ###
    }
}
