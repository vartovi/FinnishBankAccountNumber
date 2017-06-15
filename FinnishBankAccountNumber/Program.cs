using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinnishBankAccountNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Converts traditional/old Finnish bank account number to machine form:");
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Input number to convert");
                string userInput = Console.ReadLine();
                Console.WriteLine();

                FinnishBankAccountNumber numberToConvert = new FinnishBankAccountNumber(userInput);
                
                Console.WriteLine(numberToConvert.ToMachineForm());
                Console.WriteLine(numberToConvert.Message);
                
            }
            Console.ReadKey();
        }
    }
}
