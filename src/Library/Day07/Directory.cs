namespace Library.Day07;

public record Directory
{
    public string Name { get; set; } = string.Empty;
    public Directory? Parent { get; set; }
    public List<Directory> Directories { get; set; } = new();
    public List<File> Files { get; set; } = new();

    public Directory(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        var files = Files.Select(x => $"file /{x.Name} {x.Size}").Aggregate((c, n) => c + "\n" + n);
        var dirSize = GetSize();
        var thisDir = $"dir {Name} {dirSize}\n{files}";
        var remaining = Directories.Any()
            ? Directories.Select(x => ToString(x, $"/")).Aggregate((c, n) => c + "\n" + n)
            : string.Empty;
        return $"{thisDir}\n{remaining}";
    }

    public string ToString(Directory directory, string path)
    {
        var dirPath = $"{path}{directory.Name}";
        var files = directory.Files.Select(x => $"file {dirPath}/{x.Name} {x.Size}").Aggregate((c, n) => c + "\n" + n);
        var dirSize = directory.GetSize();
        var thisDir = $"dir {dirPath} {dirSize}\n{files}";
        var remaining = directory.Directories.Any()
            ? directory.Directories.Select(x => ToString(x, dirPath + "/")).Aggregate((c, n) => c + "\n" + n)
            : string.Empty;
        return $"{thisDir}\n{remaining}";
    }

    public long GetSize()
    {
        return Files.Sum(x => x.Size) + Directories.Sum(GetSize);
    }

    public long GetSize(Directory directory)
    {
        return directory.Files.Sum(x => x.Size) + directory.Directories.Sum(GetSize);
    }

    public Dictionary<string, long> GetAllDirectoriesAndSizes()
    {
        var result = new Dictionary<string, long>();
        GetAllDirectoriesAndSizes(result, this);
        return result;
    }

    public void GetAllDirectoriesAndSizes(Dictionary<string, long> result, Directory directory, string path = "")
    {
        var dirPath = $"{path}/{(directory.Name == "/" ? string.Empty : directory.Name)}";
        result.Add(dirPath, directory.GetSize());
        if (directory.Directories.Any()) directory.Directories.ForEach(x => GetAllDirectoriesAndSizes(result, x, dirPath));
    }
}