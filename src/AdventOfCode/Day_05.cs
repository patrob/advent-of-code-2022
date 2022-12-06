using System.Text;
using AoCHelper;
using Library.Day05;

namespace AdventOfCode;

public class Day_05 : BaseDay
{
    private readonly List<string> _input;
    private const string EmptySlot = "[_]";
    private readonly Action _noOp = () => { };

    public Day_05()
    {
        _input = File.ReadAllText(InputFilePath).Split('\n').ToList();
    }
    
    public override ValueTask<string> Solve_1()
    {
        var stackLines = GetStackLines(_input);
        var stacks9000 = GetStacks<Stacker9000>(stackLines);
        
        var moves = GetMoves(_input);
        moves.ForEach(move => Move(stacks9000, move.Item1, move.Item2, move.Item3));
        
        return ValueTask.FromResult($"{GetTops(stacks9000)}");
    }

    public override ValueTask<string> Solve_2()
    {
        var stackLines = GetStackLines(_input);
        var stacks9001 = GetStacks<Stacker9001>(stackLines);
        
        var moves = GetMoves(_input);
        moves.ForEach(move => Move(stacks9001, move.Item1, move.Item2, move.Item3));
        
        
        return ValueTask.FromResult($"{GetTops(stacks9001)}");
    }
    
    public List<string> GetStackLines(List<string> input)
    {
        return input
            .TakeWhile(x => !string.IsNullOrEmpty(x))
            .Select(GetSanitizedString)
            .ToList();
    }

    public string GetSanitizedString(string input)
    {
        return input.Replace("    [", $"{EmptySlot} [")
            .Replace("]    ", $"] {EmptySlot}");
    }

    public bool ValidItemToPush(string value, string key, int index)
    {
        return value != EmptySlot && !string.IsNullOrEmpty(value) && int.Parse(key) - 1 == index;
    }
    
    public Dictionary<string, T> GetStacks<T>(List<string> stackLines) where T : IElfStack<string>, new()
    {
        var stacks = stackLines
            .Last()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select((_, index) => new
            {
                Name = $"{index + 1}",
                Stack = new T()
            })
            .ToDictionary(x => x.Name, x => x.Stack);

        
        stacks.Keys.ToList().ForEach(key =>
        {
            stackLines
                .Take(stackLines.Count - 1) // don't take last line
                .Select(x => x.Split(' '))
                .SelectMany(line => line.Select((value, index) =>
                    ValidItemToPush(value, key, index) ? () => stacks[key].Push(value) : _noOp))
                .ToList()
                .ForEach(action => action());
        });

        return stacks;
    }

    public List<(int, string, string)> GetMoves(List<string> inputLines)
    {
        return inputLines
            .SkipWhile(s => !string.IsNullOrEmpty(s))
            .Skip(1)
            .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(x => (int.Parse(x[1]), x[3], x[5]))
            .ToList();
    }
    
    public void Move<T>(Dictionary<string, T> stacks, int count, string from, string to) where T : IElfStack<string>
    {
        stacks[to].PushRange(stacks[from].PopMultiple(count));
    }

    public string GetTops<T>(Dictionary<string, T> stacks) where T : IElfStack<string>
    {
        return stacks.Keys
            .Select(x => stacks[x].Any() ? stacks[x].Peek() : string.Empty)
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(x => x.Trim('[', ']'))
            .Aggregate((c, n) => c + n);
    }
}