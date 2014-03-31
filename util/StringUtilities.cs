using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordCrackerCentralized.util
{
    internal class StringUtilities
    {
        /**
         * This CLASS is gonna be very big one !
    TODO: Implement deepness of variations !  
        -Starting with a capital letter - 1
        -All capital letters - 1
        -Any arbitrary number of capital letter of the beginning of the word - 2
        -Adding 1 or 2 digits to the beginning of the word - 100
        -Adding 1 or 2 digits to the end of the word - 100
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
            G,
            Default
        };

        public static List<string> MakeVariations(string Word, DeepnessLevel levelOdDeepness)
        {
            if (levelOdDeepness == DeepnessLevel.Default)
            {
                List<string> ListOfVariations = new List<string>();
                ListOfVariations.Add(StringUtilities.Capitalize(Word));
                ListOfVariations.Add(StringUtilities.Reverse(Word));
                ListOfVariations.Add(StringUtilities.StartingCapital(Word));
                return ListOfVariations;
            }
            else
            throw new NotImplementedException();
        }

        public static void multipleFirstLetter(string word, int number,ref List<string> listOfWords )
        {
            /// this shouls take the word and multiple the first letter number times and put it to listOfWords
            /// ex.: word=car number=3 then should return ccar, cccar
            throw new NotImplementedException();
        }
        public static void capitaliseFirstLetters(string word, int number, ref List<string> listOfWords)
        {
            /// this shouls take the word and capitalise number to 1 interval of begginging characters
            /// ex.: word=carousel number=3 the should make: CARousel, CArousel, Carousel
            throw new NotImplementedException();
        }
        public static string StartingCapital(string word)
        {
            if (word == null) throw new ArgumentNullException();
            if (word.Length == 0) throw new ArgumentOutOfRangeException();
            string firstLetter = word.Substring(0, 1);
            firstLetter.ToUpper();
            return firstLetter + word.Substring(1, word.Length - 1);
        }
        public static void AddDigitsToBegin(string word, int numberOfDigits, ref List<string> listOfWords)
        {
            if (word == null) throw new ArgumentNullException("word");
            if (listOfWords == null) throw new ArgumentNullException("listOfWords");
            for (int i = 1; i <=numberOfDigits; i++)
            {
                for (int j = 0; j < Math.Pow(10,numberOfDigits); j++)
                {
                    listOfWords.Add(word + i);
                }
            }
        }
        public static void AddDigitsToEnd(string word, int numberOfDigits, ref List<string> listOfWords)
        {
            if (word == null) throw new ArgumentNullException("word");
            if (listOfWords == null) throw new ArgumentNullException("listOfWords");
            for (int i = 1; i <= numberOfDigits; i++)
            {
                for (int j = 0; j < Math.Pow(10, numberOfDigits); j++)
                {
                    listOfWords.Add(i + word);
                }
            }
        }
        public static String Capitalize(string str)
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

        public static String Reverse(string str)
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