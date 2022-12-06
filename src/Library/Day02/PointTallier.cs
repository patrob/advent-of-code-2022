namespace Library.Day02;

public interface IPointTallier
{
    int TallyScore(PlayOption opponent, PlayOption myPlay);
}

public class PointTallier : IPointTallier
{
    public int TallyScore(PlayOption opponent, PlayOption myPlay)
    {
        return myPlay.CompareTo(opponent) switch
        {
            1 => (int)myPlay.Option + 6,
            -1 => (int)myPlay.Option,
            _ => (int)myPlay.Option + 3
        };
    }
}

