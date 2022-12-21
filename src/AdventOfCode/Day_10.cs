using AoCHelper;
using Library.Day10;

namespace AdventOfCode;

public class Day_10 : BaseDay
{
    private readonly List<Command> _commands;
    private readonly Processor _processor = new();

    public Day_10()
    {
        var input = File.ReadAllLines(InputFilePath);
        _commands = CommandParser.ParseCommands(input);
        _commands.ForEach(_processor.Execute);
    }
    
    public override ValueTask<string> Solve_1()
    {
        var answer = _processor.GetSignalStrengths();
        return ValueTask.FromResult($"{answer}");
    }

    public override ValueTask<string> Solve_2()
    {
        var answer = _processor.GetPixelsToPrint().ToList();
        answer.ForEach(Console.WriteLine);
        return ValueTask.FromResult("See console output.");
    }
}