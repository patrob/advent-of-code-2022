namespace Library.Day10;

public static class CommandParser
{
    public static Command ParseCommand(string commandText)
    {
        if (commandText == "noop") return new NoOpCommand();
        var commandWithArgs = commandText.Split(' ');
        if (commandWithArgs[0] == "addx")
        {
            return new AddCommand(int.Parse(commandWithArgs[1]));
        }
        throw new NotImplementedException("No other command implemented at this time.");
    }

    public static List<Command> ParseCommands(IEnumerable<string> commandLines)
    {
        return commandLines.Select(ParseCommand).ToList();
    }
}