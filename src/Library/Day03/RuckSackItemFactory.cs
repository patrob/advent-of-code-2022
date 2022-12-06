namespace Library.Day03;

public interface IRuckSackItemFactory
{
    RuckSackItem CreateRuckSackItem(char id);
}

public class RuckSackItemFactory : IRuckSackItemFactory
{
    private bool IsLower(char id) => id is >= 'a' and <= 'z';
    private int GetCapitalPriority(char id) => id - 'A' + 27;
    private int GetNormalPriority(char id) => id - 'a' + 1;
    
    public RuckSackItem CreateRuckSackItem(char id)
    {
        var priority = IsLower(id) ? GetNormalPriority(id) : GetCapitalPriority(id);
        return new RuckSackItem(id, priority);
    }
}