﻿namespace Gitinclude.ConsoleApp;

public class _Main
{
    static void Main(string[] args)
    {
        Console.WriteLine("Gitignore ConsoleApp v2.0.0");

        var gitIgnoreUpdator = new GitignoreUpdator(
            rulesGenerator: new RulesGenerator(),
            sectionReplacer: new SectionReplacer(),
            fileChanger: new FileChanger());

        try
        {
            string directory;
            if (args.Length == 0)
            {
                directory = AppContext.BaseDirectory;
            }
            else
            {
                var arg = args[0].Trim().Trim('"').Trim('\'');
                if (arg.EndsWith(".gitinclude"))
                {
                    arg = arg.Substring(0, arg.Length - ".gitinclude".Length);
                }
                directory = arg.Trim('\\').Trim('/');
            }

            Console.WriteLine("Expected .gitignore location: " + directory);

            gitIgnoreUpdator.Update(directory);

            Console.WriteLine("Your .gitignore is up to date.");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.ReadKey();
        }
    }
}

