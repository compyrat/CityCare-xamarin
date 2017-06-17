using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Proyecto_Final___Xamarin_Ver.Utils
{
    public static class StringUtilities
    {
        public static string RemoveWhiteSpaces(string text)
        {
            return text.Replace(" ", string.Empty);
        }

        public static string RemoveNoDigits(string text)
        {
            return Regex.Replace(text, "\\D", string.Empty);
        }

        public static string RemoveDigits(string text)
        {
            return Regex.Replace(text, "\\d", string.Empty);
        }

        public static string RemoveAccents(string text)
        {
            text = text.Normalize(NormalizationForm.FormD);
            return Regex.Replace(text, "\\p{Mn}", string.Empty);
        }

        public static Boolean IsCorrectEmail(string text)
        {
            if (text == null || text.Length == 0)
            {
                return false;
            }
            else
            {
                if (text.Contains(" ") || IsNumeric(text.Substring(0, 1)))
                {
                    return false;
                }
                else
                {
                    if (Regex.IsMatch(text, "(\\w+\\S+@[a-zA-Z_]+?\\.[a-zA-Z_]{2,6})"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static string Truncate(string text, int i)
        {
            return text.Substring(0, i);
        }

        public static Boolean IsNumeric(string text)
        {
            try
            {
                int.Parse(text);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
