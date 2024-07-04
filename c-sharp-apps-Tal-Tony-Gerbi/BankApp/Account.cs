using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.BankApp
{
    public class Account
    {
        private Owner owner;
        private double balance;
        private int overdraft;
        private const int MAX_OVERDRAFT = 90000;

        public Account(Owner owner, double balance, int overdraft)
        {
            this.owner = owner;
            this.balance = balance;
            this.overdraft = overdraft;
        }
        public Owner GetOwner()
        {
            return this.owner;
        }
        public double GetBalance()
        {
            return this.balance;
        }
        public int GetOverDraft()
        {
            return this.overdraft;
        }
        public void SetOverdraft(int overdraft)
        {
            if (overdraft <= MAX_OVERDRAFT)
            {
                this.overdraft = overdraft;
            }

        }
        public void Deposit(double amount)
        {
            this.balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (this.balance - amount >= -this.overdraft)
                this.balance -= amount;
        }
    }
}
