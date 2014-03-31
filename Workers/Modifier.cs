using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCrackerCentralized.model;
using PasswordCrackerCentralized.util;

namespace PasswordCrackerCentralized
{
    public class Modifier
    {
        private BlockingCollection<string> Dictionary;
        private BlockingCollection<List<string>> PossiblePasswords;

        public Modifier(BlockingCollection<string> _dictionary, BlockingCollection<List<string>> _PossiblePasswords)
        {
            if (_dictionary == null) throw new ArgumentNullException("Dictionary");
            if (_PossiblePasswords == null) throw new ArgumentNullException("Passwords");
            Dictionary = _dictionary;
            PossiblePasswords = _PossiblePasswords;
        }

        public void Start()
        {
            string currentWord;
            while (!Dictionary.IsCompleted)
            {
                PossiblePasswords.Add(  StringUtilities.MakeVariations( Dictionary.Take(),
                                                                        StringUtilities.DeepnessLevel.Default)
                                        );
            }
            PossiblePasswords.CompleteAdding();
        }
    }
}
