namespace Library.Day03;

public interface IRuckSackGrouper
{
    List<List<(string, string)>> GroupByCount(List<(string, string)> ruckSacks, int n);
}

public class RuckSackGrouper : IRuckSackGrouper
{
    public List<List<(string, string)>> GroupByCount(List<(string, string)> ruckSacks, int n)
    {
        var result = new List<List<(string, string)>>();
        var skip = 0;
        while (ruckSacks.Skip(skip).Any())
        {
            result.Add(ruckSacks.Skip(skip).Take(n).ToList());
            skip += n;
        }

        return result;
    }
}