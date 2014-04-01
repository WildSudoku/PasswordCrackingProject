using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net.Config;
using PasswordCrackerCentralized.model;
using PasswordCrackerCentralized.util;
using PasswordCrackerCentralized.Workers;

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
        private List<UserInfo> UserAccounts;
        private BlockingCollection<Dictionary<string, byte[]>> PossiblePasswords;
        private BlockingCollection<List<string>> PossibleClearPasswords; 

        public Cracker(string dictionaryFile, string passwordFile)
        {
            _Dictionary = new BlockingCollection<string>();
            PossiblePasswords = new BlockingCollection<Dictionary<string, byte[]>>();
            PossibleClearPasswords = new BlockingCollection<List<string>>();
            UserAccounts = PasswordFileHandler.ReadPasswordFile(passwordFile);
            new DictionaryReader(_Dictionary,dictionaryFile);
            Dictionary.CompleteAdding();
            BasicConfigurator.Configure();
        }

        public void Start()
        {
            Console.WriteLine("Starting. ..."+DateTime.Now);
            Modifier modifier1 = new Modifier(Dictionary,PossibleClearPasswords);
            Modifier modifier2 = new Modifier(Dictionary,PossibleClearPasswords);

            Encryptor encryptor1 = new Encryptor(PossibleClearPasswords,PossiblePasswords);
            Encryptor encryptor2 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor3 = new Encryptor(PossibleClearPasswords, PossiblePasswords);

            Comparator comparator1 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator2 = new Comparator(UserAccounts, PossiblePasswords);

            Task.Factory.StartNew(() => modifier1.Start());
            Task.Factory.StartNew(() => modifier2.Start());
            Task.Factory.StartNew(() => encryptor1.Start());
            Task.Factory.StartNew(() => encryptor2.Start());
            Task.Factory.StartNew(() => encryptor3.Start());

            Parallel.Invoke(() => comparator1.Start(), () => comparator2.Start());
            Console.WriteLine("Finished. ..." + DateTime.Now);
            foreach (UserInfo userAccount in UserAccounts)
            {
                Console.WriteLine(userAccount.Username + " " + userAccount.ClearPassword);
            }
        }
    }
}
