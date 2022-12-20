namespace Library.Day10;

public class Processor
{
    public int Cycles => RegisterValues.Count;
    public List<int> RegisterValues { get; } = new() {1};

    public void Execute(Command command)
    {
        var currentX = RegisterValues.Last();
        if (command is AddCommand add)
        {
            RegisterValues.Add(currentX);
            RegisterValues.Add(currentX + add.AddValue);
        }
        else if (command is NoOpCommand noOp)
        {
            RegisterValues.Add(currentX);
        }
    }
}