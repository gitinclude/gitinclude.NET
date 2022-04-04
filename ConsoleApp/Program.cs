// See https://aka.ms/new-console-template for more information

public class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            throw new ArgumentException("Provide the path of the folder that contains the .gitinclude file.");
        }
        var arg = args[0].Trim().Trim('"').Trim('\'');
        if (arg.EndsWith(".gitignore"))
        {
            arg = arg.Substring(0, arg.Length - ".gitignore".Length);
        }
        arg = arg.Trim('\\').Trim('/');

        // get .gitinclude content

        // call RulesGenerator

        // update specific section of .gitignore
    }
}

