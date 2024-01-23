namespace MyWallet;

abstract class Currency(string name)
{
    public string Name { get; } = name;
}

class Dollar : Currency
{
    public Dollar() : base("Dollar") { }
}

// Euro class
class Euro : Currency
{
    public Euro() : base("Euro") { }
}