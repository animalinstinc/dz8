using System;

enum AccountType { Current, Savings }

class BankAccount
{
    private static int lastNumber = 0;
    private int accountNumber;
    private decimal balance;
    private AccountType accountType;
    public BankAccount()
    {
        accountNumber = GenerateNumber();
        balance = 0;
        accountType = AccountType.Current;
    }

    public BankAccount(decimal balance)
    {
        accountNumber = GenerateNumber();
        this.balance = balance;
        accountType = AccountType.Current;
    }

    public BankAccount(AccountType accountType)
    {
        accountNumber = GenerateNumber();
        balance = 0;
        this.accountType = accountType;
    }

    public BankAccount(decimal balance, AccountType accountType)
    {
        accountNumber = GenerateNumber();
        this.balance = balance;
        this.accountType = accountType;
    }
    private static int GenerateNumber()
    {
        lastNumber++;
        return lastNumber;
    }
    public int GetAccountNumber() => accountNumber;

    public decimal GetBalance() => balance;

    public AccountType GetAccountType() => accountType;
    public void Print()
    {
        Console.WriteLine($"Номер счёта: {accountNumber}");
        Console.WriteLine($"Баланс: {balance}");
        Console.WriteLine($"Тип счёта: {accountType}");
        Console.WriteLine();
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма должна быть больше нуля");
            return;
        }
        balance += amount;
    }
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > balance)
        {
            Console.WriteLine("Недостаточно средств или введена неверная сумма");
            return false;
        }
        balance -= amount;
        return true;
    }
    public bool Transfer(BankAccount from, decimal amount)
    {
        if (from.Withdraw(amount))
        {
            Deposit(amount);
            return true;
        }
        return false;
    }
}
class Program
{
    static void Main()
    {
        BankAccount first = new BankAccount(1500m, AccountType.Current);
        first.Deposit(1000m);
        BankAccount second = new BankAccount(2345m, AccountType.Current);
        second.Withdraw(324m);
        BankAccount third = new BankAccount(42132m, AccountType.Savings);
        third.Deposit(4325m);
        BankAccount fourth = new BankAccount();
        BankAccount fifth = new BankAccount(AccountType.Savings);
        second.Transfer(first, 324m);
        first.Transfer(third, 4135m);
        third.Transfer(second, 1m);
        first.Print();
        second.Print();
        third.Print();
        fourth.Print();
        fifth.Print();
    }
}