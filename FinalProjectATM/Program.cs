class FinalProjectATM
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("This is ATM program");
            Console.WriteLine("choose from the following options");
            Console.WriteLine("To Check Balance - Enter 1");
            Console.WriteLine("To Deposit Money - Enter 2");
            Console.WriteLine("To Withdraw Money - Enter 3");
            Console.WriteLine("To Finish Operations - Enter 0");

            int number = Int32.Parse(Console.ReadLine());

            switch (number)
            {
                case 0:
                    Console.WriteLine("Thank you for using our ATM. Bye");
                    break;
                case 1:
                    CheckBalance();
                    break;
                case 2:
                    DepositMoney();
                    break;
                case 3:
                    WithdrawMoney();
                    break;
                default:
                    Console.WriteLine("Invalid Option. Try Again.");
                    break;
            }
        }
    }

    private static void CheckBalance()
    {
        Console.Write("Enter your user ID: ");
        string userID = Console.ReadLine();

        string userMoney = GetUserinfo(userID);
        if (userMoney != null)
        {
            double balance = double.Parse(userMoney);
            Console.WriteLine($"Balance: {balance}");
        }
        else
        {
            Console.WriteLine("user not found");
        }
    }

    private static void DepositMoney()
    {
        Console.Write("Enter your user ID: ");
        string userID = Console.ReadLine();
        string userMoney = GetUserinfo(userID);

        if (userMoney != null)
        {
            double money = double.Parse(userMoney);
            Console.Write("Enter deposit amount: ");
            double deposit = double.Parse(Console.ReadLine());
            money += deposit;
            UpdateBalance(userID, money);
            string balance = GetUserinfo(userID);
            Console.WriteLine("the balance is: " + balance);
        }
        else
        {
            Console.WriteLine("user not found");
        }
    }

    private static void WithdrawMoney()
    {
        Console.Write("Enter your user ID: ");
        string userID = Console.ReadLine();
        string userMoney = GetUserinfo(userID);

        if (userMoney != null)
        {
            double money = double.Parse(userMoney);
            Console.Write("Enter amount to withdraw: ");
            double minusMoney = double.Parse(Console.ReadLine());
            money -= minusMoney;
            UpdateBalance(userID, money);
            string balance = GetUserinfo(userID);
            Console.WriteLine("the balance is: " + balance);
        }
        else
        {
            Console.WriteLine("user not found");
        }
    }

    private static void UpdateBalance(string userID, double money)
    {
        string[] userInfo = File.ReadAllLines("ATMFile.txt");
        for (int i = 0; i < userInfo.Length; i++)
        {
            string[] temp = userInfo[i].Split(',');
            if (temp[0] == userID)
            {
                temp[1] = money.ToString(); //updatebs balancs
                userInfo[i] = string.Join(",", temp);
                File.WriteAllLines("ATMFile.txt", userInfo);
                return;
            }
        }
    }
    private static string GetUserinfo(string userID)
    {
        //file line _ userID, money. 
        string[] userInfo = File.ReadAllLines("ATMFile.txt");
        foreach (string line in userInfo)
        {
            string[] temp = line.Split(',');
            if (temp[0] == userID)
            {
                return temp[1];
            }
        }
        return null;
    }
    /*
    private static bool IsInteger(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }
    */
}