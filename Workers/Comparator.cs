using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Repository.Hierarchy;
using PasswordCrackerCentralized.model;
using PasswordCrackerCentralized.util;

namespace PasswordCrackerCentralized
{
    /// <summary>
    /// Compare different variations, made by modifier, with possiblePassword.
    /// </summary>
    ///<param name="possiblePassEncrypted">List of (encrypted password) pairs from the password file.</param>
    public class Comparator
    {
        private BlockingCollection<Dictionary<string, byte[]>> possiblePassEncrypted;
        private List<UserInfo> UserAccounts;
        public static readonly ILog Logger = LogManager.GetLogger(typeof(Program));
        public Comparator(List<UserInfo> _UserAccounts, BlockingCollection<Dictionary<string, byte[]>> PossiblePass)
        {
            possiblePassEncrypted = PossiblePass;
            UserAccounts = _UserAccounts;
        }

        public void Start()
        {
            while (!possiblePassEncrypted.IsCompleted)
            {
                try
                {
                Dictionary<string, byte[]> passwordsEncr = possiblePassEncrypted.Take();
                

                foreach (KeyValuePair<string, byte[]> keyValuePair in passwordsEncr)
                {
                    foreach (UserInfo userAccount in UserAccounts)
                    {
                        if (PassChecker.CompareBytes(userAccount.EntryptedPassword, keyValuePair.Value))
                        {
                            userAccount.ClearPassword = keyValuePair.Key;
                            Logger.FatalFormat("\n\nCracked !:" + keyValuePair.Key+"\n\n");
                        }
                    }
                }
                }
                catch (InvalidOperationException ex)
                {
                    break;
                }
            }
        }
    }
}
