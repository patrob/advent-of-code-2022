namespace Library;

public abstract class BasePuzzleSolver : IPuzzleSolver
{
    protected readonly IInputReader Reader;

    protected BasePuzzleSolver(IInputReader reader)
    {
        Reader = reader;
    }
    
    public virtual string Solve()
    {
        return Reader.GetAllText();
    }
}