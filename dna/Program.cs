string? dnaString = Console.ReadLine();
int a = 0; int c = 0; int g = 0; int t = 0;
foreach (char? nucleotide in dnaString)
{
    switch (nucleotide)
    {
        case 'A': a++; break;
        case 'C': c++; break;
        case 'G': g++; break;
        case 'T': t++; break;
    }
}
Console.WriteLine($"{a} {c} {g} {t}");
