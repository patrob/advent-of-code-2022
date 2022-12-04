namespace Day_03;

public interface IDuplicateItemDetector
{
    RuckSackItem GetDuplicateItem((string, string) ruckSack);
    RuckSackItem GetDuplicateItemAcrossMultiple(List<(string, string)> ruckSacks);
}

public class DuplicateItemDetector : IDuplicateItemDetector
{
    private readonly IRuckSackItemFactory _itemFactory;

    public DuplicateItemDetector(IRuckSackItemFactory itemFactory)
    {
        _itemFactory = itemFactory;
    }
    public RuckSackItem GetDuplicateItem((string, string) ruckSack)
    {
        var dupe = ruckSack.Item1.ToCharArray()
            .FirstOrDefault(x => ruckSack.Item2.Contains(x, StringComparison.Ordinal));

        return _itemFactory.CreateRuckSackItem(dupe);
    }

    public RuckSackItem GetDuplicateItemAcrossMultiple(List<(string, string)> ruckSacks)
    {
        var totalSacks = ruckSacks
            .Select(x => x.Item1 + x.Item2)
            .ToList();
        var firstSack = totalSacks.First().ToCharArray();
        foreach(var c in firstSack)
        {
            if (totalSacks.Skip(1).ToList().All(x => x.ToCharArray().Contains(c)))
            {
                return _itemFactory.CreateRuckSackItem(c);
            }
        }

        throw new NotSupportedException();
    }
}