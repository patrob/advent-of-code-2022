namespace Library.Day08;

public interface ICountVisibleTrees
{
    int GetVisibleTrees(TreeGrid grid);
    (int, int, int, int) GetViewingDistances(TreeNode treeNode);
    int GetScenicScore(TreeNode treeNode);
    int GetBestScenicScore(TreeNode[][] treeNode);
}

public class VisibleTreeCounter : ICountVisibleTrees
{
    private readonly TreeVisibilityChecker _checker = new();

    public int GetVisibleTrees(TreeGrid grid)
    {
        var answer = 0;
        for (var y = 0; y < grid.Trees.Length; y++)
        {
            for (var x = 0; x < grid.Trees[y].Length; x++)
            {
                if (_checker.IsVisible(x, y, grid)) answer++;
            }
        }

        return answer;
    }

    public (int, int, int, int) GetViewingDistances(TreeNode treeNode)
    {
        var northCount = GetCount(treeNode, nameof(TreeNode.North), treeNode.Height, 0);
        var southCount = GetCount(treeNode, nameof(TreeNode.South), treeNode.Height, 0);
        var eastCount = GetCount(treeNode, nameof(TreeNode.East), treeNode.Height, 0);
        var westCount = GetCount(treeNode, nameof(TreeNode.West), treeNode.Height, 0);
        return (northCount, eastCount, westCount, southCount);
    }

    public int GetScenicScore(TreeNode treeNode)
    {
        var distances = GetViewingDistances(treeNode);
        return distances.Item1 * distances.Item2 * distances.Item3 * distances.Item4;
    }

    public int GetBestScenicScore(TreeNode[][] treeNode)
    {
        return treeNode.SelectMany(t => t).Max(GetScenicScore);
    }

    private int GetCount(TreeNode node, string direction, int originalHeight, int runningCount)
    {
        var nextNode = direction switch
        {
            nameof(TreeNode.North) => node.North,
            nameof(TreeNode.South) => node.South,
            nameof(TreeNode.East) => node.East,
            nameof(TreeNode.West) => node.West,
            _ => throw new NotImplementedException()
        };
        if (nextNode == null) return runningCount;
        if (nextNode.Height >= originalHeight) return runningCount + 1;
        return GetCount(nextNode, direction, originalHeight, runningCount + 1);
    }

}