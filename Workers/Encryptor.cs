using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCrackerCentralized.Workers
{

    public class Encryptor
    {
        private BlockingCollection<List<string>> PossiblePassClear;
        private BlockingCollection<Dictionary<string,string>> PossiblePassEncr;

        public Encryptor(BlockingCollection<List<string>> possiblePassClear, BlockingCollection<Dictionary<string, string>> possiblePassEncr)
        {
            if (possiblePassClear == null) throw new ArgumentNullException("Clear passwords");
            if (PossiblePassEncr == null) throw new ArgumentNullException("Encrypted passwords");
            PossiblePassClear = possiblePassClear;
            PossiblePassEncr = possiblePassEncr;
        }
    }
}
