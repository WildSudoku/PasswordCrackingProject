using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordCrackerCentralized.model;

namespace PasswordCrackerCentralized.util
{
    class PassChecker
    {
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
        public static Boolean Check(IEnumerable<UserInfo> userInfos, byte[] possiblePassword)
        {
            foreach (var UserInfo in userInfos)
            {
                if (CompareBytes(UserInfo.EntryptedPassword,possiblePassword)) return true;
            }
            return false;
        }
    }
}
