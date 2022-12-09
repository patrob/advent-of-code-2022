using Library.Day08;

namespace AdventOfCode.Tests.Day08;

public class TreeGridParserTests
{
    public static IEnumerable<object[]> TreeGridTestData = new List<object[]>
    {
        new object[]
        {
            new List<string> { "0123456789" },
            new TreeGrid(new[]
            {
                new[] { new(0), new(1), new(2), new(3), new Tree(4), new(5), new(6), new(7), new(8), new(9) }
            })
        },
        new object[]
        {
            new List<string>
            {
                "012",
                "987"
            },
            new TreeGrid(new[]
            {
                new Tree[] {new(0), new(1), new(2)},
                new Tree[] {new(9), new(8), new(7)}
            })
        }
    };


    [Theory]
    [MemberData(nameof(TreeGridTestData))]
    public void Parse_ShouldHaveResultingTreeGrid(List<string> input, TreeGrid expected)
    {
        new TreeGridParser().Parse(input).Should().BeEquivalentTo(expected);
    }
}