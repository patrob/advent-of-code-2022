using AoCHelper;
using Library.Day04;

namespace AdventOfCode;

public class Day_04 : BaseDay
{
    private readonly List<string> _input;
    
    public Day_04()
    {
        _input = File.ReadAllText(InputFilePath).Split('\n').ToList();
    }
    
    public override ValueTask<string> Solve_1()
    {
        var sum = _input
            .Select(x => x.Split(',').Select(SimpleRange.Parse).ToArray())
            .Select(x => x[0].IsWithinRange(x[1]) || x[1].IsWithinRange(x[0]) ? 1 : 0)
            .Sum();

        return ValueTask.FromResult($"{sum}");
    }

    public override ValueTask<string> Solve_2()
    {
        var sum = _input
            .Select(x => x.Split(',').Select(SimpleRange.Parse).ToArray())
            .Select(x => x[0].ToArray().Intersect(x[1].ToArray()).Any() ? 1 : 0)
            .Sum();
    
        return ValueTask.FromResult($"{sum}");
    }
}