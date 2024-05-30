using System.Text.RegularExpressions;

namespace CrudUdes.Api.Helpers
{
    public static class ValidPassword
    {

        public static bool IsValidPassword(this string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            if (!Regex.IsMatch(password, "[A-Z]"))
            {

                return false;
            }

            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                return false;
            }

            if (!Regex.IsMatch(password, "[0-9]"))
            {
                return false;
            }

            if (!Regex.IsMatch(password, "[!@#$%^&*()]"))
            {
                return false;
            }

            return true;

        }
    }
}
