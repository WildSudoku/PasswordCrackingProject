using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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
        private string _DictionaryFile;
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
            _DictionaryFile = dictionaryFile;
        }

        public List<Action> PrepareWorkers(int NumberOfModifiers, int NumberOfEncryptors, int NumberOfComparators)
        {
            List<Action> Actions = new List<Action>();
            for (int i = 0; i < NumberOfModifiers; i++)
            {
                Actions.Add(new Action(() => new Modifier(Dictionary, PossibleClearPasswords)));
            }
            for (int i = 0; i < NumberOfEncryptors; i++)
            {
                Actions.Add(new Action(() => new Encryptor(PossibleClearPasswords, PossiblePasswords)));
            }
            for (int i = 0; i < NumberOfComparators; i++)
            {
                Actions.Add(new Action(() => new Comparator(UserAccounts, PossiblePasswords)));
            }
            return Actions;
        }
        public void Start()
        {
            List<Action> Workers;
            int numberOfModifiers = (System.Environment.ProcessorCount / 2 == 0 ? 1 : System.Environment.ProcessorCount / 2);
            int numberOfEncryptors = System.Environment.ProcessorCount;
            int numberOfComparators = (System.Environment.ProcessorCount / 4 == 0 ? 1 : System.Environment.ProcessorCount / 4);
            
            Workers = PrepareWorkers(numberOfModifiers, numberOfEncryptors, numberOfComparators);          
            
            Stopwatch watch = new Stopwatch();
            Console.WriteLine("Cracking started at "+DateTime.Now + " with " + Workers.Count + " workers.");
            watch.Start();
            
            Parallel.Invoke(Workers.ToArray());
            
            watch.Start();
            Console.WriteLine("Cracking done at " + DateTime.Now + " and took " + watch.Elapsed);
            foreach (UserInfo userAccount in UserAccounts)
            {
                Console.WriteLine(userAccount.Username + " " + userAccount.ClearPassword);
            }
        }
    }
}
