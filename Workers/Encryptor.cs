using System;
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
        

        public Encryptor(BlockingCollection<Dictionary<string, byte[]>> possiblePass)
        {
            if (PossiblePassEncr == null) throw new ArgumentNullException("Encrypted passwords");
            PossiblePassEncr = possiblePass;
            hashAlgorithm = new SHA1CryptoServiceProvider();
        }

        private byte[] encryptSingleElement(string possiblePass)
        {
            return hashAlgorithm.ComputeHash(
                Array.ConvertAll(   possiblePass.ToCharArray(), 
                                    PasswordFileHandler.GetConverter()));
        }
    }
}
