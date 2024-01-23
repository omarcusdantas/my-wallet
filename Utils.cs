namespace MyWallet;

static class Utils
{
    static public decimal ConvertCurrency(decimal amount, string sourceCurrency, string targetCurrency)
    {
        if (sourceCurrency == "Euro" && targetCurrency == "Dollar")
        {
            return Math.Round(amount * 1.1m, 2);
        }
        
        if (sourceCurrency == "Dollar" && targetCurrency == "Euro")
        {
            return Math.Round(amount / 1.1m, 2);
        }

        return amount;
    }
}