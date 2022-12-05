namespace Day_05;

public interface IElfStack<T>
{
    void Push(T item);
    void PushRange(IEnumerable<T> items);
    T Pop();
    IEnumerable<T> PopMultiple(int count);
    T Peek();
    bool Any();
    void PrintStack();
}

public class BaseElfStacker : IElfStack<string>
{
    protected List<string> Stack;

    protected BaseElfStacker()
    {
        Stack = new List<string>();
    }

    public virtual void Push(string item)
    {
        Stack.Add(item);
    }

    public virtual void PushRange(IEnumerable<string> items)
    {
        Stack.InsertRange(0, items);
    }

    public virtual string Pop()
    {
        var result = Stack.Last();
        Stack.RemoveAt(Stack.Count - 1);
        return result;
    }

    public virtual IEnumerable<string> PopMultiple(int count)
    {
        var result = Stack.Take(count).ToList();
        Stack.RemoveRange(0, count);
        return result;
    }

    public string Peek()
    {
        return Stack[0];
    }

    public bool Any()
    {
        return Stack.Any();
    }

    public void PrintStack()
    {
        Stack.ToArray().Reverse().ToList().ForEach(Console.Write);
        Console.WriteLine();
    }
}

public class Stacker9000 : BaseElfStacker
{
    public override IEnumerable<string> PopMultiple(int count)
    {
        return base.PopMultiple(count).Reverse();
    }
}

public class Stacker9001 : BaseElfStacker
{
}