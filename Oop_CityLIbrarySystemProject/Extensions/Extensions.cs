namespace Oop_CityLIbrarySystemProject.Extensions;

public static class StringExtensions
{

    public static string NormalizedId(this string id)
        => id?.Trim().ToUpperInvariant()!;

    public static bool IsValidEmail(this string email)
    {
        if (string.IsNullOrEmpty(email)) return false;
        bool hasAt = false;
        bool hasDot = false;
        for (int i = 0; i < email.Length; i++)
        {
            if (email[i] == '@') hasAt = true;
            if (email[i] == '.') hasDot = true;


        }
        return hasAt && hasDot;
    }

    public static bool ContainDigit(this string id)
    {
        if (string.IsNullOrEmpty(id))
            return false;
        for (int i = 0; i < id.Length; i++)
        {
            if (char.IsDigit(id[i]))
                return true;
        }
        return false;
    }

}
