namespace Library.Day08;

public class TreeNode
{
    public int Height { get; }
    public TreeNode? North { get; set; } = null;
    public TreeNode? South { get; set; } = null;
    public TreeNode? East { get; set; } = null;
    public TreeNode? West { get; set; } = null;
    
    public TreeNode(int height)
    {
        Height = height;
    }

    public bool IsLocallyVisible()
    {
        if (North == null) return true;
        if (South == null) return true;
        if (East == null) return true;
        if (West == null) return true;
        return new[] { North.Height, South.Height, East.Height, West.Height }.Min() < Height;
    }
}