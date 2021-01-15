using System;

namespace FirstBankOfSuncoastv2
{
    class Transaction
    {
        private int Deposit { get; set; }
        private int Withdraw { get; set; }
        public int Savings { get; set; }
        public int Checking { get; set; }

        var checkingSavings = new List<Transaction>



    }

    class Program
    {
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to The First Bank of Suncoast");
            var hasQuitTheApplication = false;
            while (hasQuitTheApplication == false)
            {
                // Show them a menu of options they can do
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
                var choice = Console.ReadLine().ToUpper().Trim();
                if (choice == "Quit")
                {
                    return
                  }

                if choice == ("VIEW")
                {
                    Console.WriteLine(Transactions);


                }
            }
            static void Main(string[] args)
            {
                var savingsBalance = 0;
                var checkingBalance = 0;
                Menu()
                {
                    quit = true;
                    Console.WriteLine("-----Good bye----");
                }
                else
                {
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
                        var savingsCsvReader = new CsvReader(savingsFileReader, CultureInfo.InvariantCulture);
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

                }
                var checkingFileWriter = new StreamWriter("checkingtransactions.csv");
                var checkingCsvWriter = new CsvWriter(checkingFileWriter, CultureInfo.InvariantCulture);
                checkingCsvWriter.WriteRecords(checkingTransactions);
                checkingFileWriter.Close();
                var savingsFileWriter = new StreamWriter("savingstransactions.csv"); var savingsCsvWriter = new CsvWriter(savingsFileWriter, CultureInfo.InvariantCulture);
                savingsCsvWriter.WriteRecords(savingsTransactions);
                savingsFileWriter.Close();
            }
        }
    }
}