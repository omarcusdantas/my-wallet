namespace MyWallet;

abstract class Currency(string name)
{
    public string Name { get; } = name;
}

class Dollar : Currency
{
    public Dollar() : base("Dollar") { }
}

class Euro : Currency
{
    public Euro() : base("Euro") { }
}
