namespace Gitinclude.ConsoleApp;

public class _Main
{
    static void Main(string[] args)
    {
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

            Console.WriteLine("Your .gitignore has been updated.");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.ReadKey();
        }
    }
}

