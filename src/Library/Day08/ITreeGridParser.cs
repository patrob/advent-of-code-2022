namespace Library.Day08;

public interface ITreeGridParser
{
    TreeGrid Parse(List<string> input);
    TreeNode[][] ParseNodes(List<string> input);
}

public class TreeGridParser : ITreeGridParser
{
    public TreeGrid Parse(List<string> input)
    {
        return new TreeGrid(input
            .Select((line, y) => line
                .ToCharArray()
                .Select((c, x) => new Tree(int.Parse($"{c}")))
                .ToArray())
            .ToArray());
    }

    public TreeNode[][] ParseNodes(List<string> input)
    {
        var grid = Parse(input);
        var treeNodes = grid.Trees
            .Select((trees, y) => trees
                .Select((tree, x) =>
                    new TreeNode(tree.Height)
                ).ToArray())
            .ToArray(); 
        

        for (var y = 0; y < treeNodes.Length; y++)
        {
            for (var x = 0; x < treeNodes[y].Length; x++)
            {
                if (x < treeNodes[y].Length - 1)
                {
                    treeNodes[y][x].West = treeNodes[y][x + 1];
                }

                if (x > 0)
                {
                    treeNodes[y][x].East = treeNodes[y][x - 1];
                }

                if (y < treeNodes.Length - 1)
                {
                    treeNodes[y][x].South = treeNodes[y + 1][x];
                }

                if (y > 0)
                {
                    treeNodes[y][x].North = treeNodes[y - 1][x];
                }
            }
        }

        return treeNodes;
    }
}