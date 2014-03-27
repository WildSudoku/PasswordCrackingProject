using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordCrackerCentralized.util
{
    class StringUtilities
    {
        /**
         * This CLASS is gonna be very big one !
    TODO: Implement deepness of variations !  
        -Starting with a capital letter - 1
        -All capital letters - 1
        -Any arbitrary number of capital letter of the beginning of the word - 2
        -Adding 1 or 2 digits to the beginning of the word - 30
        -Adding 1 or 2 digits to the end of the word - 30
        -any combination of the above.

         
         */
        public enum DeepnessLevel
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G
        };

        public static List<string> MakeVariations(DeepnessLevel levelOdDeepness)
        {
            throw new NotImplementedException();
        } 
        public static String Capitalize(String str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            if (str.Trim().Length == 0)
            {
                return str;
            }
            String firstLetterUppercase = str.Substring(0, 1).ToUpper();
            String theRest = str.Substring(1);
            return firstLetterUppercase + theRest;
        }

        public static String Reverse(String str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            if (str.Trim().Length == 0)
            {
                return str;
            }
            StringBuilder reverseString = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                reverseString.Append(str.ElementAt(str.Length - 1 - i));
            }
            return reverseString.ToString();
        }
    }
}
