using System;
using BankChallenge.Enum;

namespace BankChallenge.Class
{
    public class Account
    {
        private int AccountId { get; set; }
        private string Name { get; set; }
        private decimal Balance { get; set; }
        private decimal Credit { get; set; }
        private AccountType AccountType { get; set; }

        public int GetAccountId
        {
            get { return AccountId; }
        }
        protected int RandonAccountID(){
            var random = new Random();

            return random.Next(1000);
        }

        public Account(string name, decimal balance, decimal credit, AccountType account)
        {
            this.AccountId = RandonAccountID();
            this.Name = name;
            this.Balance = balance;
            this.Credit = credit;
            this.AccountType = account;
        }

        public void Deposit(int account, decimal value)
        {
            if (this.AccountId == account)
            {
                if (value > 0)
                {   
                    this.Balance += value;
                    Console.WriteLine(this.ToString());
                }
            }
            else
            {
                Console.WriteLine("Account for Deposit not found");
            }
            
        }    
        public bool Withdrow(int account, decimal value)
        {
            if (this.AccountId == account)
            {
                if (this.Balance - value < (this.Credit * -1))
                {
                    Console.WriteLine("Insufficient funds");
                    return false;
                }
                else
                {
                    this.Balance -= value;
                    Console.WriteLine(this.ToString());
                }
            }
            else
            {
                Console.WriteLine("Account fro withdrow not found");
                return false;
            }

            return true;
        }
        public void Transfer(int originAccount, decimal value, Account destinyAccount)
        {
           
            if(this.Withdrow(originAccount, value))
            {
                destinyAccount.Deposit(destinyAccount.AccountId, value);
            }
            else
            {
                Console.WriteLine("Unable to transfer");
            }
        }
        
        public override string ToString(){
            return $"# {this.AccountId } | Name: {this.Name} | Balance: {this.Balance} | Credit: {this.Credit} | Account Type: {this.AccountType}";
        }

    }
}