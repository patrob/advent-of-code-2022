using Library.Day09;

namespace AdventOfCode.Tests.Day09;

public class ParseMovesTests
{
    public static IEnumerable<object[]> TestMoves = new List<object[]>
    {
        new object[]
        {
            new List<string>{"R 2", "D 2"},
            new List<Move>{ new(Direction.Right, 2), new(Direction.Down, 2)}
        },
        new object[]
        {
            new List<string>{"R 2", "D 2", "U 100", "L 99"},
            new List<Move>
            {
                new(Direction.Right, 2),
                new(Direction.Down, 2),
                new(Direction.Up, 100),
                new(Direction.Left, 99),
            }
        }
    };

    public static IEnumerable<object[]> TestMoves2 = new List<object[]>
    {
        new object[]
        {
            new List<Move>
            {
                new (Direction.Right, 4),
                new (Direction.Up, 4)
            },
            7
        },
        new object[]
        {
            new List<Move>
            {
                new (Direction.Right, 4),
                new (Direction.Up, 4),
                new(Direction.Left, 3),
                new(Direction.Down, 1),
                new(Direction.Right, 4),
                new(Direction.Down, 1),
                new(Direction.Left, 5),
                new(Direction.Right, 2)
            },
            13
        }
    };

    public static IEnumerable<object[]> TestLongTail = new List<object[]>
    {
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
            },
            36
        }
    };

    [Theory]
    [MemberData(nameof(TestMoves))]
    public void Parse_ShouldReturnExpected(List<string> input, List<Move> expected)
    {
        new ParseMoves().Parse(input).Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(TestMoves2))]
    public void MoveMultiple(List<Move> moves, int expected)
    {
        var parser = new ParseMoves();
        parser.MoveMultiple(moves);
        parser.GetVisitedCount().Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestLongTail))]
    public void MoveLongTail(List<Move> moves, int expected)
    {
        var parser = new ParseMoves();
        parser.MoveLongRope(moves);
        parser.GetVisitedCount().Should().Be(expected);
    }
}