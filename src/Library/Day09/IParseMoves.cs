using System.Collections;

namespace Library.Day09;

public interface IParseMoves
{
    List<Move> Parse(List<string> input);
}

public class ParseMoves : IParseMoves
{
    public List<Move> Parse(List<string> input)
    {
        return input
            .Select(x => x.Split(' '))
            .Select(x => new Move((Direction)x[0][0], int.Parse(x[1])))
            .ToList();
    }
}