string? input = Console.ReadLine();
if (input == null)
{
    Console.WriteLine("No input parameters provided");
    return;
}
string[] parameters = input.Split(' ');
if (parameters.Length != 2)
{
    Console.WriteLine("Wrong number of parameters");
    return;
}
long maxGenerations = long.Parse(parameters[0]);
long littersPerGeneration = long.Parse(parameters[1]);
Generation generation = new(LittersPerGeneration: littersPerGeneration);
for (long i = 1; i < maxGenerations; ++i)
{
    generation = generation.NextGeneration();
    //    Console.WriteLine(generation);
}
Console.WriteLine(generation.TotalRabbits);

record Generation(long MatureRabbits = 0,
            long ImmatureRabbits = 1,
            long ExpectedBirths = 0,
            long LittersPerGeneration = 3) {

    
    public long TotalRabbits => MatureRabbits + ImmatureRabbits;

    public Generation NextGeneration() => new(MatureRabbits: TotalRabbits,
            ImmatureRabbits: ExpectedBirths,
            ExpectedBirths: (LittersPerGeneration * TotalRabbits),
            LittersPerGeneration: LittersPerGeneration);
}