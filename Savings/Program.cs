using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Savings
{


    public class Accounts
    {
        public string AccountName;
        private decimal Balance=0;
        public bool Withdraw (decimal amount)
        { if (Balance < amount)
        { return false; }
        Balance = Balance - amount;
        return true;
        }
        public void Deposit (decimal amount)
        { Balance = Balance + amount; }
        public decimal GetBalance()
        { return Balance; }
        public string StatementReason;
    };

   

    class Savings
    


    {
        

        static void Main()
            
       {
           


            int select;
            string menuString2;
            try
            {
                Console.WriteLine(@"
MENU
====

1. Add to balance

2. Create Account

3. Check balance

4. Withdraw from balance


Please type the number of your selection and press ENTER:");
                menuString2 = Console.ReadLine();
                select = int.Parse(menuString2);


                switch (select)
                {
                    case 1:
                        Console.Clear();
                        AddBalance();
                        break;
                    case 2:
                        Console.Clear();
                        CreateAccount();
                        break;
                    case 3:
                        Console.Clear();
                        CheckBalance();
                        break;
                    case 4:
                        Console.Clear();
                        MinusBalance();
                        break;
                    default:
                        Console.WriteLine("Invalid Number Entered");
                        Main();
                        break;
                }

            }
            catch
            {
                Console.Clear();
                Console.WriteLine(@"

ERROR
=====

Invalid value entered. Enter 1 or 2 then press ENTER

");
                Main();
            }
            
            
            
            
        
        } 

        static void CheckBalance()
        {
            //initial setup
            string name;
            int select;
            string menustring;
            
            //account selection (poss switch TBC)
            Console.WriteLine(@"ACCOUNT LIST
============
");
            
            StreamReader listreader = new StreamReader("accountlist.txt");
            while (listreader.EndOfStream == false)
            {
                string line = listreader.ReadLine();
                Console.WriteLine(line);
            }
            listreader.Close();
            
            Console.WriteLine(@"
Enter account name as it appears above:-
");
            name = Console.ReadLine();
            Console.Clear();
            
            //loading of balance from file & display results
            StreamReader reader = new StreamReader(name);
            while (reader.EndOfStream == false) 
            { string line = reader.ReadLine();
            Console.WriteLine(line);
            
            }
            reader.Close();

            //option to return to main
            try
            {
                Console.WriteLine(@"

MENU
====

1. Main Menu

2. Check Balance of another account


Please type the number of your selection and press ENTER:");
                menustring = Console.ReadLine();
                select = int.Parse(menustring);


                switch (select)
                {
                    case 1:
                        Console.Clear();
                        Main();
                        break;
                    case 2:
                        Console.Clear();
                        CheckBalance();
                        break;
                    default:
                        Console.WriteLine("Invalid Number Entered, returning to main menu...");
                        Main();
                        break;
                }
            }

            catch
            {
                Console.Clear();
                Console.WriteLine(@"

ERROR
=====

Invalid value entered. Enter 1 or 2 then press ENTER

");
               Main();
            }
        }

        static void AddBalance()
        { // initial setup
            string name, amount, initialstring, menustring;
            int select;
            decimal initial, deposit;
            
            //account selection (possibly change to a switch TBC)
            Console.WriteLine(@"ACCOUNT LIST
============
");

            StreamReader listreader = new StreamReader("accountlist.txt");
            while (listreader.EndOfStream == false)
            {
                string line = listreader.ReadLine();
                Console.WriteLine(line);
            }
            listreader.Close();

            Console.WriteLine(@"
Enter account name as it appears above:-
");
            name = Console.ReadLine();
            
            //object creation (poss wrong terminology)
            Accounts SilverAccounts;
            SilverAccounts = new Accounts();
            
            //loading of saved file of account TBC
            StreamReader reader = new StreamReader(name);
            name = reader.ReadLine();
            initialstring = reader.ReadLine();
            reader.Close();
            SilverAccounts.AccountName = name;
            initial = decimal.Parse(initialstring);
            SilverAccounts.Deposit(initial);
            
            
            //deposit amount
            Console.WriteLine("Enter deposited amount:-");
            amount = Console.ReadLine();
            deposit = decimal.Parse(amount);
            SilverAccounts.Deposit(deposit);
            Console.WriteLine(SilverAccounts.AccountName);

            //display updated balance
            Console.WriteLine("New balance is:-");
            Console.WriteLine(SilverAccounts.GetBalance());

            //save file
            StreamWriter writer;
            writer = new StreamWriter(name);
            writer.WriteLine(name);
            writer.WriteLine(SilverAccounts.GetBalance());
            writer.Close();

            //menu to return
            try
            {
                Console.WriteLine(@"

MENU
====

1. Main Menu

2. Make another deposit


Please type the number of your selection and press ENTER:");
                menustring = Console.ReadLine();
                select = int.Parse(menustring);


                switch (select)
                {
                    case 1:
                        Console.Clear();
                        Main();
                        break;
                    case 2:
                        Console.Clear();
                        AddBalance();
                        break;
                    default:
                        Console.WriteLine("Invalid Number Entered");
                        CheckBalance();
                        break;
                }
            }

            catch
            {
                Console.Clear();
                Console.WriteLine(@"

ERROR
=====

Invalid value entered. Returning to Main Menu...

");
                Main();
            }

        }
        static void CreateAccount()
        {
            //initial setup
            string name, amountstring;
            decimal initialbalance;
                        
            //data entry
            Console.WriteLine(@"ACCOUNT CREATION
================

Please enter the name of the account:- ");
            name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(@"ACCOUNT CREATION
================

Please enter the initial balance of the account:- ");
            amountstring = Console.ReadLine();
            initialbalance = decimal.Parse(amountstring);
            
            //account creation
            Accounts SilverAccounts;
            SilverAccounts = new Accounts();
            SilverAccounts.AccountName = name;
            SilverAccounts.Deposit(initialbalance);
            
            //add account to account list
            StreamWriter accountlistwriter;
            accountlistwriter = File.AppendText("accountlist.txt");
            accountlistwriter.WriteLine(name);
            accountlistwriter.Close();


            //save to file
            StreamWriter writer;
            writer = new StreamWriter(name);
            writer.WriteLine(name);
            writer.WriteLine(SilverAccounts.GetBalance());
            writer.Close();

            Console.Clear();
            Main();

            
        }

        static void MinusBalance()
        { // initial setup
            string name, amount, initialstring, menustring;
            int select;
            decimal initial, withdraw;

            //account selection (possibly change to a switch TBC)
            Console.WriteLine(@"ACCOUNT LIST
============
");

            StreamReader listreader = new StreamReader("accountlist.txt");
            while (listreader.EndOfStream == false)
            {
                string line = listreader.ReadLine();
                Console.WriteLine(line);
            }
            listreader.Close();

            Console.WriteLine(@"
Enter account name as it appears above:-
");
            name = Console.ReadLine();

            //object creation (poss wrong terminology)
            Accounts SilverAccounts;
            SilverAccounts = new Accounts();

            //loading of saved file of account TBC
            StreamReader reader = new StreamReader(name);
            name = reader.ReadLine();
            initialstring = reader.ReadLine();
            reader.Close();
            SilverAccounts.AccountName = name;
            initial = decimal.Parse(initialstring);
            SilverAccounts.Deposit(initial);


            //withdraw amount
            Console.WriteLine("Enter withdrawn amount:-");
            amount = Console.ReadLine();
            withdraw = decimal.Parse(amount);
            SilverAccounts.Withdraw(withdraw);
                        
            //display updated balance
            Console.WriteLine(SilverAccounts.AccountName);
            Console.WriteLine("New balance is:-");
            Console.WriteLine(SilverAccounts.GetBalance());

            //save file
            StreamWriter writer;
            writer = new StreamWriter(name);
            writer.WriteLine(name);
            writer.WriteLine(SilverAccounts.GetBalance());
            writer.Close();

            //menu to return
            try
            {
                Console.WriteLine(@"

MENU
====

1. Main Menu

2. Make another withdrawal


Please type the number of your selection and press ENTER:");
                menustring = Console.ReadLine();
                select = int.Parse(menustring);


                switch (select)
                {
                    case 1:
                        Console.Clear();
                        Main();
                        break;
                    case 2:
                        Console.Clear();
                        MinusBalance();
                        break;
                    default:
                        Console.WriteLine("Invalid Number Entered, returning to Main Menu...");
                        Main();
                        break;
                }
            }

            catch
            {
                Console.Clear();
                Console.WriteLine(@"

ERROR
=====

Invalid value entered. Returning to Main Menu...

");
                Main();
            }

        }

        
       

    }

}

