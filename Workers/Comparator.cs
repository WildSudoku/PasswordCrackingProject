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

    public class Comparator
    {
        private BlockingCollection<Dictionary<string, byte[]>> possiblePassEncrypted;
        private List<UserInfo> UserAccounts;

        public Comparator(List<UserInfo> _UserAccounts, BlockingCollection<Dictionary<string, byte[]>> PossiblePass)
        {
            possiblePassEncrypted = PossiblePass;
            UserAccounts = _UserAccounts;
        }

        public void Start()
        {

        }
    }
}
