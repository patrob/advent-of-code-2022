using Library.Day08;

namespace AdventOfCode.Tests.Day08;

public class VisibleTreeCounterTests
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

    public static TreeNode[][] GetExampleTreeNode()
    {
        var inputs = new List<string>
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390"
        };

        return new TreeGridParser().ParseNodes(inputs);
    }

    public static IEnumerable<object[]> TestData = new List<object[]>
    {
        new object[]{GetExampleTreeNode(), (2,1), (1,1,2,2)},
        new object[]{GetExampleTreeNode(), (2,3), (2,2,2,1)}
    };
    
    public static IEnumerable<object[]> TestData2 = new List<object[]>
    {
        new object[]{GetExampleTreeNode(), (2,1), 4},
        new object[]{GetExampleTreeNode(), (2,3), 8}
    };

    [Fact]
    public void GetVisibleTrees_ShouldReturnExpected()
    {
        new VisibleTreeCounter().GetVisibleTrees(GetExampleTreeGrid()).Should().Be(21);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void GetViewingDistance_ShouldReturnExpected(TreeNode[][] trees, (int,int) coordinates, (int,int,int,int) expected)
    {
        new VisibleTreeCounter().GetViewingDistances(trees[coordinates.Item2][coordinates.Item1]).Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData2))]
    public void GetScenicScore_ShouldReturnExpected(TreeNode[][] trees, (int,int) coordinates, int expected)
    {
        new VisibleTreeCounter().GetScenicScore(trees[coordinates.Item2][coordinates.Item1]).Should().Be(expected);
    }

    [Fact]
    public void GetBestScenicScore_ShouldReturnExpected()
    {
        new VisibleTreeCounter().GetBestScenicScore(GetExampleTreeNode()).Should().Be(8);
    }
}