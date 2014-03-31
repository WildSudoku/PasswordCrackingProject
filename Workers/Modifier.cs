using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCrackerCentralized.model;

namespace PasswordCrackerCentralized
{
    public class Modifier
    {
        private BlockingCollection<string> Dictionary;
        private BlockingCollection<Dictionary<string, byte[]>> PossiblePasswords;

        public Modifier(BlockingCollection<string> _dictionary, BlockingCollection<Dictionary<string, byte[]>> _PossiblePasswords)
        {
            if (_dictionary == null) throw new ArgumentNullException("Dictionary");
            if (_PossiblePasswords == null) throw new ArgumentNullException("Passwords");
            Dictionary = _dictionary;
            PossiblePasswords = _PossiblePasswords;
        }

        public void Start()
        {
            string currentWord;
            while (Dictionary.IsCompleted)
            {
                currentWord = Dictionary.Take();
            }
        }
    }
}
