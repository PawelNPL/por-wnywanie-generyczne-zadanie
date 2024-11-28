using System;
using System.Numerics;

class Program
{
    static int ValueComparer<T1 , T2>(T1 v1  , T2 v2)
    {
        if (v1 is IComparable<T1> comparable1 && v2 is T1)
        {
            return comparable1.CompareTo((T1)(object)v2);
        }


        if (v1 is IComparable comparable)
        {
            return comparable.CompareTo(v2);
        }

        throw new InvalidOperationException("Nie można porównać");

    }

    static void Main()
    {
        Console.WriteLine("1 oznacza że pierwsza liczba jest wieksza, -1 że druga jest większa");
        //liczby zmiennoprzecinkowe
        double x = 7.3;
        double y = 2.2;
        Console.WriteLine("Porównanie double");
        Console.WriteLine(ValueComparer(x, y));

        //liczby całowite
        int a = 5; 
        int b = 2;
        Console.WriteLine("\nPorównanie int");
        Console.WriteLine(ValueComparer(a, b));

        //string
        string text = "abc";
        string text1 = "bds";

        Console.WriteLine("\nPorównanie string");
        Console.WriteLine(ValueComparer(text, text1));

        try // próba porównania różnych typów
        {
            int numer = 10;
            string slowo = "Witam";
            Console.WriteLine("\nPorównanie int i string");
            Console.WriteLine(ValueComparer(numer, slowo));
        }
        catch (Exception e) 
        {
            Console.WriteLine($"błąd {e.Message}");
        }

    }
}