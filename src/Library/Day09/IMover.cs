namespace Library.Day09;

public interface IMover
{
    int CountVisits(Move previous, Move current);
    int CountVisits(List<Move> moves);
}

public class Mover : IMover
{
    private readonly Direction[] _vertical = new[] { Direction.Up, Direction.Down };
    private readonly Direction[] _horizontal = new[] { Direction.Left, Direction.Right };

    private bool SamePlane(Move previous, Move current)
    {
        return (_vertical.Contains(previous.Direction) && _vertical.Contains(current.Direction)) ||
               (_horizontal.Contains(previous.Direction) && _horizontal.Contains(current.Direction));
    }
    
    public int CountVisits(Move? previous, Move current)
    {
        if (previous != null)
        {
            return !SamePlane(previous, current) ? current.Spaces - 1 : current.Spaces - previous.Spaces - 1;
        }
        return  current.Spaces - (previous == null ? 0 : 1);
    }

    public int CountVisits(List<Move> moves)
    {
        return moves
            .Select((move, i) => new
            {
                Previous = i > 0 ? moves[i - 1] : (Move)null,
                Current = move
            })
            .Sum(x => CountVisits(x.Previous, x.Current));
    }
}