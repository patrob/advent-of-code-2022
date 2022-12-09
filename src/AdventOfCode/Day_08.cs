using AoCHelper;
using Library.Day08;

namespace AdventOfCode;

public class Day_08 : BaseDay
{
    private readonly List<string> _input;
    private readonly TreeGridParser _parser = new();
    private readonly VisibleTreeCounter _counter = new();
    
    public Day_08()
    {
        _input = File.ReadAllText(InputFilePath).Split('\n').ToList();
    }
    
    public override ValueTask<string> Solve_1()
    {
        var grid = _parser.Parse(_input);
        var answer = _counter.GetVisibleTrees(grid);
        return ValueTask.FromResult($"{answer}");
    }

    public override ValueTask<string> Solve_2()
    {
        var nodes = _parser.ParseNodes(_input);
        var answer = _counter.GetBestScenicScore(nodes);
        return ValueTask.FromResult($"{answer}");
    }
}