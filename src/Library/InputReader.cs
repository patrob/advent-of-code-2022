namespace Library;

public interface IInputReader
{
    string GetAllText(string path);
    IEnumerable<string> GetAllLinesOfText(string path);
}

public class InputReader : IInputReader
{
    public string GetAllText(string path)
    {
        return File.ReadAllText(path);
    }

    public IEnumerable<string> GetAllLinesOfText(string path)
    {
        return GetAllText(path).Split('\n');
    }
}