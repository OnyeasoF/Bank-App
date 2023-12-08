using System;

class BankAccount
{
    private static int accountNumberCounter = 1000000000; // Starting account number
    private readonly int accountNumber;
    private decimal balance;

    public BankAccount()
    {
        accountNumber = accountNumberCounter++;
        balance = 0;
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account Number: {accountNumber}");
        Console.WriteLine($"Current Balance: {balance:C}");
    }

    public void FundAccount(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"Funded {amount:C} into your account.");
    }

    public void TransferMoney(BankAccount receiver, decimal amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            receiver.balance += amount;
            Console.WriteLine($"Transferred {amount:C} to account number {receiver.accountNumber}");
        }
        else
        {
            Console.WriteLine("Insufficient funds to transfer.");
        }
    }

    public void WithdrawFunds(decimal amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C} from your account.");
        }
        else
        {
            Console.WriteLine("Insufficient funds to withdraw.");
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount account1 = new BankAccount();
        BankAccount account2 = new BankAccount();

        // Checking balance
        account1.CheckBalance();
        account2.CheckBalance();

        // Funding account
        account1.FundAccount(500);
        account2.FundAccount(1000);

        // Checking balance after funding
        account1.CheckBalance();
        account2.CheckBalance();

        // Transferring money from account2 to account1
        account2.TransferMoney(account1, 300);

        // Checking balance after transfer
        account1.CheckBalance();
        account2.CheckBalance();

        // Withdrawing funds from account1
        account1.WithdrawFunds(200);

        // Checking balance after withdrawal
        account1.CheckBalance();
    }
}
