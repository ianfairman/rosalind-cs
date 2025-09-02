// https://rosalind.info/problems/gc/
using Fasta;

FastaParser parser = new();
FastaFile file = parser.Parse(Console.In);
Console.Write(file.MaxGc());
