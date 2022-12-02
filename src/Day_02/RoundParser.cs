namespace Day_02;

public interface IRoundParser
{
    int GetRoundScore(string roundInput);
}

public class RoundParser : IRoundParser
{
    private readonly IPlayOptionParser _parser;
    private readonly IPointTallier _tallier;

    public RoundParser(IPlayOptionParser parser, IPointTallier tallier)
    {
        _parser = parser;
        _tallier = tallier;
    }
    
    public int GetRoundScore(string roundInput)
    {
        var playOptions = roundInput.Split(' ')
            .Take(2) // should only be 2, but just in case
            .Select(x => _parser.ParsePlayOption(x))
            .Select(x => new PlayOption(x))
            .ToArray();
        return _tallier.TallyScore(playOptions[0], playOptions[1]);
    }
}

public class PredictableRoundParser : IRoundParser
{
    private readonly IPlayOptionParser _parser;
    private readonly IPointTallier _tallier;

    public PredictableRoundParser(IPlayOptionParser parser, IPointTallier tallier)
    {
        _parser = parser;
        _tallier = tallier;
    }
    
    public int GetRoundScore(string roundInput)
    {
        var split = roundInput.Split(' ');
        var opponent = _parser.ParsePlayOption(split[0]);
        var desiredResult = GetDesiredOutcome(opponent, split[1]);
        return _tallier.TallyScore(new PlayOption(opponent), new PlayOption(desiredResult));
    }

    public PlayOptionEnum GetDesiredOutcome(PlayOptionEnum opponent, string input)
    {
        var opponentValue = (int)opponent - 1;
        if (opponentValue == 0) opponentValue += 3;
        return input switch
        {
            "X" => (PlayOptionEnum)((opponentValue - 1) % 3 + 1),
            "Y" => opponent,
            "Z" => (PlayOptionEnum)((opponentValue + 1) % 3 + 1),
            _ => throw new NotSupportedException()
        };
    }
}