using System.Text.RegularExpressions;

namespace Gitinclude;

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
                throw new Exception($"Each .gitinclude rule should contain a forward slash '/' to define a folder to exclude on the left and an inclusion path on the right. The rule '{include}' is not allowed.");
            }

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
        return string.Join(Environment.NewLine, ignoreRules);
    }
}
