using Library.Day08;

namespace AdventOfCode.Tests.Day08;

public class TreeVisibilityCheckerTests
{
    public static TreeGrid GetExampleTreeGrid()
    {
        var inputs = new List<string>
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390"
        };
        
        return new TreeGridParser().Parse(inputs);
    }
    
    public static TreeGrid CreateSimpleTreeGrid(int centerHeight = 1)
    {
        return new TreeGrid(new[]
        {
            new Tree[] { new(5), new(5), new(5) },
            new Tree[] { new(5), new(centerHeight), new(5) },
            new Tree[] { new(5), new(5), new(5) }
        });
    }

    public static IEnumerable<object[]> VisibilityCheckerData = new List<object[]>
    {
        // x, y, grid, true/false
        new object[] // border trees are visible
            { (0, 0), CreateSimpleTreeGrid(), true },
        new object[] // border trees are visible
            { (2, 2), CreateSimpleTreeGrid(), true },
        new object[] // border trees are visible
            { (2, 1), CreateSimpleTreeGrid(), true },
        new object[] // border trees are visible
            { (0, 1), CreateSimpleTreeGrid(), true },
        new object[] // center tree isn't visible
            { (1, 1), CreateSimpleTreeGrid(), false },
        new object[] // center tree should be visible
            { (1, 1), CreateSimpleTreeGrid(9), true },
        new object[] // center tree should be visible
        {
            (1, 1),
            new TreeGrid(new[]
            {
                new Tree[] { new(5), new(9), new(5) },
                new Tree[] { new(5), new(7), new(5) },
                new Tree[] { new(5), new(9), new(5) }
            }),
            true
        }
    };

    public static IEnumerable<object[]> ExampleTestData = new List<object[]>
    {
        new object[] { GetExampleTreeGrid(), (0,0), true },
        new object[] { GetExampleTreeGrid(), (0,1), true },
        new object[] { GetExampleTreeGrid(), (0,2), true },
        new object[] { GetExampleTreeGrid(), (0,3), true },
        new object[] { GetExampleTreeGrid(), (0,4), true },
        new object[] { GetExampleTreeGrid(), (1,0), true },
        new object[] { GetExampleTreeGrid(), (1,1), true },
        new object[] { GetExampleTreeGrid(), (1,2), true },
        new object[] { GetExampleTreeGrid(), (1,3), false },
        new object[] { GetExampleTreeGrid(), (1,4), true },
        new object[] { GetExampleTreeGrid(), (2,0), true },
        new object[] { GetExampleTreeGrid(), (2,1), true },
        new object[] { GetExampleTreeGrid(), (2,2), false },
        new object[] { GetExampleTreeGrid(), (2,3), true },
        new object[] { GetExampleTreeGrid(), (2,4), true },
        new object[] { GetExampleTreeGrid(), (3,0), true },
        new object[] { GetExampleTreeGrid(), (3,1), false },
        new object[] { GetExampleTreeGrid(), (3,2), true },
        new object[] { GetExampleTreeGrid(), (3,3), false },
        new object[] { GetExampleTreeGrid(), (3,4), true },
        new object[] { GetExampleTreeGrid(), (4,0), true },
        new object[] { GetExampleTreeGrid(), (4,1), true },
        new object[] { GetExampleTreeGrid(), (4,2), true },
        new object[] { GetExampleTreeGrid(), (4,3), true },
        new object[] { GetExampleTreeGrid(), (4,4), true },
    };

    [Theory]
    [MemberData(nameof(VisibilityCheckerData))]
    public void IsVisible_ShouldReturnExpected((int,int) coordinates, TreeGrid grid, bool expected)
    {
        new TreeVisibilityChecker().IsVisible(coordinates.Item1, coordinates.Item2, grid).Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(ExampleTestData))]
    public void IsVisible_ShouldSolveSimpleProblem(TreeGrid grid, (int,int) coordinates, bool expected)
    {
        var visChecker = new TreeVisibilityChecker();
        var visible = visChecker.IsVisible(coordinates.Item1, coordinates.Item2, grid);
        visible.Should().Be(expected);
    }
}