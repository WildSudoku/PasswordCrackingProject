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


    public class Cracker
    {
        private BlockingCollection<string> _Dictionary;

        public BlockingCollection<string> Dictionary
        {
            get { return _Dictionary; }
            set { _Dictionary = value; }
        }
    
        private BlockingCollection<UserInfo> UserAccounts;
        private BlockingCollection<Dictionary<string, string>> PossiblePasswords;

        public Cracker(string dictionaryFile, string passwordFile)
        {
            _dictionary = new BlockingCollection<string>();
            UserAccounts = new BlockingCollection<UserInfo>();
            PossiblePasswords = new BlockingCollection<Dictionary<string, string>>();
            LoadDataFromFiles(dictionaryFile,passwordFile);
        }

        private void LoadDataFromFiles(string dictionaryFileName, string passwordsFileName)
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
                        this._dictionary.Add(dictionary.ReadLine());
                    }
                }
        }


    }
}
