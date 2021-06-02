using System;
using System.Collections.Generic;
using BankChallenge.Class;
using BankChallenge.Enum;

namespace BankChallenge
{
    class Program
    {
        static List<Account> accounts = new List<Account>();
        static string userOption = UserOption();
        static void Main(string[] args)
        {

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        NewAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdrow();
                        break;
                    case "5":
                        Deposit();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = UserOption();
            }

            Console.Clear();
        }

        private static void NewAccount()
        {
            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("New Account");
            Console.Write("1 for a Physical Person or 2 for a Legal Person: ");
            int accountType = int.Parse(Console.ReadLine());

            Console.WriteLine("Name of account");
            string accountName = Console.ReadLine().ToUpper();

            Console.WriteLine("Balance");
            decimal accountBalance = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Credit");
            decimal accountCredit = decimal.Parse(Console.ReadLine());

            Account account = new Account(name: accountName, balance: accountBalance, 
                                            credit: accountCredit, account: (AccountType)accountType);

            accounts.Add(account);

            Console.Clear();
        }
      
        private static void ListAccounts()
        {
            Console.Clear();
            Console.WriteLine();

            foreach (var account in accounts)
            {
                Console.WriteLine(account.ToString());
            }
        }

        private static void Transfer()
        {
            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("Perform bank transfer");
            Console.WriteLine();

            Console.WriteLine("Origin Account:");
            int originAccount = int.Parse(Console.ReadLine());
            Account isOriginAccount = accounts.Find(a => a.GetAccountId == originAccount);

            Console.WriteLine("Destiny Account:");
            int destinyAccount = int.Parse(Console.ReadLine());
            Account isDestinyAccount = accounts.Find(a => a.GetAccountId == destinyAccount);

            Console.WriteLine("Transver value:");
            decimal value = int.Parse(Console.ReadLine());

            isOriginAccount.Transfer(isOriginAccount.GetAccountId, value, isDestinyAccount);
        }
      
        private static void Withdrow()
        {
            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("Withdrow");
            Console.WriteLine();

            Console.WriteLine("Account:");
            int withdrowAccount = int.Parse(Console.ReadLine());
            Account isAccount = accounts.Find(a => a.GetAccountId == withdrowAccount);

            Console.WriteLine("Withdrow amount:");
            decimal value = int.Parse(Console.ReadLine());

            isAccount.Withdrow(isAccount.GetAccountId, value);
        }

        private static void Deposit()
        {
            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("Deposit");
            Console.WriteLine();

            Console.WriteLine("Account:");
            int depositAccount = int.Parse(Console.ReadLine());
            Account isAccount = accounts.Find(a => a.GetAccountId == depositAccount);

            Console.WriteLine("Deposit amount:");
            decimal value = int.Parse(Console.ReadLine());

            isAccount.Deposit(isAccount.GetAccountId, value);
        }

        private static string UserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Bank Challenge!!!");
            Console.WriteLine("Enter your option:");
            Console.WriteLine();

            Console.WriteLine("1- List all accounts");
            Console.WriteLine("2- Add new account");
            Console.WriteLine("3- Tranfer");
            Console.WriteLine("4- Withdrow");
            Console.WriteLine("5- Deposit");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
