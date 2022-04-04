using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace gitinclude
{
    public class RulesGenerator
    {
        public string GetIgnoreRulesFromIncludeRules(string includesText)
        {
            var includes = Regex.Split(includesText, @"(\r\n|\r|\n)").Select(x => x.Trim()).Where(x => x != "").ToArray();

            var ignoreRules = new List<string>();
            foreach(var include in includes)
            {
                var pathParts = include.Split('/');
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
}
