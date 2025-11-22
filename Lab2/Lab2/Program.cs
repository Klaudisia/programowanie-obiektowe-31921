//zadanie 5
KontoBankowe konto = new KontoBankowe();
class KontoBankowe
{
    private double saldo;
    public void Wplata(double kwota) { saldo += kwota; }
    public void Wyplata(double kwota)
    {
        if (saldo > kwota)
        {
            saldo -= kwota;
        }
        else
        {
            Console.WriteLine("Nie masz wystarczająco pieniędzy na koncie");
        }
    }
    public double PobierzSaldo() { return saldo; }
}

//zadanie 6

class Zwierze
{
    public void Jedz() => Console.WriteLine("Zwierzę je");
}
class Pies : Zwierze
{
    public void Szczekaj() => Console.WriteLine("Hau hau!");
}

class Kot : Zwierze
{
    public void Miaucz() => Console.WriteLine("Miau");
}

//sprawdzam