using Library;

namespace Day_03;

public class TestInputReader : IInputReader
{
    public string GetAllText(string path)
    {
        return
            "vJrwpWtwJgWrhcsFMMfFFhFp\n" +
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\n" +
            "PmmdzqPrVvPwwTWBwg\n" +
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\n" +
            "ttgJtRGJQctTZtZT\n" +
            "CrZsJsPPZsGzwwsLwLmpwMDw";
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