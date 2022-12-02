namespace Day_02;

public interface IPlayOptionParser
{
    PlayOptionEnum ParsePlayOption(string playOptionText);
}

public class PlayOptionParser : IPlayOptionParser
{
    public PlayOptionEnum ParsePlayOption(string playOptionText)
    {
        return playOptionText switch
        {
            "A" => PlayOptionEnum.Rock,
            "X" => PlayOptionEnum.Rock,
            "B" => PlayOptionEnum.Paper,
            "Y" => PlayOptionEnum.Paper,
            "C" => PlayOptionEnum.Scissors,
            "Z" => PlayOptionEnum.Scissors,
            _ => throw new NotSupportedException()
        };
    }
}