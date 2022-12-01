using Library;

namespace Day_01;

public class TestInputReader : IInputReader
{
    public string GetAllText(string path)
    {
        return "1000\n" +
               "2000\n" +
               "3000\n" +
               "\n" +
               "4000\n" +
               "\n" +
               "5000\n" +
               "6000\n" +
               "\n" +
               "7000\n" +
               "8000\n" +
               "9000\n" +
               "\n" +
               "10000\n";
    }

    public IEnumerable<string> GetAllLinesOfText(string path)
    {
        return GetAllText(string.Empty).Split('\n');
    }
}