using AoCHelper;
using Library.Day09;

namespace AdventOfCode;

public class Day_09 : BaseDay
{
    private readonly List<string> _input;

    public Day_09()
    {
        _input = File.ReadAllLines(InputFilePath).ToList();
    }
    
    public override ValueTask<string> Solve_1()
    {
        var parser = new ParseMoves();
        var moves = parser.Parse(_input);
        parser.MoveMultiple(moves);
        var answer = parser.GetVisitedCount();
        return ValueTask.FromResult($"{answer}");
    }

    public override ValueTask<string> Solve_2()
    {
        var parser = new ParseMoves();
        // var moves = _parser.Parse(_input);
        var moves = new List<Move>
        {
            new(Direction.Right, 5),
            new(Direction.Up, 8),
            new(Direction.Left, 8),
            new(Direction.Down, 3),
            new(Direction.Right, 17),
            new(Direction.Down, 10),
            new(Direction.Left, 25),
            new(Direction.Up, 20)
        };
        parser.MoveLongRope(moves);
        parser.Grid.ToList().ForEach(row =>
        {
            row.ToList().ForEach(col => Console.Write(col.Peek()));
            Console.WriteLine();
        });
        var answer = parser.GetVisitedCount();
        return ValueTask.FromResult($"{answer}");
    }
}