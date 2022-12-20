using System.Drawing;
using System.Numerics;

namespace Library.Day09;

public class Node
{
    public Vector2 Location { get; set; } = Vector2.Zero;
    public Node? Tail { get; set; }
    public int Id { get; init; }
    public List<Vector2> Visits { get; } = new() { Vector2.Zero };
}

public static class NodeMap
{
    public const int InitialGridSize = 20;

    public static char[][] Grid = GenerateGrid(InitialGridSize);
    
    public static char[][] GenerateGrid(int size) => Enumerable.Range(0, size)
        .Select((_, i) => new char[size]
            .Select((_, j) => i == size / 2 && j == size / 2 ? 's' : '.').ToArray()).ToArray();

    public static void PrintGrid()
    {
        foreach (var row in Grid)
        {
            foreach (var col in row)
            {
                Console.Write(col);
            }
            Console.WriteLine();
        }
    }

    public static (int, int) GetRowAndCol(Vector2 location)
    {
        var row = (int)(Grid.Length / 2.0 - location.Y); // reverse Y since rows go downward
        var col = (int)(Grid[0].Length / 2.0 + location.X);
        return (row, col);
    }

    public static void UpdateGrid()
    {
        Console.WriteLine("Doubling grid size...");
        var newGrid = GenerateGrid(Grid.Length * 2);
        
        for (var r = 0; r < Grid.Length; r++)
        {
            for (var c = 0; c < Grid[r].Length; c++)
            {
                newGrid[r + Grid.Length / 4][c + Grid.Length / 4] = Grid[r][c];
            }
        }

        Grid = newGrid;
    }

    private static (int, int) GetRowAndColWithUpdatedGrid(Vector2 location)
    {
        var (row, col) = GetRowAndCol(location);
        while (row < 0 || col < 0 || row >= Grid.Length || col >= Grid.Length)
        {
            UpdateGrid();
            (row, col) = GetRowAndCol(location);
        }

        return (row, col);
    }

    public static void SetNodeLocation(Node? node)
    {
        if (node == null) return;
        
        var (row, col) = GetRowAndColWithUpdatedGrid(node.Location);
        Console.WriteLine($"Node {node.Id} {node.Location} [{row}][{col}]");
        
        if (node is not TailNode)
        {
            Grid[row][col] = 'H';
        }
        else if (node is TailNode tail)
        {
            if (tail.Tail == null) // last tail
            {
                tail.VisitedLocations.ForEach(loc =>
                {
                    var (r, c) = GetRowAndColWithUpdatedGrid(loc);
                    Grid[r][c] = '#';
                });
            }
            else if (Grid[row][col] == '.' || Grid[row][col] == 's')
            {
                Grid[row][col] =  (char)('0' + tail.Id);
            }
        }
        SetNodeLocation(node.Tail);
    }
}

public class TailNode : Node
{
    public required Node Head { get; set; }
    public List<Vector2> VisitedLocations { get; } = new();
    public void Visit(Vector2 point)
    {
        if (VisitedLocations.Contains(point)) return;
        
        // Console.WriteLine($"Tail has visited {point}");
        VisitedLocations.Add(point);
    }
}

public static class NodeFactory
{
    public static Node CreateNodeWithTails(int nTails)
    {
        var head = new Node();
        head.Tail = CreateTail(head, nTails);
        return head;
    }

    private static Node? CreateTail(Node head, int tails)
    {
        if (tails == 0) return null;
        var node = new TailNode { Head = head, Id = head.Id + 1};
        node.Tail = CreateTail(node, tails - 1);
        return node;
    }
}

public static class NodesMover
{
    public static void MoveNode(Node head, List<Move> moves)
    {
        moves.ForEach(move => MoveNode(head, move));
    }
    
    public static void MoveNode(Node head, Move move)
    {
        for (var i = 0; i < move.Spaces; i++)
        {
            MoveNode(head, GetDirectionVector(move.Direction));
        }
    }
    
    public static Vector2 GetDirectionVector(Direction direction)
    {
        return direction switch
        {
            Direction.Up => Vector2.UnitY,
            Direction.Down => -Vector2.UnitY,
            Direction.Left => -Vector2.UnitX,
            Direction.Right => Vector2.UnitX,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
    
    public static void MoveNode(Node? node, Direction direction)
    {
        MoveNode(node, GetDirectionVector(direction));
    }

    public static Vector2 GetMovement(Vector2 headLocation, Vector2 tailLocation)
    {
        var distance = Vector2.Distance(headLocation, tailLocation);
        var direction = Vector2.Normalize(Vector2.Subtract(headLocation, tailLocation));

        if (!(Math.Abs(distance) >= 2)) return Vector2.Zero;
        
        if ((int)headLocation.X == (int)tailLocation.X) return distance > 0 ? Vector2.UnitY : -Vector2.UnitY;
        if ((int)headLocation.Y == (int)tailLocation.Y) return distance > 0 ? Vector2.UnitX : -Vector2.UnitX;

        return new Vector2(direction.X > 0 ? 1 : -1, direction.Y > 0 ? 1 : -1);
    }
    
    public static void MoveNode(Node? node, Vector2? direction = null)
    {
        if (node == null) return;
        
        if (node is not TailNode && direction.HasValue) // aka head!
        {
            node.Location = Vector2.Add(node.Location, direction.Value);
        }
        else if (node is TailNode tail)
        {
            var move = GetMovement(tail.Head.Location, tail.Location);
            tail.Location = Vector2.Add(tail.Location, move);
            if (tail.Tail == null && move != Vector2.Zero)
            {
                tail.VisitedLocations.Add(tail.Location);
            }
        }
        
        MoveNode(node.Tail);
    }
}

public static class NodeVisitCounts
{
    public static long GetVisitCount(Node? node)
    {
        if (node is TailNode { Tail: null } tail)
        {
            return tail.VisitedLocations.Count;
        }

        return GetVisitCount(node?.Tail);
    }
}