using AoCHelper;

namespace AdventOfCode;

public class Day_06 : BaseDay
{
    private readonly string _input;

    public Day_06()
    {
        _input = File.ReadAllText(InputFilePath);
    }
    
    public override ValueTask<string> Solve_1()
    {
        var startOfPacket = FindUniqueChars(_input, 4);

        return ValueTask.FromResult($"{startOfPacket.Count}");
    }

    public override ValueTask<string> Solve_2()
    {
        var startOfMessage = FindUniqueChars(_input, 14);

        return ValueTask.FromResult($"{startOfMessage.Count}");
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
}