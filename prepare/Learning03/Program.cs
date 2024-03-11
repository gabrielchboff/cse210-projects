class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Learning03");
        
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(1);
        Fraction f3 = new Fraction(3, 4);
        

        Console.WriteLine("The first fraction is " + f1.GetFractionString());
        Console.WriteLine("The second fraction is " + f2.GetFractionString());
        Console.WriteLine("The third fraction is " + f3.GetFractionString());

        Console.WriteLine("The first fraction is " + f1.GetDecimalValue());
        Console.WriteLine("The second fraction is " + f2.GetDecimalValue());
        Console.WriteLine("The third fraction is " + f3.GetDecimalValue());

    }

}
