using System;
using System.Collections.Generic;
using System.IO;

namespace PasswordCrackerCentralized
{
    class Program
    {
        static void Main()
        {
            Cracker cracker = new Cracker("webster-dictionary-reduced.txt","passwords.txt");
            cracker.Start();
            Console.ReadKey();
        }
    }
}
