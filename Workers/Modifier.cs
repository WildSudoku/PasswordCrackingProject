using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCrackerCentralized.model;

namespace PasswordCrackerCentralized
{
    class Modifier
    {
        private List<String> Dictionary;

        public Modifier(List<String> _dictionary)
        {
            if (_dictionary == null) throw new ArgumentNullException("Dictionary");
            Dictionary = _dictionary;
        }
    }
}
