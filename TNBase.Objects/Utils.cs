using System;
using System.Text.RegularExpressions;

namespace TNBase.Objects
{
    public class Utils
    {
        /// <summary>
        /// Calidates a postcode and surname specifier.
        /// </summary>
        /// <param name="postcode">The postcode</param>
        /// <exception cref="FormatException">Throws a format exception if its invalid.</exception>
        public static void validatePostcode(String postcode)
        {
            // Get a copy, make it upper case and remove spaces.
            String copy = postcode;
            copy = copy.ToUpper();
            copy = removeSurnameSpecifier(copy);
            copy = copy.Replace(" ", "");

            // Check alphanumeric.
            if (!System.Text.RegularExpressions.Regex.IsMatch(copy, @"^[a-zA-Z0-9]+( \[[A-Z]\-[A-Z]\])?$"))
            {
                throw new FormatException("Input does not match expected format. There should be no spaces in the postcode and a space before an optional surname specifier");
            }

            // Length check.
            if (copy.Length > 7)
            {
                throw new FormatException("Postcode is too long.");
           
            }
        }

        /// <summary>
        /// Is a surname valid for a particular postcode?
        /// </summary>
        /// <param name="postcode">The postcode</param>
        /// <param name="listenerSurname">The surname</param>
        /// <returns></returns>
        public static bool postcodeValidForSurname(String postcode, String listenerSurname)
        {
            string listenerPostcode = removeSurnameSpecifier(postcode);

            string pattern = @" \[[A-Z]\-[A-Z]\]";
            Regex regex = new Regex(pattern);
            var match = regex.Match(postcode);
            if (!match.Success)
            {
                return true;
            }

            // Get the result and move spaces.
            string result = match.Groups[0].Value;
            result = result.Replace(" ", "");

            char startLetter = result.ToCharArray()[1];
            char endLetter = result.ToCharArray()[3];

            char surnameLetter = listenerSurname.ToCharArray()[0];
            return (surnameLetter >= startLetter
                && surnameLetter <= endLetter);
        }

        /// <summary>
        /// Remove the surname specifier (e.g. [A-H] from a string)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String removeSurnameSpecifier(String input)
        {
            string pattern = @" \[[A-Z]\-[A-Z]\]";
            input = input.ToUpper();

            Regex regex = new Regex(pattern);
            return regex.Replace(input, "").Replace(" ", "");
        }
    }
}
