namespace Gitinclude;

public class GitignoreUpdator
{
    private readonly IRulesGenerator _rulesGenerator;
    private readonly ISectionReplacer _sectionReplacer;
    private readonly IFileChanger _fileChanger;

    public GitignoreUpdator(
        IRulesGenerator rulesGenerator,
        ISectionReplacer sectionReplacer,
        IFileChanger fileChanger)
    {
        _rulesGenerator = rulesGenerator;
        _sectionReplacer = sectionReplacer;
        _fileChanger = fileChanger;
    }
    public void Update(string directory)
    {
        var gitincludeText = _fileChanger.ReadAllText(Path.Combine(directory, ".gitinclude"));
        var generatedText = _rulesGenerator.GetIgnoreRulesFromIncludeRules(gitincludeText);

        var gitignorePath = Path.Combine(directory, ".gitignore");

        string newText;
        if (_fileChanger.Exists(gitignorePath))
        {
            newText = _sectionReplacer.GetTextWithSection(
                originalText: _fileChanger.ReadAllText(gitignorePath),
                newSectionText: generatedText);
        }
        else
        {
            newText = _sectionReplacer.GetTextWithSection("", generatedText);
        }

        _fileChanger.WriteAllText(gitignorePath, newText);
    }
}

public interface IFileChanger
{
    void WriteAllText(string path, string contents);
    string ReadAllText(string path);
    bool Exists(string path);
}
