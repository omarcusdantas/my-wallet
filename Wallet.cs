namespace MyWallet;

class Wallet<T> where T : Currency
{
    private decimal balance = 0;

    public void AddFunds(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"Added {amount} {typeof(T).Name}.");
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public void ExchangeFunds<TTarget>(decimal amount, Wallet<TTarget> targetWallet) where TTarget : Currency
    {
        if (balance < amount)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }

        balance -= amount;
        targetWallet.AddFunds(Utils.ConvertCurrency(amount, typeof(T).Name, typeof(TTarget).Name));
    }
}