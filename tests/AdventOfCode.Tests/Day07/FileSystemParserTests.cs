using System.Text;
using Library.Day07;
using Directory = Library.Day07.Directory;
using File = Library.Day07.File;

namespace AdventOfCode.Tests.Day07;

public class FileSystemParserTests
{
    private List<string> GetTestInput()
    {
        var sb = new StringBuilder();

        sb.AppendLine("$ cd /");
        sb.AppendLine("$ ls");
        sb.AppendLine("dir a");
        sb.AppendLine("14848514 b.txt");
        sb.AppendLine("8504156 c.dat");
        sb.AppendLine("dir d");
        sb.AppendLine("$ cd a");
        sb.AppendLine("$ ls");
        sb.AppendLine("dir e");
        sb.AppendLine("29116 f");
        sb.AppendLine("2557 g");
        sb.AppendLine("62596 h.lst");
        sb.AppendLine("$ cd e");
        sb.AppendLine("$ ls");
        sb.AppendLine("584 i");
        sb.AppendLine("$ cd ..");
        sb.AppendLine("$ cd ..");
        sb.AppendLine("$ cd d");
        sb.AppendLine("$ ls");
        sb.AppendLine("4060174 j");
        sb.AppendLine("8033020 d.log");
        sb.AppendLine("5626152 d.ext");
        sb.AppendLine("7214296 k");

        return sb.ToString().Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public Directory Parse(List<string>? input = null)
    {
        return new FileSystemParser().Parse(input ?? GetTestInput());
    }

    [Fact]
    public void Parse_Test()
    {
        var root = Parse();
        root.Files.Should().HaveCount(2);
        root.Directories.Should().HaveCount(2);
        root.Directories[0].Directories.Should().HaveCount(1);
        root.Directories[0].Directories[0].GetSize().Should().Be(584);
        root.GetAllDirectoriesAndSizes().Should().HaveCount(4);
        root.GetAllDirectoriesAndSizes().Values.Where(x => x < 100000).Sum().Should().Be(95437);

    }

    [Fact]
    public void Delete_Test()
    {
        const long maxRoom = 70000000;
        const long updateSize = 30000000;
        var root = Parse();
        var rootSize = root.GetSize();
        var dirSizes = root.GetAllDirectoriesAndSizes();
        var sizeToFreeUp = dirSizes.Keys.Where(x => maxRoom - rootSize + dirSizes[x] > updateSize).Select(x => new { Dir = x, Size = dirSizes[x] }).OrderBy(x => x.Size).First().Size;
        sizeToFreeUp.Should().Be(24933642);
    }

    public static IEnumerable<object[]> DirectorySizeTestData = new List<object[]>
    {
        new object[]
        {
            new Directory("Root")
            {
                Files = new List<File>
                {
                    new(null!, "test", 1)
                }
            },
            1
        },
        new object[]
        {
            new Directory("Root")
            {
                Files = new List<File>
                {
                    new(null!, "test1", 1),
                    new(null!, "test2", 2)
                }
            },
            3
        },
        new object[]
        {
            new Directory("Root")
            {
                Files = new List<File>
                {
                    new(null!, "test1", 1),
                    new(null!, "test2", 2)
                },
                Directories = new List<Directory>
                {
                    new("Child1")
                    {
                        Files = new List<File>
                        {
                            new(null!, "childTest1", 1),
                            new(null!, "childTest2", 2)
                        }
                    }
                }
            },
            6
        }
    };

    [Theory]
    [MemberData(nameof(DirectorySizeTestData))]
    public void GetSize_Test(Directory root, int expectedSize)
    {
        root.GetSize().Should().Be(expectedSize);
    }
}