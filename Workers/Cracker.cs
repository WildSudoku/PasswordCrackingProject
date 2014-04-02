using System;
using System.Collections;
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
            PossiblePasswords = new BlockingCollection<Dictionary<string, byte[]>>(6500);
            PossibleClearPasswords = new BlockingCollection<List<string>>(6500);
            UserAccounts = PasswordFileHandler.ReadPasswordFile(passwordFile);
            new DictionaryReader(_Dictionary,dictionaryFile);
            Dictionary.CompleteAdding();
            FileInfo configFile = new FileInfo(@"..\..\logconfig.xml");
            BasicConfigurator.Configure();
            XmlConfigurator.Configure(configFile);
        }

        public void Start()
        {
            Console.WriteLine("Starting. ..."+DateTime.Now);
            Modifier modifier1 = new Modifier(Dictionary,PossibleClearPasswords);
            Modifier modifier2 = new Modifier(Dictionary,PossibleClearPasswords);
            Modifier modifier3 = new Modifier(Dictionary, PossibleClearPasswords);
            Modifier modifier4 = new Modifier(Dictionary, PossibleClearPasswords);

            Encryptor encryptor1 = new Encryptor(PossibleClearPasswords,PossiblePasswords);
            Encryptor encryptor2 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor3 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor4 = new Encryptor(PossibleClearPasswords, PossiblePasswords);

            Comparator comparator1 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator2 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator3 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator4 = new Comparator(UserAccounts, PossiblePasswords);

            Task.Factory.StartNew(() => modifier1.Start());
            Task.Factory.StartNew(() => modifier2.Start());
            Task.Factory.StartNew(() => modifier3.Start());
            Task.Factory.StartNew(() => modifier4.Start());

            Task.Factory.StartNew(() => encryptor1.Start());
            Task.Factory.StartNew(() => encryptor2.Start());
            Task.Factory.StartNew(() => encryptor3.Start());
            Task.Factory.StartNew(() => encryptor4.Start());
            
            Parallel.Invoke(() => comparator1.Start(), () => comparator2.Start(),
                            () => comparator3.Start(), () => comparator4.Start());
            
            Console.WriteLine("Finished. ..." + DateTime.Now);
            foreach (UserInfo userAccount in UserAccounts)
            {
                Console.WriteLine(userAccount.Username + " " + userAccount.ClearPassword);
            }
        }
    }
}
