using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCrackerCentralized.model;

namespace PasswordCrackerCentralized.util
{
    class DictionaryReader
    {
        public DictionaryReader(BlockingCollection<string> Dictionary,string dictionaryFileName)
        {
            //foreach (UserInfo user in PasswordFileHandler.ReadPasswordFile(passwordsFileName))
            //{
            //    UserAccounts.Add(user);
            //}
            using (FileStream fs = new FileStream(dictionaryFileName, FileMode.Open, FileAccess.Read))
                using (StreamReader dictionary = new StreamReader(fs))
                {
                    while (!dictionary.EndOfStream)
                    {
                        Dictionary.Add(dictionary.ReadLine());
                    }
                }
        }
    }
}
