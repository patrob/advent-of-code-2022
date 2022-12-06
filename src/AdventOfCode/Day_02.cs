using AoCHelper;
using Library.Day02;

namespace AdventOfCode;

public class Day_02 : BaseDay
{
    private readonly List<string> _input;
    private readonly IRoundParser _roundParser;
    private readonly IRoundParser _predictableParser;

    public Day_02()
    {
        _input = File.ReadAllText(InputFilePath).Split('\n').ToList();
        _roundParser = new RoundParser(new PlayOptionParser(), new PointTallier());
        _predictableParser = new PredictableRoundParser(new PlayOptionParser(), new PointTallier());
    }
    
    public override ValueTask<string> Solve_1()
    {
        var total = _input
            .Select(x => _roundParser.GetRoundScore(x))
            .Aggregate((c,n) => c+n);
        return ValueTask.FromResult($"{total}");
    }

    public override ValueTask<string> Solve_2()
    {
        var total = _input
            .Select(x => _predictableParser.GetRoundScore(x))
            .Aggregate((c,n) => c+n);
        return ValueTask.FromResult($"{total}");
    }
}