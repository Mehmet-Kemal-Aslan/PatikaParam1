// An extension to warn the user to capitalize the initial letter.
namespace StudentWebApi.Extension
{
    public static class FirstLetter
    {
        public static string firstLetter(this string str)
        {
            if (Char.IsUpper(str, 0))
                return str;
            else
                return "Attantion! The first letter is lowercase.";
        }
    }
}
