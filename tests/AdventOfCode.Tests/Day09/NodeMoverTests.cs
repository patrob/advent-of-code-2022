using System.Numerics;
using Library.Day09;

namespace AdventOfCode.Tests.Day09;

public class NodeMoverTests
{
    public static Node CreateHeadNode(int tails = 0)
    {
        var head = new Node();
        var node = head;
        for (var i = 0; i < tails; i++)
        {
            node.Tail = new TailNode { Head = node, Id = i + 1 };
            node = node.Tail;
        }
        
        return head;
    }

    public static IEnumerable<object[]> TestMoveData = new List<object[]>
    {
        new object[]
        {
            new List<Move> { new(Direction.Right, 4), }, // moves
            CreateHeadNode(1), // nodes
            new Vector2(3, 0)// tail location
        },
        new object[]
        {
            new List<Move> { new(Direction.Left, 4), }, // moves
            CreateHeadNode(1), // nodes
            new Vector2(-3, 0)// tail location
        },
        new object[]
        {
            new List<Move> { new(Direction.Up, 4), }, // moves
            CreateHeadNode(1), // nodes
            new Vector2(0, 3)// tail location
        },
        new object[]
        {
            new List<Move> { new(Direction.Down, 4), }, // moves
            CreateHeadNode(1), // nodes
            new Vector2(0, -3)// tail location
        },
        new object[]
        {
            new List<Move> { new(Direction.Right, 1), new(Direction.Up, 2) }, // moves
            CreateHeadNode(1), // nodes
            new Vector2(1, 1)// tail location
        },
        new object[]
        {
            new List<Move> { new(Direction.Right, 1), new(Direction.Up, 2) }, // moves
            CreateHeadNode(2), // nodes
            new Vector2(0, 0)// tail location
        },
        new object[]
        {
            new List<Move>
            {
                new(Direction.Right, 4),
                new(Direction.Up, 4),
                new(Direction.Left, 3),
            }, // moves
            CreateHeadNode(9), // nodes
            new Vector2(0, 0)// tail location
        },
        new object[]
        {
            new List<Move>
            {
                new(Direction.Right, 4),
                new(Direction.Up, 4),
                new(Direction.Left, 3),
                new(Direction.Down, 1),
                new(Direction.Right, 4),
                new(Direction.Down, 1),
                new(Direction.Left, 5),
                new(Direction.Right, 2),
            }, // moves
            CreateHeadNode(9), // nodes
            new Vector2(0, 0)// tail location
        },
        new object[]
        {
            new List<Move>
            {
                new(Direction.Right, 5),
                new(Direction.Up, 8),
                new(Direction.Left, 8),
                new(Direction.Down, 3),
                new(Direction.Right, 17),
                new(Direction.Down, 10),
                new(Direction.Left, 25),
                new(Direction.Up, 20)
            }, // moves
            CreateHeadNode(9), // nodes
            new Vector2(-11, 6)// tail location
        },
    };

    public static IEnumerable<object[]> TestPartsData = new List<object[]>
    {
        new object[]
        {
            new List<Move>
            {
                new(Direction.Right, 4),
                new(Direction.Up, 4),
                new(Direction.Left, 3),
                new(Direction.Down, 1),
                new(Direction.Right, 4),
                new(Direction.Down, 1),
                new(Direction.Left, 5),
                new(Direction.Right, 2),
            }, // moves
            CreateHeadNode(1), // nodes
            13
        },
        new object[]
        {
            new List<Move>
            {
                new(Direction.Right, 5),
                new(Direction.Up, 8),
                new(Direction.Left, 8),
                new(Direction.Down, 3),
                new(Direction.Right, 17),
                new(Direction.Down, 10),
                new(Direction.Left, 25),
                new(Direction.Up, 20)
            }, // moves
            CreateHeadNode(9), // nodes
            36
        },
    };

    private readonly NodeMover _sut = new();
    
    [Theory]
    [MemberData(nameof(TestMoveData))]
    public void Test(List<Move> moves, Node head, Vector2 expectedTailLocation)
    {
        _sut.Move(head, moves);
        var tail = head.Tail;
        while (tail?.Tail != null) tail = tail.Tail;
        tail.Should().NotBeNull();
        tail?.Location.Should().Be(expectedTailLocation);
    }

    [Theory]
    [MemberData(nameof(TestPartsData))]
    public void Test2(List<Move> moves, Node head, int expectedTailVisits)
    {
        _sut.Move(head, moves);
        var tail = head.Tail;
        while (tail?.Tail != null) tail = tail.Tail;
        tail.Should().NotBeNull();
        tail?.Visits.Distinct().Count().Should().Be(expectedTailVisits);
    }
}