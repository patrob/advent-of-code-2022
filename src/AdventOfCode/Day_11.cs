using AoCHelper;
using Library.Day11;

namespace AdventOfCode;

public class Day_11 : BaseDay
{
    private readonly List<string> _input;

    public Day_11()
    {
        _input = File.ReadAllLines(InputFilePath).ToList();
        
    }
    
    public override ValueTask<string> Solve_1()
    {
        var monkeys = MonkeyParser.ParseMonkeys(_input);
        MonkeyBusiness.LoadMonkeys(monkeys);
        MonkeyBusiness.ExecuteRounds(20, (worry) => worry / 3);
        var answer = MonkeyBusiness.CalculateMonkeyBusiness();
        return ValueTask.FromResult($"{answer}");
    }

    public override ValueTask<string> Solve_2()
    {
        var monkeys = MonkeyParser.ParseMonkeys(_input);
        MonkeyBusiness.LoadMonkeys(monkeys);
        var mod = monkeys.Select(x => x.DivisibleBy).Aggregate(1L, (acc, cur) => acc * cur);
        MonkeyBusiness.ExecuteRounds(10000, (worry) => worry % mod);
        var answer = MonkeyBusiness.CalculateMonkeyBusiness();
        return ValueTask.FromResult($"{answer}");
    }
}