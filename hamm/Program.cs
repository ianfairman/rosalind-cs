var sequence1 = Console.ReadLine();
var sequence2 = Console.ReadLine();

if (sequence1 == null || sequence2 == null || sequence1.Length != sequence2.Length)
{
    Console.WriteLine("Strings not of same length");
    Environment.Exit(1);
}

var hammingDistance = 0;

for (var i = 0; i < sequence1.Length; ++i)
{
    if (sequence1[i] != sequence2[i])
    {
        ++hammingDistance;
    }
}

Console.WriteLine(hammingDistance);
