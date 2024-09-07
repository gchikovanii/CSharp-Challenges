﻿using System.Threading.Tasks.Dataflow;

namespace State
{
    public abstract class BankAccountState
    {
        public BankAccount BankAccount { get; protected set; } = null!;
        public decimal Balance { get; protected set; }
        public abstract void Deposit(decimal amount);
        public abstract void WithDraw(decimal amount);

    }
    public class RegularState : BankAccountState
    {
        public RegularState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }
        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()} depositing {amount}");
            Balance += amount;
            if(Balance >= 1000)
                BankAccount.BankAccountState = new GoldState(Balance,BankAccount);
        }

        public override void WithDraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()} withdrawing {amount}");
            Balance -= amount;
            if (Balance < 0)
            {
                BankAccount.BankAccountState = new OverDrownState(Balance, BankAccount);
            }
        }
    }
    public class OverDrownState : BankAccountState
    {
        public OverDrownState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }
        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()} depositing {amount}");
            Balance += amount;
            if (Balance >= 0)
            {
                BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
            }
        }

        public override void WithDraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()} cannot withdraw money, balance is {Balance}");

        }
    }
    public class BankAccount
    {
        public BankAccountState BankAccountState { get; set; }
        public decimal Balance
        {
            get { return BankAccountState.Balance; }

        }
        public BankAccount()
        {
            BankAccountState = new RegularState(200, this);
        }
        public void Deposit(decimal amount)
        {
            BankAccountState.Deposit(amount);
        }
        public void WithDraw(decimal amount)
        {
            BankAccountState.WithDraw(amount);
        }

    }
    public class GoldState : BankAccountState
    {
        public GoldState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }
        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()} depositing {amount} plus bonus 10%: {amount / 10}");
            Balance += amount + (amount / 10);
        }

        public override void WithDraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()} cannot withdraw money, balance is {Balance}");
            Balance -= amount;
            if (Balance < 1000 && Balance >= 0)
                BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
            else if(Balance < 0)
                BankAccount.BankAccountState = new OverDrownState(Balance, BankAccount);
        }
    }
}
