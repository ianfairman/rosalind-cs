// https://rosalind.info/problems/gc/
Console.WriteLine("Boo!");
FastaParser parser = new();
parser.Parse(Console.In);
record FastaSequence(string Value)
{
    public int CountGc()
    {
        return CountChar('C') + CountChar('G');
    }

    private int CountChar(char c)
    {
        int count = 0;
        foreach (char ch in Value)
        {
            if (ch == c)
            {
                count++;
            }
        }
        return count;
    }
}

record FastaId(string Value) { }
record FastaRecord(FastaId Id, FastaSequence Sequence) { }
record FastaFile(Dictionary<FastaId, FastaRecord> Records) { }

class FastaParser
{
    public FastaFile Parse(TextReader textReader)
    {
        string? line = textReader.ReadLine();
        while (line != null)
        {
            ProcessLine(line);
            line = textReader.ReadLine();
        }
        EndOfFile();
        return null;
    }

    private void ProcessLine(string line)
    {
        if (line.StartsWith('>'))
        {
            ProcessId(line);
            return;
        }
        if (line.Trim().Length == 0)
        {
            ProcessBlank(line);
            return;
        }
        ProcessSequence(line);
    }

    private string? id = null;
    private string? sequence;

    private void ProcessId(string line)
    {
        if (id != null)
        {
            HandleRecord(id, sequence);
        }
        char[] prefix = { '>' };
        id = line.TrimStart(prefix).Trim();
        sequence = "";
    }

    private void ProcessBlank(string line)
    {
        if (id != null)
        {
            HandleRecord(id, sequence);
            id = null;
            sequence = "";
        }
    }

    private void ProcessSequence(string line)
    {
        sequence += line.Trim();
    }

    private void EndOfFile()
    {
        if (id != null)
        {
            HandleRecord(id, sequence);
        }
    }

    private Dictionary<FastaId, FastaSequence> lookup = new();

    private void HandleRecord(string id, string? sequence)
    {
        FastaId fastaId = new(id);
        FastaSequence fastaSequence = new(sequence);
        Console.WriteLine($"{fastaId} {fastaSequence}");
    }
}