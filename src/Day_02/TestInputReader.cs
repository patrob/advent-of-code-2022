using Library;

namespace Day_02;

public class TestInputReader : IInputReader
{
    public string GetAllText(string path)
    {
        return "A Y\n"+
               "B X\n" +
               "C Z";
    }

    public string GetAllText()
    {
        return GetAllText(string.Empty);
    }

    public IEnumerable<string> GetAllLinesOfText(string path)
    {
        return GetAllText(string.Empty).Split('\n', StringSplitOptions.RemoveEmptyEntries);
    }

    public IEnumerable<string> GetAllLinesOfText()
    {
        return GetAllLinesOfText(string.Empty);
    }
}