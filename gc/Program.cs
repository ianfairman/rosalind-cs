// https://rosalind.info/problems/gc/
FastaParser parser = new();
FastaFile file = parser.Parse(Console.In);
Console.Write(file.MaxGc());
record FastaSequence(string Value)
{
    private int CountGc() => CountChar('C') + CountChar('G');

    public double PercentGc() => (double)CountGc() / (double)Value.Length * 100d;

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

    public override string ToString() => Value;
}

record FastaId(string Value) {
    public override string ToString() => Value;
}
record FastaRecord(FastaId Id, FastaSequence Sequence)
{
    public override string ToString() => $@"{Id}
{PercentGc():F6}";

    public double PercentGc() => Sequence.PercentGc();
}
record FastaFile(Dictionary<FastaId, FastaSequence> Records)
{

    public FastaRecord MaxGc()
    {
        var entryWithMaxValue = Records.MaxBy(entry => entry.Value.PercentGc());
        return new FastaRecord(entryWithMaxValue.Key, entryWithMaxValue.Value);   
    }
}

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
        return new FastaFile(lookup);
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
    private string sequence = "";

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

    private void HandleRecord(string id, string sequence)
    {
        FastaId fastaId = new(id);
        FastaSequence fastaSequence = new(sequence);
        lookup.Add(fastaId, fastaSequence);
    }
}