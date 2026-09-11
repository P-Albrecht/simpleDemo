using System.Text;
using Recite.Core.Csl;

namespace Recite.Core.Citations;


public sealed class CitationKeyScheme
{
    public const string Default = "[auth][year][shorttitle]";

    public string Template { get; }

    public CitationKeyScheme(string? template = null)
        => Template = string.IsNullOrWhiteSpace(template) ? Default : template!;

    /// <summary>Render the base (pre-collision) key for a document.</summary>
    public string BaseKey(CslDocument doc)
    {
        var sb = new StringBuilder();
    }

}
