using System.Text.RegularExpressions;

namespace Gitinclude.ConsoleApp;

public interface IRulesGenerator
{
    string GetIgnoreRulesFromIncludeRules(string includesText);
}

public class RulesGenerator : IRulesGenerator
{
    public virtual string GetIgnoreRulesFromIncludeRules(string includesText)
    {
        var includes = Regex.Split(includesText, @"(\r\n|\r|\n)").Select(x => x.Split("#")[0].Trim()).Where(x => x != "").ToArray();

        var ignoreRules = new List<string>();
        foreach(var include in includes)
        {
            var pathParts = include.Split('/');

            if (pathParts.Length == 1)
            {
                ignoreRules.Add("!" + pathParts[0]);
                continue;
            }

            ignoreRules.Add("!" + pathParts[0] + "/");

            ignoreRules.Add(pathParts[0] + "/*");
            for (var i = 2; i < pathParts.Length; i++)
            {
                var path = string.Join('/', pathParts.Take(i));
                ignoreRules.Add("!" + path + "/");
                ignoreRules.Add(path + "/*");
            }
            ignoreRules.Add("!" + include);
        }
        ignoreRules = ignoreRules.Distinct().OrderBy(x => x.Count(x => x == '/')).ThenBy(x => x.TrimStart('!')).ToList();
        return "*" + Environment.NewLine + String.Join(Environment.NewLine, ignoreRules);
    }
}
