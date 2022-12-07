namespace Library.Day07;

public class FileSystemParser
{
    public Directory Root { get; } = new Directory("/");

    public Directory Parse(List<string> commandOutputs)
    {
        var output = commandOutputs.Skip(1) // first line is `$cd /`
            .ToArray();

        var directory = GetDirectoryTree(Root, output);
        while (true)
        {
            if (directory.Parent == null) return directory;
            directory = directory.Parent;
        }
    }

    public Directory GetDirectoryTree(Directory currentDirectory, string[] remainingOutput)
    {
        if (!remainingOutput.Any()) return currentDirectory;
        var currentLine = remainingOutput.First();
        if (currentLine.StartsWith("dir"))
        {
            var newDirectory = new Directory(currentLine.Split(" ")[1])
            {
                Parent = currentDirectory
            };
            currentDirectory.Directories.Add(newDirectory);
            return GetDirectoryTree(currentDirectory, remainingOutput[1..]);
        }

        if (currentLine.StartsWith("$ cd"))
        {
            var direction = currentLine.Split(" ") .Last();
            return direction switch
            {
                "/" => GetRootDirectory(currentDirectory),
                ".." => GetDirectoryTree(currentDirectory.Parent!, remainingOutput[1..]),
                _ => GetDirectoryTree(currentDirectory.Directories.Find(x => x.Name == direction)!,
                    remainingOutput[1..])
            };
        }

        if (currentLine.StartsWith("$ ls"))
        {
            return GetDirectoryTree(currentDirectory, remainingOutput[1..]);
        }

        var fileInfo = currentLine.Split(" ");
        var file = new File(currentDirectory, fileInfo[1], long.Parse(fileInfo[0]));
        currentDirectory.Files.Add(file);
        return GetDirectoryTree(currentDirectory, remainingOutput[1..]);
    }

    public Directory GetRootDirectory(Directory child)
    {
        while (true)
        {
            if (child.Parent == null) return child;
            child = child.Parent;
        }
    }
}