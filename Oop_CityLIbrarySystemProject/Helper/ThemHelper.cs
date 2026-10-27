namespace Oop_CityLIbrarySystemProject.Helper
;

public static class ThemeHelper
{
    public static void PrintHeader(string title)
    {
        int num = 40;
        Console.WriteLine(new string('=', num));
        Console.WriteLine(title.PadLeft((num + title.Length) / 2));
        Console.WriteLine(new string('=', num));
    }

    public static void PrintSectionTitle(string title)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        int num = 40;
        int count = (num - title.Length - 2) / 2;
        string value = new string('-', count);
        Console.WriteLine($"{value} {title} {value}");
        Console.ResetColor();
    }

    public static void PrintOption(string option)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("  " + option);
        Console.ResetColor();
    }

    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message ?? "");
        Console.ResetColor();
    }

    public static void PrintSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(message ?? "");
        Console.ResetColor();
    }

    public static void PrintWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(message ?? "");
        Console.ResetColor();
    }

    public static string Prompt(string label)
    {
        string text;
        do
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nEnter " + label + ": ");
            Console.ForegroundColor = ConsoleColor.Green;
            text = Console.ReadLine()?.Trim();
            Console.ResetColor();
            if (string.IsNullOrWhiteSpace(text))
            {
                PrintWarning(label + " cannot be empty. Please try again.");
            }
        }
        while (string.IsNullOrWhiteSpace(text));
        return text;
    }
}