using System;
using System.Threading;

class BankAccount
{
    // Property to store the account balance
    public int Balance { get; private set; }

    // Mutex to protect shared resources
    private readonly Mutex mutex = new Mutex();

    // Constructor to initialize the account with an initial balance
    public BankAccount(int initialBalance)
    {
        Balance = initialBalance;
    }

    // Method to transfer money from this account to another account with a timeout
    public bool Transfer(BankAccount target, int amount, int timeout)
    {
        // Acquire locks for both accounts with a timeout
        if (Mutex.WaitAll(new[] { mutex, target.mutex }, timeout))
        {
            try
            {
                // Perform the transfer
                Balance -= amount; // Subtract the amount from the source account
                target.Balance += amount; // Add the amount to the target account
                return true; // Transfer successful
            }
            finally
            {
                // Release locks in the reverse order
                target.mutex.ReleaseMutex();
                mutex.ReleaseMutex();
            }
        }
        else
        {
            // If the timeout occurs, return false
            Console.WriteLine("Transfer failed due to timeout.");
            return false; // Transfer failed
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create two bank accounts with initial balances of 1000
        BankAccount account1 = new BankAccount(1000);
        BankAccount account2 = new BankAccount(1000);

        // Create a thread to transfer money from account1 to account2
        Thread thread1 = new Thread(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                if (!account1.Transfer(account2, 10, 100)) // Transfer 10 units with a timeout of 100ms
                {
                    Console.WriteLine("Thread1: Transfer failed.");
                }
                else
                {
                    Console.WriteLine($"Transferred 10 from Account1 to Account2, Balance1: {account1.Balance}, Balance2: {account2.Balance}");
                }
            }
        });

        // Create a thread to transfer money from account2 to account1
        Thread thread2 = new Thread(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                if (!account2.Transfer(account1, 10, 100)) // Transfer 10 units with a timeout of 100ms
                {
                    Console.WriteLine("Thread2: Transfer failed.");
                }
                else
                {
                    Console.WriteLine($"Transferred 10 from Account2 to Account1, Balance1: {account1.Balance}, Balance2: {account2.Balance}");
                }
            }
        });

        // Start both threads
        thread1.Start();
        thread2.Start();

        // Wait for both threads to finish
        thread1.Join();
        thread2.Join();

        // Display the final balances
        Console.WriteLine($"Final Balance1: {account1.Balance}, Final Balance2: {account2.Balance}");
    }
}