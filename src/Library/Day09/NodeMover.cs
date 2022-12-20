using System.Numerics;

namespace Library.Day09;

public class NodeMover
{
    public Vector2 GetDirectionVector(Direction direction)
    {
        return direction switch {
            Direction.Up => Vector2.UnitY,
            Direction.Down => -Vector2.UnitY,
            Direction.Left => -Vector2.UnitX,
            Direction.Right => Vector2.UnitX,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    public void Move(Node head, List<Move> moves)
    {
        moves.ForEach(move => Move(head, move));
    }

    public void Move(Node head, Move move)
    {
        for (var i = 0; i < move.Spaces; i++)
        {
            Move(head, move.Direction);
        }
    }

    private Vector2 GetDirection(Vector2 headLocation, Vector2 tailLocation)
    {
        var direction = Vector2.Normalize(Vector2.Subtract(headLocation, tailLocation));
        if (direction.X == 0 || direction.Y == 0)
        {
            return direction;
        }

        return new Vector2(direction.X > 0 ? 1 : -1, direction.Y > 0 ? 1 : -1);
    }
    
    public void Move(Node? node, Direction? direction = null)
    {
        if (node == null) return;
        
        if (node is not TailNode && direction.HasValue)
        {
            var dirVector = GetDirectionVector(direction.Value);
            node.Location = Vector2.Add(node.Location, dirVector);
            node.Visits.Add(node.Location);
        }
        else if (node is TailNode tail)
        {
            if (Math.Abs(Vector2.Distance(tail.Head.Location, tail.Location)) >= 2)
            {
                var dirVector = GetDirection(tail.Head.Location, tail.Location);
                
                tail.Location = Vector2.Add(tail.Location, dirVector);
                tail.Visits.Add(tail.Location);
            }
        }
        Move(node.Tail);
    }
}