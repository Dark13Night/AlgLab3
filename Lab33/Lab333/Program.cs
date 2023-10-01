using System;

class Currency
{
    public decimal Value { get; set; }
}

class CurrencyUSD : Currency
{
    public static implicit operator CurrencyEUR(CurrencyUSD usd)
    {
        decimal conversionRate = 0.85m; // курс USD к EUR
        CurrencyEUR eur = new CurrencyEUR();
        eur.Value = usd.Value * conversionRate;
        return eur;
    }

    public static implicit operator CurrencyRUB(CurrencyUSD usd)
    {
        decimal conversionRate = 72.52m; // курс USD к RUB
        CurrencyRUB rub = new CurrencyRUB();
        rub.Value = usd.Value * conversionRate;
        return rub;
    }
}

class CurrencyEUR : Currency
{
    public static implicit operator CurrencyUSD(CurrencyEUR eur)
    {
        decimal conversionRate = 1.18m; // курс EUR к USD
        CurrencyUSD usd = new CurrencyUSD();
        usd.Value = eur.Value * conversionRate;
        return usd;
    }

    public static implicit operator CurrencyRUB(CurrencyEUR eur)
    {
        decimal conversionRate = 86.36m; // курс EUR к RUB
        CurrencyRUB rub = new CurrencyRUB();
        rub.Value = eur.Value * conversionRate;
        return rub;
    }
}

class CurrencyRUB : Currency
{
    public static implicit operator CurrencyUSD(CurrencyRUB rub)
    {
        decimal conversionRate = 0.014m; // курс RUB к USD
        CurrencyUSD usd = new CurrencyUSD();
        usd.Value = rub.Value * conversionRate;
        return usd;
    }

    public static implicit operator CurrencyEUR(CurrencyRUB rub)
    {
        decimal conversionRate = 0.012m; // курс RUB к EUR
        CurrencyEUR eur = new CurrencyEUR();
        eur.Value = rub.Value * conversionRate;
        return eur;
    }
}

class Program
{
    static void Main(string[] args)
    {
        CurrencyUSD usd = new CurrencyUSD();
        usd.Value = 100;

        CurrencyEUR eur = usd; // неявное преобразование из USD в EUR
        Console.WriteLine(eur.Value); // выведет 85

        CurrencyRUB rub = (CurrencyRUB)eur; // явное преобразование из EUR в RUB
        Console.WriteLine(rub.Value); // выведет 7338.6
    }
}