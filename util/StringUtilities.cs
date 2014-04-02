using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Util;

namespace PasswordCrackerCentralized.util
{
    public class StringUtilities
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
        /// <summary>
        /// Class contains static methods that creates string variations.
        /// </summary>

        /// <summary>
        /// Define seven levels. 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="number"></param>
        /// <param name="numberOfDigits"></param>
        /// <param name="listOfWords"></param>

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
                string currentWord = Word.ToLower();
                ListOfVariations.Add(currentWord);
                ListOfVariations.Add(currentWord.ToUpper());
                ListOfVariations.Add(StringUtilities.Capitalize(currentWord));
                ListOfVariations.Add(StringUtilities.Reverse(currentWord));
                AddDigitsToBegin(currentWord, 2, ListOfVariations);
                AddDigitsToEnd(currentWord, 2, ListOfVariations);
                SurroundWithDigits(currentWord, ListOfVariations, 1);
                return ListOfVariations;
            }
            else
            throw new NotImplementedException();
        }

        public static void multipleFirstLetter(string word, int number,List<string> listOfWords )
        {
            /// <summary>Takes the word and multiple first letter several times and add it on the listOfWords.</summary>
            ///<returns></returns>

            ///  <example> word=car number=3, return ccar, cccar</example>
            throw new NotImplementedException();
        }
        public static void capitaliseFirstLetters(string word, int number, List<string> listOfWords)
        {
            /// <summary>Takes the word and using the number capitalise beginging characters.</summary>
            ///<returns></returns>
            /// <example> word=carousel number=3 the should make: CARousel, CArousel, Carousel</example>
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
        public static void AddDigitsToBegin(string word, int numberOfDigits, List<string> listOfWords)
        {
            if (word == null) throw new ArgumentNullException("word");
            if (listOfWords == null) throw new ArgumentNullException("listOfWords");
            if (numberOfDigits < 1 || numberOfDigits >3) throw new ArgumentOutOfRangeException("numberOfDigits could be only 1,2 or 3");
            StringBuilder genWord;
            if (numberOfDigits == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    listOfWords.Add(i+word);
                }
            }
            else if (numberOfDigits == 2)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        listOfWords.Add(i+""+j+word);
                    }
                }
            }
            else if (numberOfDigits == 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            listOfWords.Add(i+""+j+""+k+word);
                        }
                    }
                }
            }
        }
        public static void AddDigitsToEnd(string word, int numberOfDigits, List<string> listOfWords)
        {
            if (word == null) throw new ArgumentNullException("word");
            if (listOfWords == null) throw new ArgumentNullException("listOfWords");
            if (numberOfDigits < 1 || numberOfDigits > 3) throw new ArgumentOutOfRangeException("numberOfDigits could be only 1,2 or 3");
            if (numberOfDigits == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    listOfWords.Add(word+i);
                }
            }
            else if (numberOfDigits == 2)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        listOfWords.Add(word+i + "" + j);
                    }
                }
            }
            else if (numberOfDigits == 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            listOfWords.Add(word+i + "" + j + "" + k);
                        }
                    }
                }
            }
        }

        public static void SurroundWithDigits(string word,ICollection<string> list,  int number)
        {
            ///number == 2 is gonna to take 100 times more time :D 
            if (word == null) throw new ArgumentNullException("word");
            if (list == null) throw new ArgumentNullException("list");
            if (number < 1 || number > 2)  throw new ArgumentOutOfRangeException("number");
            if (number == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        list.Add(i+word+j);
                    }
                }
            }
            else if (number == 2)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            for (int l = 0; l < 10; l++)
                            {
                                list.Add(i+""+k + word + j+""+l);
                            }
                        }
                    }
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