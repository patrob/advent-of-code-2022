using AoCHelper;
using Library.Day01;

namespace AdventOfCode;

public class Day_01 : BaseDay
{
    private readonly List<string> _input;
    private readonly ICalorieCounter _counter;
    private readonly ICalorieCountParser _parser;
    
    public Day_01()
    {
        _input = File.ReadAllText(InputFilePath).Split('\n').ToList();
        _counter = new CalorieCounter();
        _parser = new CalorieCountParser();
    }
    
    public override ValueTask<string> Solve_1()
    {
        var counts = _parser.ParseCalorieCounts(_input);
        var max = _counter.GetMaxCalorieCount(counts);
        return ValueTask.FromResult($"{max}");
    }

    public override ValueTask<string> Solve_2()
    {
        var counts = _parser.ParseCalorieCounts(_input);
        var top3 = _counter.GetTop3CalorieCounts(counts);
        return ValueTask.FromResult($"{top3}");
    }
}