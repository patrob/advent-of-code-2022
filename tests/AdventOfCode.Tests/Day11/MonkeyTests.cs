using Library.Day11;

namespace AdventOfCode.Tests.Day11;

public class MonkeyTests
{
    private List<Monkey> GetPart1ExampleMonkeys()
    {
        var testInput = new List<string>
        {
            "Monkey 0:",
            "Starting items: 79, 98",
            "Operation: new = old * 19",
            "Test: divisible by 23",
            "If true: throw to monkey 2",
            "If false: throw to monkey 3",
            "",
            "Monkey 1:",
            "Starting items: 54, 65, 75, 74",
            "Operation: new = old + 6",
            "Test: divisible by 19",
            "If true: throw to monkey 2",
            "If false: throw to monkey 0",
            "",
            "Monkey 2:",
            "Starting items: 79, 60, 97",
            "Operation: new = old * old",
            "Test: divisible by 13",
            "If true: throw to monkey 1",
            "If false: throw to monkey 3",
            "",
            "Monkey 3:",
            "Starting items: 74",
            "Operation: new = old + 3",
            "Test: divisible by 17",
            "If true: throw to monkey 0",
            "If false: throw to monkey 1"
        };
        return MonkeyParser.ParseMonkeys(testInput);
    }
    
    [Theory]
    [InlineData("new = old * 19", 79, 1501)]
    [InlineData("new = old * 19", 98, 1862)]
    [InlineData("new = old + 6", 54, 60)]
    [InlineData("new = old * old", 79, 6241)]
    public void ParseOperationExecute(string operationText, long old, long expected)
    {
        MonkeyParser.ParseOperation(operationText)(old).Should().Be(expected);
    }

    [Theory]
    [InlineData("divisible by 23", 500, false)]
    [InlineData("divisible by 23", 620, false)]
    [InlineData("divisible by 13", 2080, true)]
    public void ParseTestExecute(string testText, long input, bool expected)
    {
        MonkeyParser.ParseTest(testText)(input).Should().Be(expected);
    }

    [Fact]
    public void ParseMonkeys_ShouldParseMonkeys()
    {
        var testInput = new List<string>
        {
            "Monkey 0:",
            "Starting items: 79, 98",
            "Operation: new = old * 19",
            "Test: divisible by 23",
            "If true: throw to monkey 2",
            "If false: throw to monkey 3",
            "",
            "Monkey 1:",
            "Starting items: 54, 65, 75, 74",
            "Operation: new = old + 6",
            "Test: divisible by 19",
            "If true: throw to monkey 2",
            "If false: throw to monkey 0",
            "",
            "Monkey 2:",
            "Starting items: 79, 60, 97",
            "Operation: new = old * old",
            "Test: divisible by 13",
            "If true: throw to monkey 1",
            "If false: throw to monkey 3",
            "",
            "Monkey 3:",
            "Starting items: 74",
            "Operation: new = old + 3",
            "Test: divisible by 17",
            "If true: throw to monkey 0",
            "If false: throw to monkey 1"
        };
        var monkeys = MonkeyParser.ParseMonkeys(testInput);
        monkeys.Should().HaveCount(4);
        monkeys[0].TrueMonkeyIndex.Should().Be(2);
        monkeys[0].FalseMonkeyIndex.Should().Be(3);
        monkeys[0].Operation(monkeys[0].Items.Peek()).Should().Be(1501);
        monkeys[0].Test(500).Should().Be(false);
    }

    [Fact]
    public void CalculateMonkeyBusiness_ShouldReturnExpected()
    {
        var monkeys = GetPart1ExampleMonkeys();
        MonkeyBusiness.LoadMonkeys(monkeys);
        MonkeyBusiness.ExecuteRounds(20, (worry) => worry / 3);
        MonkeyBusiness.CalculateMonkeyBusiness().Should().Be(10605L);
    }
    
    [Theory]
    [InlineData(1, 2, 4, 3, 6)]
    [InlineData(20, 99, 97, 8, 103)]
    [InlineData(1000, 5204, 4792, 199, 5192)]
    [InlineData(10000, 52166, 47830, 1938, 52013)]
    public void ExecuteMonkeyBusinessPart2_ShouldReturnExpected(int rounds, long inspects0, long inspects1, long inspects2, long inspects3)
    {
        var monkeys = GetPart1ExampleMonkeys();
        MonkeyBusiness.LoadMonkeys(monkeys);
        var mod = monkeys.Select(x => x.DivisibleBy).Aggregate(1L, (acc, cur) => acc * cur);
        MonkeyBusiness.ExecuteRounds(rounds, (worry) => worry % mod);
        MonkeyBusiness.Monkeys[0].TotalInspects.Should().Be(inspects0);
        MonkeyBusiness.Monkeys[1].TotalInspects.Should().Be(inspects1);
        MonkeyBusiness.Monkeys[2].TotalInspects.Should().Be(inspects2);
        MonkeyBusiness.Monkeys[3].TotalInspects.Should().Be(inspects3);
    }
    
    [Fact]
    public void CalculateMonkeyBusinessPart2_ShouldReturnExpected()
    {
        var monkeys = GetPart1ExampleMonkeys();
        MonkeyBusiness.LoadMonkeys(monkeys);
        var mod = monkeys.Select(x => x.DivisibleBy).Aggregate(1L, (acc, cur) => acc * cur);
        MonkeyBusiness.ExecuteRounds(10000, (worry) => worry % mod);
        MonkeyBusiness.CalculateMonkeyBusiness().Should().Be(2713310158);
    }
}