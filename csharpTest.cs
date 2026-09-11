using System.Text;
using Recite.Core.Csl;

namespace Recite.Core.Citations;

/// <summary>
/// Generates stable, collision-safe citation keys from a scheme template (PLAN §7).
/// Default scheme <c>[auth][year][shorttitle]</c>. Placeholders:
/// <list type="bullet">
/// <item><c>[auth]</c> first author's family name</item>
/// <item><c>[authors]</c> up to three families concatenated</item>
/// <item><c>[year]</c> issued year (or "nd")</item>
/// <item><c>[shorttitle]</c> first significant title word, capitalised</item>
/// <item><c>[veryshorttitle]</c> same but lowercased</item>
/// </list>
/// Keys are pure functions of the document; collisions get an a/b/c suffix.
/// </summary>
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
        int i = 0;
        while (i < Template.Length)
        {
            if (Template[i] == '[')
            {
                int end = Template.IndexOf(']', i);
                if (end < 0) { sb.Append(Template[i..]); break; }
                var token = Template[(i + 1)..end].ToLowerInvariant();
                sb.Append(Expand(token, doc));
                i = end + 1;
            }
            else
            {
                sb.Append(Template[i]);
                i++;
            }
        }
        var key = sb.ToString();
        // Keep keys LaTeX-safe.
        key = new string(key.Where(c => char.IsLetterOrDigit(c) || c is '-' or '_' or ':' or '.').ToArray());
        return key.Length == 0 ? "ref" : key;
    }
}
