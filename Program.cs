using System;
using System.Collections.Generic;

namespace PasswordCrackerCentralized
{
    class Program
    {
        static void Main()
        {
            //Cracking cracker = new Cracking();
            //cracker.RunCracking();
            Dictionary<string,string> dict = new Dictionary<string,string>(0);
            dict.Add("Ahoj ! ","By bye !");
            Console.WriteLine(dict);
            Console.ReadKey();
        }
    }
}
