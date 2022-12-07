using AoCHelper;
using Library.Day07;
using Directory = Library.Day07.Directory;
using File = System.IO.File;

namespace AdventOfCode;

public class Day_07 : BaseDay
{
    private readonly List<string> _input;
    private readonly FileSystemParser _parser = new();
    private Directory _root;
    
    public Day_07()
    {
        _input = File.ReadAllText(InputFilePath).Split('\n').ToList();
        _root = _parser.Parse(_input);
    }
    
    public override ValueTask<string> Solve_1()
    {
        var answer = _root.GetAllDirectoriesAndSizes().Values.Where(x => x < 100000).Sum();
        return ValueTask.FromResult($"{answer}");
    }

    public override ValueTask<string> Solve_2()
    {
        const long maxRoom = 70000000;
        const long updateSize = 30000000;
        var rootSize = _root.GetSize();
        var dirSizes = _root.GetAllDirectoriesAndSizes();
        var sizeToFreeUp = dirSizes.Keys
            .Where(x => maxRoom - rootSize + dirSizes[x] > updateSize)
            .Select(x => new { Dir = x, Size = dirSizes[x] })
            .OrderBy(x => x.Size)
            .First().Size;
        return ValueTask.FromResult($"{sizeToFreeUp}");
    }
}