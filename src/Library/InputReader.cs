namespace Library;

public interface IInputReader
{
    bool IsExample { get; }
    string GetAllText(string path);
    string GetAllText();
    List<string> GetAllLinesOfText(string path);
    List<string> GetAllLinesOfText();
}

public class InputReader : IInputReader
{
    public bool IsExample { get; }
    private const string ExamplePath = "./ExampleData.txt";
    private const string ProblemPath = "./ProblemData.txt";
    private readonly string _path;

    public InputReader(bool isExample = false)
    {
        _path = isExample ? ExamplePath : ProblemPath;
        IsExample = isExample;
    }
    
    public string GetAllText(string path)
    {
        return File.ReadAllText(path);
    }

    public string GetAllText()
    {
        return GetAllText(_path);
    }

    public List<string> GetAllLinesOfText(string path)
    {
        return GetAllText(path).Split('\n').ToList();
    }

    public List<string> GetAllLinesOfText()
    {
        return GetAllLinesOfText(_path);
    }
}
