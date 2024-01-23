//TODO: Error Handling

using System.Globalization;

namespace MyWallet;
static class Program
{
    static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        Wallet<Dollar> dollarWallet = new();
        Wallet<Euro> euroWallet = new();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Choose Dollar Wallet");
            Console.WriteLine("2. Choose Euro Wallet");
            Console.WriteLine("3. Transfer between wallets");
            Console.WriteLine("4. Quit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    WalletController.HandleWalletOperations(dollarWallet);
                    break;
                case 2:
                    WalletController.HandleWalletOperations(euroWallet);
                    break;
                case 3:
                    WalletController.ExchangeFunds(dollarWallet, euroWallet);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}