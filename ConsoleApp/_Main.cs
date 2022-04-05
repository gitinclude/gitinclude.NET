namespace Gitinclude.ConsoleApp;

public class _Main
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("  Gitignore ConsoleApp v3.0.0  ");
        Console.ResetColor();

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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your .gitignore is up to date.");
            Console.ResetColor();
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine(ex.ToString());
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}

