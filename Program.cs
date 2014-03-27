using System;
using System.Collections.Generic;

namespace PasswordCrackerCentralized
{
    class Program
    {
        static void Main()
        {
            Cracker cracker = new Cracker("webster-dictionary-reduced.txt","passwords.txt");
            Console.ReadKey();
        }
    }
}
