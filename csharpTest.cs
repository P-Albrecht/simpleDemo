using System.Text;
using Recite.Core.Csl;

namespace Recite.Core.Citations;

/// <summary>
public sealed class CitationKeyScheme
{
    public string BaseKey(CslDocument doc)
    {
        ey = sb.ToString();
        // Keep keys LaTeX-safe.
        key = new string(key.Where(c => char.IsLetterOrDigit(c) || c is '-' or '_' or ':' or '.').ToArray());
        return key.Length == 0 ? "ref" : key;
    }
}

return key.Length == 0 ? "ref" : key;
