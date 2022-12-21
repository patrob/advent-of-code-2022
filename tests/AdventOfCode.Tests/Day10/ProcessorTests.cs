using Library.Day10;

namespace AdventOfCode.Tests.Day10;

public class ProcessorTests
{
    public static Processor GetPreProcessed(List<Command>? commands = null)
    {
        commands ??= GetPart1ExampleInput();
        var processor = new Processor();
        commands.ForEach(processor.Execute);
        return processor;
    }
    public static List<Command> GetPart1ExampleInput()
    {
        return new List<Command>
        {
            new AddCommand(15),
            new AddCommand(-11),
            new AddCommand(6),
            new AddCommand(-3),
            new AddCommand(5),
            new AddCommand(-1),
            new AddCommand(-8),
            new AddCommand(13),
            new AddCommand(4),
            new NoOpCommand(),
            new AddCommand(-1),
            new AddCommand(5),
            new AddCommand(-1),
            new AddCommand(5),
            new AddCommand(-1),
            new AddCommand(5),
            new AddCommand(-1),
            new AddCommand(5),
            new AddCommand(-1),
            new AddCommand(-35),
            new AddCommand(1),
            new AddCommand(24),
            new AddCommand(-19),
            new AddCommand(1),
            new AddCommand(16),
            new AddCommand(-11),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(21),
            new AddCommand(-15),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(-3),
            new AddCommand(9),
            new AddCommand(1),
            new AddCommand(-3),
            new AddCommand(8),
            new AddCommand(1),
            new AddCommand(5),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(-36),
            new NoOpCommand(),
            new AddCommand(1),
            new AddCommand(7),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(2),
            new AddCommand(6),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(1),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(7),
            new AddCommand(1),
            new NoOpCommand(),
            new AddCommand(-13),
            new AddCommand(13),
            new AddCommand(7),
            new NoOpCommand(),
            new AddCommand(1),
            new AddCommand(-33),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(2),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(8),
            new NoOpCommand(),
            new AddCommand(-1),
            new AddCommand(2),
            new AddCommand(1),
            new NoOpCommand(),
            new AddCommand(17),
            new AddCommand(-9),
            new AddCommand(1),
            new AddCommand(1),
            new AddCommand(-3),
            new AddCommand(11),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(1),
            new NoOpCommand(),
            new AddCommand(1),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(-13),
            new AddCommand(-19),
            new AddCommand(1),
            new AddCommand(3),
            new AddCommand(26),
            new AddCommand(-30),
            new AddCommand(12),
            new AddCommand(-1),
            new AddCommand(3),
            new AddCommand(1),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(-9),
            new AddCommand(18),
            new AddCommand(1),
            new AddCommand(2),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(9),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(-1),
            new AddCommand(2),
            new AddCommand(-37),
            new AddCommand(1),
            new AddCommand(3),
            new NoOpCommand(),
            new AddCommand(15),
            new AddCommand(-21),
            new AddCommand(22),
            new AddCommand(-6),
            new AddCommand(1),
            new NoOpCommand(),
            new AddCommand(2),
            new AddCommand(1),
            new NoOpCommand(),
            new AddCommand(-10),
            new NoOpCommand(),
            new NoOpCommand(),
            new AddCommand(20),
            new AddCommand(1),
            new AddCommand(2),
            new AddCommand(2),
            new AddCommand(-6),
            new AddCommand(-11),
            new NoOpCommand(),
            new NoOpCommand(),
            new NoOpCommand(),
        };
    }

    public static string[] GetPart2ExampleOutput()
    {
        return new[]
        {
            "##..##..##..##..##..##..##..##..##..##..",
            "###...###...###...###...###...###...###.",
            "####....####....####....####....####....",
            "#####.....#####.....#####.....#####.....",
            "######......######......######......####",
            "#######.......#######.......#######....."
        };
    }
    
    public static IEnumerable<object[]> Part1TestData = new List<object[]>
    {
        new object[]
        {
            GetPart1ExampleInput(),
            20,
            420
        },
        new object[]
        {
            GetPart1ExampleInput(),
            60,
            1140
        },
        new object[]
        {
            GetPart1ExampleInput(),
            100,
            1800
        },
        new object[]
        {
            GetPart1ExampleInput(),
            140,
            2940
        },
        new object[]
        {
            GetPart1ExampleInput(),
            180,
            2880
        },
        new object[]
        {
            GetPart1ExampleInput(),
            220,
            3960
        },
    };

    private readonly Processor _processor = GetPreProcessed();
    
    [Theory]
    [MemberData(nameof(Part1TestData))]
    public void GetSignalStrength(List<Command> commands, int cycle, int expectedStrength)
    {
        commands.ForEach(c => _processor.Execute(c));
        _processor.GetSignalStrength(cycle).Should().Be(expectedStrength);
    }

    [Fact]
    public void GetSignalStrengths_ShouldReturnExpected()
    {
        _processor.GetSignalStrengths().Should().Be(13140);
    }

    [Theory]
    [InlineData(0, 1, "#")]
    [InlineData(1, 1, "#")]
    [InlineData(2, 15, ".")]
    [InlineData(3, 15, ".")]
    [InlineData(4, 5, "#")]
    public void GetPixelToPrint_ShouldReturnExpectedString(int cycle, int spriteX, string expected)
    {
        _processor.GetPixelToPrint(cycle, spriteX).Should().Be(expected);
    }

    [Fact]
    public void GetPixelsToPrint_ShouldReturnExpected()
    {
        _processor.GetPixelsToPrint().Should().BeEquivalentTo(GetPart2ExampleOutput());
    }
}