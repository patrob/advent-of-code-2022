namespace Library.Day10;

public abstract class Command
{
    public int CycleTime { get; init; }

    protected Command(int cycleTime)
    {
        CycleTime = cycleTime;
    }
}

public class NoOpCommand : Command
{
    public NoOpCommand() : base(1)
    {
    }
}

public class AddCommand : Command
{
    public int AddValue { get; init; }

    public AddCommand(int addValue) : base(2)
    {
        AddValue = addValue;
    }
}