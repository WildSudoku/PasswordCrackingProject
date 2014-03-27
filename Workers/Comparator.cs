using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCrackerCentralized.model;
using PasswordCrackerCentralized.util;

namespace PasswordCrackerCentralized
{

    public class Comparator
    {
        private BlockingCollection<Dictionary<string, byte[]>> possiblePassEncrypted;
        private List<UserInfo> UserAccounts;

        public Comparator(List<UserInfo> _UserAccounts, BlockingCollection<Dictionary<string, byte[]>> PossiblePass)
        {
            possiblePassEncrypted = PossiblePass;
            UserAccounts = _UserAccounts;
        }
        private static bool CompareBytes(IList<byte> firstArray, IList<byte> secondArray)
        {
            if (secondArray == null)
            {
                throw new ArgumentNullException("firstArray");
            }
            if (secondArray == null)
            {
                throw new ArgumentNullException("secondArray");
            }
            if (firstArray.Count != secondArray.Count)
            {
                return false;
            }
            for (int i = 0; i < firstArray.Count; i++)
            {
                if (firstArray[i] != secondArray[i])
                    return false;
            }
            return true;
        }
        private bool CheckSingleWord(IEnumerable<UserInfo> userInfos, byte[] possiblePassword)
        {
            //string encryptedPasswordBase64 = System.Convert.ToBase64String(encryptedPassword);

            List<UserInfoClearText> results = new List<UserInfoClearText>();
            foreach (UserInfo userInfo in userInfos)
            {
                if (CompareBytes(userInfo.EntryptedPassword, encryptedPassword))
                {
                    results.Add(new UserInfoClearText(userInfo.Username, possiblePassword));
                    Console.WriteLine(userInfo.Username + " " + possiblePassword);
                }
            }
            return results;
            return null;
        }
    }
}
