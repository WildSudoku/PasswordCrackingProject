﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PasswordCrackerCentralized.util;

namespace PasswordCrackerCentralized.Workers
{

    public class Encryptor
    {
        private readonly HashAlgorithm hashAlgorithm;
        private BlockingCollection<Dictionary<string,byte[]>> PossiblePassEncr;
        private BlockingCollection<List<string>> PossiblePassClean; 

        public Encryptor(BlockingCollection<List<string>> _PossiblePassClean,BlockingCollection<Dictionary<string, byte[]>> _PossiblePassEncr)
        {
            if (_PossiblePassEncr == null) throw new ArgumentNullException("Encrypted passwords");
            if (_PossiblePassClean == null) throw new ArgumentNullException("Clear passwords");
            PossiblePassClean = _PossiblePassClean;
            PossiblePassEncr = _PossiblePassEncr;
            hashAlgorithm = new SHA1CryptoServiceProvider();
        }

        public void Start()
        {
            while (!PossiblePassClean.IsCompleted)
            {
                Dictionary<string, byte[]> encrypted = new Dictionary<string, byte[]>();
                List<string> current = PossiblePassClean.Take();
                foreach (var element in current)
                {
                    encrypted.Add(element,encryptSingleElement(element));
                }
                PossiblePassEncr.Add(encrypted);
            }
            PossiblePassEncr.CompleteAdding();
        }
        private byte[] encryptSingleElement(string possiblePass)
        {
            return hashAlgorithm.ComputeHash(
                Array.ConvertAll(   possiblePass.ToCharArray(), 
                                    PasswordFileHandler.GetConverter()));
        }
    }
}
