using System.Text.RegularExpressions;

namespace Gitinclude;

public interface ISectionReplacer
{
    string GetTextWithSection(string originalText, string newSectionText);
}

public class SectionReplacer : ISectionReplacer
{
    private readonly string _sectionOpener;
    private readonly string _sectionCloser;

    public SectionReplacer(
        string sectionOpener = "# .gitignore generated rules START", 
        string sectionCloser = "# .gitignore generated rules END")
    {
        _sectionOpener = sectionOpener;
        _sectionCloser = sectionCloser;
    }

    public string GetTextWithSection(string originalText, string newSectionText)
    {
        var fullSection = _sectionOpener + Environment.NewLine + newSectionText + Environment.NewLine + _sectionCloser;

        if (string.IsNullOrWhiteSpace(originalText))
        {
            return fullSection;
        }
        else 
        {
            var pattern = Regex.Escape(_sectionOpener) + @"[\s\S]*" + Regex.Escape(_sectionCloser);
            if (Regex.IsMatch(originalText, pattern))
            {
                return Regex.Replace(
                    input: originalText,
                    pattern: pattern,
                    replacement: fullSection);
            }
            else
            {
                return originalText + Environment.NewLine + Environment.NewLine + fullSection;
            }
        }
    }
}

