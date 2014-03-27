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

        public Modifier(BlockingCollection<string> _dictionary)
        {
            if (_dictionary == null) throw new ArgumentNullException("Dictionary");
            Dictionary = _dictionary;
        }
    }
}
