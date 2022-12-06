using System.Text;
using Library;

namespace Day_06;

public class Day06Solver : BasePuzzleSolver
{
    public Day06Solver(IInputReader reader) : base(reader)
    {
    }

    public bool IsAllUnique(string chars)
    {
        return chars.Distinct().Count() == chars.Length;
    }

    public List<char> FindUniqueChars(string input, int size)
    {
        return input
            .TakeWhile((c, i) => i < size || !IsAllUnique(input[(i - size)..i]))
            .ToList();
    }

    public override string Solve()
    {
        var input = Reader.GetAllText();
        if (Reader.IsExample)
        {
            input = input.Split('\n')[0];
        }

        var startOfPacket = FindUniqueChars(input, 4);

        var startOfMessage = FindUniqueChars(input, 14);

        var sb = new StringBuilder();
        sb.AppendFormat("Found {0} characters for start of packet.\n", startOfPacket.Count);
        sb.AppendFormat("Found {0} characters for start of message.", startOfMessage.Count);
        
        return sb.ToString();
    }
}