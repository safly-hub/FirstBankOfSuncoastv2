using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;

namespace FirstBankOfSuncoastv2
{
    class Transaction
    {
        public string TransactionType { get; set; }
        public int ChangeOfBalance { get; set; }
        public string TransactionHistory()
        {
            var transactionHistory = $"{TransactionType} for {ChangeOfBalance}";
            return transactionHistory;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var savingsAccountBalance = 0;
            var checkingAccountBalance = 0;
            // Create a list to to track transfers
            var checkingTransactions = new List<Transaction>();
            if (File.Exists("checkingtransactions.csv"))
            {
                var checkingFileReader = new StreamReader("checkingtransactions.csv");
                var checkingCsvReader = new CsvReader(checkingFileReader, CultureInfo.InvariantCulture);
                // checkingCsvReader.Configuration.HasHeaderRecord = false;
                checkingTransactions = checkingCsvReader.GetRecords<Transaction>().ToList();
            }
            foreach (var check in checkingTransactions)
            {
                if (check.TransactionType == "Deposit")
                {
                    checkingAccountBalance += check.ChangeOfBalance;
                }
                else
                {
                    checkingAccountBalance -= check.ChangeOfBalance;
                }
            }
            var savingsTransactions = new List<Transaction>();
            if (File.Exists("savingstransactions.csv"))
            {
                var savingsFileReader = new StreamReader("savingstransactions.csv");
                var savingsCsvReader = new csvReader(savingsFileReader, CultureInfo.InvariantCulture);
                // savingsCsvReader.Configuration.HasHeaderRecord = false;
                savingsTransactions = savingsCsvReader.GetRecords<Transaction>().ToList();
            }
            foreach (var save in savingsTransactions)
            {
                if (save.TransactionType == "Deposit")
                {
                    savingsAccountBalance += save.ChangeOfBalance;
                }
                else
                {
                    savingsAccountBalance -= save.ChangeOfBalance;
                }
            }
            Console.WriteLine();
            Console.WriteLine(" - - - - - - ---------------------------------- - - - - - - -");
            Console.WriteLine(" - - - - - -Welcome to The First Bank of Suncoast- - - - - - - -");
            Console.WriteLine(" - - - - - - ---------------------------------- - - - - - - -");
            Console.WriteLine();
            var hasQuitTheApplication = false;
            while (hasQuitTheApplication == false)
            {
                Console.WriteLine();
                Console.WriteLine("Select an option from the Menu below:");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("BALANCE - View balances of your accounts");
                Console.WriteLine();
                Console.WriteLine("TRANSACTIONS - View transaction history.");
                Console.WriteLine();
                Console.WriteLine("WITHDRAW - Take out money from your accounts");
                Console.WriteLine();
                Console.WriteLine("DEPOSIT - Place money in your accounts");
                Console.WriteLine();
                Console.WriteLine("QUIT - Quit the program!");
                Console.WriteLine();
                Console.Write("Choice: ");
                var choice = Console.ReadLine().ToUpper();
                if (choice == "QUIT")
                {
                    hasQuitTheApplication = true;
                }
                if (choice == "DEPOSIT")
                {
                    Console.WriteLine("Please select which account to deposit into, CHECKING or SAVINGS");
                    var answer = Console.ReadLine().ToUpper();
                    if (answer == "CHECKING")
                    {
                        Console.WriteLine("How much would you like to deposit");
                        var depositAmount = int.Parse(Console.ReadLine());
                        var newTransaction = new Transaction
                        {
                            TransactionType = "Deposit",
                            ChangeOfBalance = depositAmount
                        }
                        var newCheckingAccountBalance = checkingAccountBalance + newTransaction.ChangeOfBalance;
                        checkingAccountBalance = newCheckingAccountBalance;
                        Console.WriteLine(checkingAccountBalance)
                        Add.Transaction => < List > checkingTransactions
                    }
                    if (answer == "SAVINGS")
                    {
                        Console.WriteLine("How much would you like to deposit?");
                        var depositAmount = int.Parse(Console.ReadLine());
                        var newTransaction = new Transaction
                        {
                            TransactionType = "Deposit",
                            ChangeOfBalance = depositAmount
                        };
                        var newSavingsAccountBalance = savingsAccountBalance + newTransaction.ChangeOfBalance;
                        savingsAccountBalance = newSavingsAccountBalance;
                        Console.WriteLine(savingsAccountBalance);
                        savingsTransactions.Add(newTransaction);
                    }
                }
                if (choice == "WITHDRAW")
                {
                    Console.WriteLine("Please select which account to withdraw from, CHECKING or SAVINGS");
                    var answer = Console.ReadLine().ToUpper();
                    if (answer == "CHECKING")
                    {
                        Console.WriteLine();
                        Console.WriteLine("How much would you like to withdraw?");
                        var withdrawAmount = int.Parse(Console.ReadLine());
                        var newTransaction = new Transaction
                        {
                            TransactionType = "Withdraw",
                            ChangeOfBalance = withdrawAmount
                        }

                        if (withdrawAmount < checkingAccountBalance)
                        {
                            var newCheckingAccountBalance = checkingAccountBalance - newTransaction.ChangeOfBalance;
                            checkingAccountBalance = newCheckingAccountBalance;
                            Console.WriteLine(checkingAccountBalance);
                            checkingTransactions.Add(newTransaction);
                        }
                        else
                        {

                            Console.WriteLine("Insufficient Funds.");

                        }
                    }
                    if (answer == "SAVINGS")
                    {
                        Console.WriteLine("How much would you like to withdraw?");
                        var withdrawAmount = int.Parse(Console.ReadLine());
                        var newTransaction = new Transaction
                        {
                            TransactionType = "Withdraw",
                            changeOfBalance = WithdrawAmount
                        }
                        if (userInput < savingsAccountBalance)
                        {
                            var newSavingsAccountBalance = savingsAccountBalance - newTransaction.ChangeOfBalance;
                            savingsAccountBalance = newSavingsAccountBalance;
                            Console.WriteLine(savingsAccountBalance);
                            savingsTransactions.Add(newTransaction);
                            Console.WriteLine("The funds have been withdrawn from your Savings account");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Funds.");
                        }
                    }

                    if (choice == "BALANCE")
                    {
                        Console.WriteLine($"The balance of your checking account is { checkingAccountBalance } and your savings account balance is { savingsAccountBalance }");
                        var answer = Console.ReadLine().ToUpper();
                    }
                    if (choice == "TRANSACTIONS")
                    {
                        Console.WriteLine("View transaction history of CHECKING or SAVINGS?");
                        var viewCheckingOrSavingsTransaction = Console.ReadLine().ToUpper();
                        if (answer == "CHECKING")
                        {
                            foreach (var transaction in checkingTransactions)
                            {
                                Console.WriteLine(transaction.TransactionHistory());
                            }
                        }
                        if (answer == "SAVINGS")
                        {
                            foreach (var transaction in savingsTransactions)
                            {
                                Console.WriteLine(transaction.TransactionHistory());
                            }
                        }
                    }
                    Console.WriteLine("Thank you!");
                }
                var checkingFileWriter = new StreamWriter("checkingtransactions.csv");
                var checkingCsvWriter = new CsvWriter(checkingFileWriter, CultureInfo.InvariantCulture);
                checkingCsvWriter.WriteRecords(checkingTransactions);
                checkingFileWriter.Close();
                var savingsFileWriter = new StreamWriter("savingstransactions.csv");
                var savingsCsvWriter = new CsvWriter(savingsFileWriter, CultureInfo.InvariantCulture);
                savingsCsvWriter.WriteRecords(savingsTransactions);
                savingsFileWriter.Close();
            }
        }
    }
}