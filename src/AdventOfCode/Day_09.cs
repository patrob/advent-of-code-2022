using AoCHelper;
using Library.Day09;

namespace AdventOfCode;

public class Day_09 : BaseDay
{
    private readonly List<string> _input;
    private readonly NodeMover _mover = new();

    public Day_09()
    {
        _input = File.ReadAllLines(InputFilePath).ToList();
    }

    private Node? GetTailestTail(Node? node)
    {
        return node?.Tail == null ? node : GetTailestTail(node.Tail);
    }
    
    public override ValueTask<string> Solve_1()
    {
        var parser = new ParseMoves();
        var moves = parser.Parse(_input);
        var head = NodeFactory.CreateNodeWithTails(1);
        _mover.Move(head, moves);
        var answer = head.Tail?.Visits.Distinct().Count();
        
        return ValueTask.FromResult($"{answer}");
    }

    public override ValueTask<string> Solve_2()
    {
        var parser = new ParseMoves();
        var moves = parser.Parse(_input);
        var head = NodeFactory.CreateNodeWithTails(9);
        _mover.Move(head, moves);
        var tail = GetTailestTail(head);
        var answer = tail?.Visits.Distinct().Count();

        return ValueTask.FromResult($"{answer}");
    }
}