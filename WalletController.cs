namespace MyWallet;

static class WalletController
{
    static public void HandleWalletOperations<T>(Wallet<T> wallet) where T : Currency
    {
        Console.WriteLine($"Choose an option for {typeof(T).Name} Wallet:");
        Console.WriteLine("1. Add Funds");
        Console.WriteLine("2. Get Amount");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                AddOperation(wallet);
                break;
            case 2:
                GetOperation(wallet);
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    static void AddOperation<T>(Wallet<T> wallet) where T : Currency
    {
        Console.WriteLine("Which currency are you adding:");
        Console.WriteLine("1. Dollar");
        Console.WriteLine("2. Euro");

        int currencyChoice = int.Parse(Console.ReadLine());

        Console.WriteLine($"Enter the amount: ");
        decimal amountToAdd = Math.Round(decimal.Parse(Console.ReadLine()), 2);

        if (currencyChoice == 1)
        {
            if (typeof(T).Name != "Dollar")
            {
                amountToAdd = Utils.ConvertCurrency(amountToAdd, "Dollar", typeof(T).Name);
            }
            wallet.AddFunds(amountToAdd);
        }
        else if (currencyChoice == 2)
        {
            if (typeof(T).Name != "Euro")
            {
                amountToAdd = Utils.ConvertCurrency(amountToAdd, "Euro", typeof(T).Name);
            }
            wallet.AddFunds(amountToAdd);
        }
        else
        {
            Console.WriteLine("Invalid currency choice. Please enter 1 for Dollar or 2 for Euro.");
        }
    }

    static void GetOperation<T>(Wallet<T> wallet) where T : Currency
    {
        Console.WriteLine("Choose the currency for getting the amount:");
        Console.WriteLine("1. Dollar");
        Console.WriteLine("2. Euro");

        int currencyChoiceGetAmount = int.Parse(Console.ReadLine());

        if (currencyChoiceGetAmount == 1)
        {
            if (typeof(T).Name != "Dollar")
            {
                decimal convertedBalance = Utils.ConvertCurrency(wallet.GetBalance(), typeof(T).Name, "Dollar");
                Console.WriteLine($"Balance: {convertedBalance} Dollar");
            }
            else
            {
                Console.WriteLine($"Balance: {wallet.GetBalance()} Dollar");
            }
        }
        else if (currencyChoiceGetAmount == 2)
        {
            if (typeof(T).Name != "Euro")
            {
                decimal convertedBalance = Utils.ConvertCurrency(wallet.GetBalance(), typeof(T).Name, "Euro");
                Console.WriteLine($"Balance: {convertedBalance} Euro");
            }
            else
            {
                Console.WriteLine($"Balance: {wallet.GetBalance()} Euro");
            }
        }
        else
        {
            Console.WriteLine("Invalid currency choice. Please enter 1 for Dollar or 2 for Euro.");
        }
    }

    static public void ExchangeFunds(Wallet<Dollar> dollarWallet, Wallet<Euro> euroWallet)
    {
        Console.WriteLine("Select transaction direction:");
        Console.WriteLine("1. Euro Wallet -> Dollar Wallet");
        Console.WriteLine("2. Dollar Wallet -> Euro Wallet");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                PerformExchange(euroWallet, dollarWallet);
                break;
            case 2:
                PerformExchange(dollarWallet, euroWallet);
                break;
            default:
                Console.WriteLine("Invalid direction choice. Please enter 1 or 2.");
                break;
        }
    }

    static void PerformExchange<TFrom, TTo>(Wallet<TFrom> fromWallet, Wallet<TTo> toWallet)
        where TFrom : Currency
        where TTo : Currency
    {
        Console.WriteLine($"Enter the amount in {typeof(TFrom).Name}: ");
        
        decimal amountToExchange = Math.Round(decimal.Parse(Console.ReadLine()), 2);

        fromWallet.ExchangeFunds(amountToExchange, toWallet);
    }
}