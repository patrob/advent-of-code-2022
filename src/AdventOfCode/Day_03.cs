using AoCHelper;
using Library.Day03;

namespace AdventOfCode;

public class Day_03 : BaseDay
{
    private readonly List<string> _input;
    private readonly RuckSackItemFactory _itemFactory = new();
    private readonly DuplicateItemDetector _dupeFinder;
    private readonly CompartmentParser _parser = new();
    private readonly RuckSackGrouper _grouper = new();
    
    public Day_03()
    {
        _input = File.ReadAllText(InputFilePath).Split('\n').ToList();
        _dupeFinder = new DuplicateItemDetector(_itemFactory);
    }
    
    public override ValueTask<string> Solve_1()
    {
        var totalPriority = _input
            .Select(x => _parser.ParseCompartments(x))
            .Select(x => _dupeFinder.GetDuplicateItem(x))
            .Sum(x => x.Priority);
        return ValueTask.FromResult($"{totalPriority}");
    }

    public override ValueTask<string> Solve_2()
    {
        var ruckSacks = _input
            .Select(x => _parser.ParseCompartments(x))
            .ToList();

        var badgePriority = _grouper.GroupByCount(ruckSacks, 3)
            .Select(x => _dupeFinder.GetDuplicateItemAcrossMultiple(x))
            .Sum(x => x.Priority);
        return ValueTask.FromResult($"{badgePriority}");
    }
}