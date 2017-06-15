using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinnishBankAccountNumber
{
    class FinnishBankAccountNumber
    {
        public string AccountNumber { get; set; }
        public string Message { get; set; }

        public FinnishBankAccountNumber(string number)
        {
            AccountNumber = number;
        }

        public string ToMachineForm()
        {
            string accNumber = string.Empty;
            if (AccountNumber.Length < 8 || AccountNumber.Length > 14 || AccountNumber[6] != '-')
            {
                return "Invalid account number. Proper account number is 8-14 numbers long and contains dash after first 6 numbers";
            }

            accNumber = AccountNumber.Remove(6, 1);        

            if (!accNumber.All(Char.IsDigit))
            {
                return "Invalid account number. No letters allowed";
            }

            if (accNumber[0].Equals('4') || accNumber[0].Equals('5'))
            {
                while (accNumber.Length < 14)
                {
                    accNumber = accNumber.Insert(7, "0");
                }
            }
            else
            {
                while (accNumber.Length < 14)
                {
                    accNumber = accNumber.Insert(6, "0");
                }
            }

            string checksum = HasValidChecksum(accNumber);

            if (checksum == accNumber.Substring(accNumber.Length -1))
            {
                Message = "Account number is valid. Checksum " + checksum + " is equal to the last digit.";
            }
            else
            {
                Message = "Account number is invalid. Checksum " + checksum + " is not equal to the last digit.";
            }
            return "Account number " + AccountNumber + " in machine form is: " +  accNumber;
        }

        public string HasValidChecksum(string numberToCheck)
        {
            int total = 0;

            for (int i = 12; i >= 0; i--)
            {
                int number = int.Parse(numberToCheck[i].ToString());
              
                if (i % 2 == 0)
                {
                    if ((number * 2) > 9)
                    {
                        total = total + 1 + (number * 2) % 10;
                    }
                    else
                    {
                        total = total + number * 2;
                    }
                }
                else
                {
                    total = total + number;
                }
            }

            if (total % 10 == 0)
            {
                total = 0;
            }
            else
            {
                total = 10 - total % 10;
            }
            
            return total.ToString();
        }


        public override string ToString()
        {
            return AccountNumber;
        }
    }
}
