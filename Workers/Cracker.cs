using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCrackerCentralized.model;
using PasswordCrackerCentralized.util;

namespace PasswordCrackerCentralized
{


    class Cracker
    {
        private BlockingCollection<string> Dictionary;
        private BlockingCollection<UserInfo> UserAccounts;
        private long loadedWords;

        private void ReadDictionary(string dictionaryFileName, string passwordsFileName)
        {
            foreach (UserInfo user in PasswordFileHandler.ReadPasswordFile(passwordsFileName))
            {
                UserAccounts.Add(user);
            }
            using (FileStream fs = new FileStream(dictionaryFileName, FileMode.Open, FileAccess.Read))
                using (StreamReader dictionary = new StreamReader(fs))
                {
                    while (!dictionary.EndOfStream)
                    {
                        String dictionaryEntry = dictionary.ReadLine();
                        Dictionary.Add(dictionaryEntry);
                    }
                }
        }
    }
}
