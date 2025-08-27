using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string? dnaString = Console.ReadLine();
        if (dnaString == null)
        {
            return;
        }
        var builder = new StringBuilder();
        foreach (char nucleotide in dnaString)
        {
            switch (nucleotide)
            {
                case 'A': builder.Insert(0, 'T'); break;
                case 'C': builder.Insert(0, 'G'); break;
                case 'G': builder.Insert(0, 'C'); break;
                case 'T': builder.Insert(0, 'A'); break;
            }
        }
        Console.WriteLine(builder);
    }
}