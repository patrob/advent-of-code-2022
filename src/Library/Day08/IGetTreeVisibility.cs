namespace Library.Day08;

public interface IGetTreeVisibility
{
    bool IsVisibleVertical(int x, int y, TreeGrid grid);
    bool IsVisibleHorizontal(int x, int y, TreeGrid grid);
    bool IsVisible(int x, int y, TreeGrid grid);
}

public class TreeVisibilityChecker : IGetTreeVisibility
{
    public bool IsVisibleVertical(int x, int y, TreeGrid grid)
    {
        var givenTree = grid.Trees[y][x];
        if (y == 0 || y == grid.Trees.Length - 1) return true;
        var verticalSlice = grid.Trees.Select(t => t[x]).ToArray();
        var top = verticalSlice[..y];
        var bottom = verticalSlice[(y + 1)..];
        var anyHigherUp = top.Any(t => t.Height >= givenTree.Height);
        var anyHigherDown = bottom.Any(t => t.Height >= givenTree.Height);
        return !(anyHigherUp && anyHigherDown);
    }

    public bool IsVisibleHorizontal(int x, int y, TreeGrid grid)
    {
        var givenTree = grid.Trees[y][x];
        if (x == 0 || x == grid.Trees[0].Length - 1) return true;
        var horizontalSlice = grid.Trees[y];
        var left = horizontalSlice[..x];
        var right = horizontalSlice[(x + 1)..];
        var anyHigherLeft = left.Any(t => t.Height >= givenTree.Height);
        var anyHigherRight = right.Any(t => t.Height >= givenTree.Height);
        return !(anyHigherLeft && anyHigherRight);
    }

    public bool IsVisible(int x, int y, TreeGrid grid)
    {
        var verticalVisibility = IsVisibleVertical(x, y, grid);
        var horizontalVisibility = IsVisibleHorizontal(x, y, grid);
        return verticalVisibility || horizontalVisibility;
    }
}