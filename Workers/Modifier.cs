using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using PasswordCrackerCentralized.model;
using PasswordCrackerCentralized.util;

namespace PasswordCrackerCentralized
{
    /// <summary>
    /// Modifier responsible for creating different variations of the word.
    /// </summary>
    ///<param name="possiblePasswords">List of (encrypted password) pairs from the password file.</param>
    public class Modifier
    {
        private BlockingCollection<string> Dictionary;
        private BlockingCollection<List<string>> PossiblePasswords;
        public static readonly ILog Logger = LogManager.GetLogger(typeof(Program));
        public Modifier(BlockingCollection<string> _dictionary, BlockingCollection<List<string>> _PossiblePasswords)
        {
            if (_dictionary == null) throw new ArgumentNullException("Dictionary");
            if (_PossiblePasswords == null) throw new ArgumentNullException("Passwords");
            Dictionary = _dictionary;
            PossiblePasswords = _PossiblePasswords;
        }
        /// <summary>
        /// Take every word from dictionary.
        /// </summary>
        /// <param name="currentWord"></param>
        ///  <returns>A list of words variations.</returns>

        public void Start()
        {
            string currentWord;
            while (!Dictionary.IsCompleted)
            {
                try
                {
                    currentWord = Dictionary.Take();
                    Logger.Info("Modified:"+currentWord);
                    PossiblePasswords.Add(StringUtilities.MakeVariations(currentWord,
                        StringUtilities.DeepnessLevel.Default)
                        );
                }
                catch (InvalidOperationException ex)
                {
                    //completed !
                }
            }
            PossiblePasswords.CompleteAdding();
        }
    }
}
