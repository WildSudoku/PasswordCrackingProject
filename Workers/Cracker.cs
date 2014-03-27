﻿using System;
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
        private BlockingCollection<Dictionary<string, byte[]>> PossiblePasswords;

        public Cracker(string dictionaryFile, string passwordFile)
        {
            _Dictionary = new BlockingCollection<string>();
            UserAccounts = new BlockingCollection<UserInfo>();
            PossiblePasswords = new BlockingCollection<Dictionary<string, byte[]>>();
            PasswordFileHandler.ReadPasswordFile(passwordFile);
            new DictionaryReader(_Dictionary,dictionaryFile);
        }

        public void Start()
        {
        }
    }
}
