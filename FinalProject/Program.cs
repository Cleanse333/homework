using System.Security.Principal;
using System.Text.Json;
using Newtonsoft.Json;

namespace FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pathjson = @"C:\Users\bsiab\source\repos\FinalProject\FinalProject\NewFolder\Account.json";
            var json = System.IO.File.ReadAllText(@"C:\Users\bsiab\source\repos\FinalProject\FinalProject\NewFolder\Account.json");
            var account = JsonConvert.DeserializeObject<Account>(json);
            bool action = true;

            while (action)
            {
                Console.WriteLine("Welcome to ATM simulator");
                Console.WriteLine("Press Enter to insert a card or type EXIT to exit");
                var input = Console.ReadLine();
                if (input == "EXIT")
                {
                    action = false;
                }
                else
                {
                    Console.WriteLine("Please enter your card number");
                    var cardNumber = Console.ReadLine();
                    Console.WriteLine("Please enter your cards expiration date");
                    var expirationDate = Console.ReadLine();
                    Console.WriteLine("Please enter your cards CVC");
                    var CVC = Console.ReadLine();
                    if (cardNumber != account.CardDetails.CardNumber || expirationDate != account.CardDetails.ExpirationDate || CVC != account.CardDetails.CVC)
                    {
                        Console.WriteLine("Please provide correct information");
                        Console.WriteLine("Ejecting you from the system");
                        action = false;
                    }
                    else
                    {
                        Console.WriteLine("Card found , please enter your pin code");
                        var pincode = Console.ReadLine();
                        if (pincode != account.PinCode)
                        {
                            Console.WriteLine("Please provide correct pincode");
                            Console.WriteLine("Ejecting you from the system");
                        }
                        else
                        {
                            Console.WriteLine($"Welcome MR {account.FirstName} {account.LastName}");
                            bool session = true;
                            while (session)
                            {
                                Console.WriteLine("MENU");
                                Console.WriteLine("1 - balance");
                                Console.WriteLine("2 - withdraw");
                                Console.WriteLine("3 - last 5 transactions");
                                Console.WriteLine("4 - deposit");
                                Console.WriteLine("5 - change PIN");
                                Console.WriteLine("6 - convert currency");
                                Console.WriteLine("7 - eject card");
                                Console.WriteLine("Enter your choice :");
                                var choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1":
                                        Console.WriteLine($"Your balance is {account.Balance}GEL");
                                        break;
                                    case "2":
                                        Console.WriteLine($"Type amount to withdraw(GEL)");
                                        var withdraw = Convert.ToDouble(Console.ReadLine());
                                        if (withdraw > account.Balance)
                                        {
                                            Console.WriteLine("Insufficient funds");
                                        }
                                        else if (withdraw <= 0)
                                        {
                                            Console.WriteLine("Please enter valid amount!");
                                        }
                                        else
                                        {
                                            account.Balance -= withdraw;
                                            Console.WriteLine("Operation was succesfull");
                                            Console.WriteLine($"Remaining balance = {account.Balance}");
                                            account.Transactions.Add(new Transaction
                                            {
                                                TransactionDate = DateTime.Now,
                                                TransactionType = "Withdrawal",
                                                AmountGEL = withdraw,
                                                AmountEUR = withdraw * 0.32,
                                                AmountUSD = withdraw * 0.37
                                            });
                                            SaveAccount(account, pathjson);
                                            LogAction($"{account.FirstName} {account.LastName} made withdrawal of {withdraw}");
                                        }
                                        break;
                                    case "3":
                                        if (account.Transactions.Count <= 5)
                                        {
                                            Console.WriteLine("you don't have 5 transactions yet");
                                            break;
                                        }
                                        else
                                        {
                                            int startindex = Math.Max(0, account.Transactions.Count - 5);
                                            for (int i = account.Transactions.Count - 1; i >= startindex; i--)
                                            {
                                                var t = account.Transactions[i];
                                                Console.WriteLine($"{t.TransactionDate:yyyy-MM-dd} | {t.TransactionType} | {t.AmountGEL} GEL | {t.AmountUSD} USD | {t.AmountEUR} EUR");
                                            }
                                        }

                                        break;
                                    case "4":
                                        Console.WriteLine("Please enter amount that you want to deposit");
                                        var deposit = Convert.ToDouble(Console.ReadLine());
                                        if (deposit <= 0)
                                        {
                                            Console.WriteLine("Please enter valid amount!");
                                        }
                                        else
                                        {
                                            account.Balance += deposit;
                                            Console.WriteLine($"You deposited {deposit}GEL");
                                            Console.WriteLine($"Balance = {account.Balance}");
                                            account.Transactions.Add(new Transaction
                                            {
                                                TransactionDate = DateTime.Now,
                                                TransactionType = "Deposit",
                                                AmountGEL = deposit,
                                                AmountEUR = deposit * 0.32,
                                                AmountUSD = deposit * 0.37
                                            });
                                            SaveAccount(account, pathjson);
                                            LogAction($"{account.FirstName} {account.LastName} made deposit of {deposit}");
                                        }
                                        break;
                                    case "5":
                                        Console.WriteLine("Are you sure you want to change your PIN? type NO to exit or hit enter to continue");
                                        var answer = Console.ReadLine();
                                        if (answer == "NO")
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please enter new 4 digit PIN");
                                            var newcode = Console.ReadLine();
                                            if (newcode.Length == 4)
                                            {
                                                account.PinCode = newcode;
                                                Console.WriteLine("Congratulations , you changed your PIN code");
                                                SaveAccount(account, pathjson);
                                                LogAction($"{account.FirstName} {account.LastName} changed their pin to - {newcode}");
                                            }
                                            }
                                            break;
                                    case "6":
                                        Console.WriteLine("Which currency you want to convert to?");
                                        Console.WriteLine("Enter 1 for EURO and 2 for USD");
                                        var curr = Console.ReadLine();
                                        if (curr == "1")
                                        {
                                            Console.WriteLine($"your balance is {account.Balance}GEL");
                                            Console.WriteLine($"converted balance is {account.Balance * 0.32}EUR");
                                        }
                                        else if (curr == "2")
                                        {
                                            Console.WriteLine($"your balance is {account.Balance}GEL");
                                            Console.WriteLine($"converted balance is {account.Balance * 0.37}USD");
                                        }
                                        break;
                                    case "7":
                                        Console.WriteLine("Ejecting card");
                                        session = false;
                                        break;
                                    default:
                                        Console.WriteLine("Option does not exist , please choose correct option");
                                        break;
                                }

                            }
                        }
                    }
                }
            }

        }

        static void SaveAccount (Account account , string path)
        {
            string updatedJson = Newtonsoft.Json.JsonConvert.SerializeObject(account , Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(path, updatedJson);
        }

        static void LogAction(string action)
        {
            if (string.IsNullOrEmpty(action))
            {
                action = "Nothing added";
            }
            string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {action}\n";
            File.AppendAllText(@"C:\Users\bsiab\source\repos\FinalProject\FinalProject\NewFolder\logs.txt", logLine);
        }
    }
}
