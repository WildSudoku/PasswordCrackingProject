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
            Modifier modifier2 = new Modifier(Dictionary, PossibleClearPasswords);
            Modifier modifier3 = new Modifier(Dictionary, PossibleClearPasswords);
            Modifier modifier4 = new Modifier(Dictionary, PossibleClearPasswords);
            Modifier modifier5= new Modifier(Dictionary, PossibleClearPasswords);
            Modifier modifier6 = new Modifier(Dictionary, PossibleClearPasswords);
            Modifier modifier7 = new Modifier(Dictionary, PossibleClearPasswords);
            Modifier modifier8 = new Modifier(Dictionary, PossibleClearPasswords);
            Modifier modifier9 = new Modifier(Dictionary, PossibleClearPasswords);
            Modifier modifier10 = new Modifier(Dictionary, PossibleClearPasswords);
            Modifier modifier11= new Modifier(Dictionary, PossibleClearPasswords);
            Modifier modifier12 = new Modifier(Dictionary, PossibleClearPasswords);
         //   Modifier modifier5 = new Modifier(Dictionary, PossibleClearPasswords);

            Encryptor encryptor1 = new Encryptor(PossibleClearPasswords,PossiblePasswords);
            Encryptor encryptor2 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor3 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor4 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor5 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor6 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor7 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor8 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor9 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor10 = new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor11= new Encryptor(PossibleClearPasswords, PossiblePasswords);
            Encryptor encryptor12= new Encryptor(PossibleClearPasswords, PossiblePasswords);
          //  Encryptor encryptor5 = new Encryptor(PossibleClearPasswords, PossiblePasswords);

            Comparator comparator1 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator2 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator3 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator4 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator5 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator6 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator7 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator8 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator9 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator10 = new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator11= new Comparator(UserAccounts, PossiblePasswords);
            Comparator comparator12= new Comparator(UserAccounts, PossiblePasswords);
           // Comparator comparator5 = new Comparator(UserAccounts, PossiblePasswords);

            Task.Factory.StartNew(() => modifier1.Start());
            Task.Factory.StartNew(() => modifier2.Start());
            Task.Factory.StartNew(() => modifier3.Start());
            Task.Factory.StartNew(() => modifier4.Start());
            Task.Factory.StartNew(() => modifier5.Start());
            Task.Factory.StartNew(() => modifier6.Start());
            Task.Factory.StartNew(() => modifier7.Start());
            Task.Factory.StartNew(() => modifier8.Start());
            Task.Factory.StartNew(() => modifier9.Start());
            Task.Factory.StartNew(() => modifier10.Start());
            Task.Factory.StartNew(() => modifier11.Start());
            Task.Factory.StartNew(() => modifier12.Start());
          //  Task.Factory.StartNew(() => modifier5.Start());

            Task.Factory.StartNew(() => encryptor1.Start());
            Task.Factory.StartNew(() => encryptor2.Start());
            Task.Factory.StartNew(() => encryptor3.Start());
            Task.Factory.StartNew(() => encryptor4.Start());
            Task.Factory.StartNew(() => encryptor5.Start());
            Task.Factory.StartNew(() => encryptor6.Start());
            Task.Factory.StartNew(() => encryptor7.Start());
            Task.Factory.StartNew(() => encryptor8.Start());
            Task.Factory.StartNew(() => encryptor9.Start());
            Task.Factory.StartNew(() => encryptor10.Start());
            Task.Factory.StartNew(() => encryptor11.Start());
            Task.Factory.StartNew(() => encryptor12.Start());
            //Task.Factory.StartNew(() => encryptor5.Start());


            Parallel.Invoke(() => comparator1.Start(), () => comparator2.Start(),
                            () => comparator3.Start(), () => comparator4.Start(),() => comparator5.Start(),
                            () => comparator6.Start(), () => comparator7.Start(), () => comparator8.Start(), () => comparator9.Start(),
                            () => comparator10.Start(), () => comparator11.Start(), () => comparator12.Start());
            //Parallel.Invoke(() => comparator1.Start());

            
            Console.WriteLine("Finished. ..." + DateTime.Now);
            foreach (UserInfo userAccount in UserAccounts)
            {
                Console.WriteLine(userAccount.Username + " " + userAccount.ClearPassword);
            }
        }
    }
}
