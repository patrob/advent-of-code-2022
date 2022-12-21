using System.Text.RegularExpressions;

namespace Library.Day11;

public class Monkey
{
    public required string Name { get; set; }
    public Queue<long> Items = new();
    public required Func<long, long> Operation;
    public required Func<long, bool> Test;
    public required long DivisibleBy;
    public required int TrueMonkeyIndex;
    public required int FalseMonkeyIndex;
    public long TotalInspects = 0;
}

public static class MonkeyParser
{
    public static Monkey ParseMonkey(List<string> lines)
    {
        var monkeyData = lines.Take(6).ToList();
        var monkeyName = monkeyData[0].Split(' ').Last().Trim(':');
        var items = monkeyData[1].Split(':')[1].Split(',').Select(x => long.Parse(x.Trim())).ToList();
        var operationText = monkeyData[2].Split(':')[1].Trim();
        var testText = monkeyData[3].Split(':').Select(x => x.Trim()).ToArray()[1];
        var trueMonkey = int.Parse(monkeyData[4].Split(' ').Last());
        var falseMonkey = int.Parse(monkeyData[5].Split(' ').Last());
        var monkey = new Monkey
        {
            Name = monkeyName,
            Operation = ParseOperation(operationText),
            Test = ParseTest(testText),
            DivisibleBy = ParseDivisibleBy(testText),
            TrueMonkeyIndex = trueMonkey,
            FalseMonkeyIndex = falseMonkey
        };
        items.ForEach(x => monkey.Items.Enqueue(x));
        
        return monkey;
    }

    public static Func<long, long> ParseOperation(string operationText)
    {
        var split = operationText.Split("=").Select(x => x.Trim()).ToArray();
        var splitOp = split[1].Split('*', '+').Select(x => x.Trim()).ToArray();
        var operation = new Func<long, long, long>((a, b) => split[1].Contains("*") ? a * b : a + b);
        if (splitOp[0] == splitOp[1])
        {
            return (old) => operation(old, old);
        }

        return (old) => operation(old, long.Parse(splitOp[1]));
    }

    public static Func<long, bool> ParseTest(string testText)
    {
        var divisible = ParseDivisibleBy(testText);
        return (given) => given % divisible == 0;
    }

    public static long ParseDivisibleBy(string testText)
    {
        var textToParse = testText.Split(' ').Last();
        return long.Parse(textToParse);
    }

    public static List<Monkey> ParseMonkeys(List<string> input)
    {
        var monkeys = new List<Monkey>();
        var monkeyLines = input.TakeWhile(x => !string.IsNullOrEmpty(x)).ToList();
        var skip = monkeyLines.Count + 1;
        while (monkeyLines.Any())
        {
            monkeys.Add(ParseMonkey(monkeyLines));
            monkeyLines = input.Skip(skip).TakeWhile(x => !string.IsNullOrEmpty(x)).ToList();
            skip += monkeyLines.Count + 1;
        }

        return monkeys;
    }
}

public static class MonkeyBusiness
{
    public static List<Monkey> Monkeys = new();

    public static void LoadMonkeys(List<Monkey> monkeys)
    {
        Monkeys = monkeys;
    }

    public static void Execute(Monkey monkey, Func<long, long> deWorry)
    {
        var item = monkey.Items.Dequeue();
        var result = deWorry(monkey.Operation(item));
        var test = monkey.Test(result);
        Monkeys[test ? monkey.TrueMonkeyIndex : monkey.FalseMonkeyIndex].Items.Enqueue(result);
        monkey.TotalInspects++;
    }

    public static void ExecuteRounds(int rounds, Func<long, long> deWorry)
    {
        for (var i = 0; i < rounds; i++)
        {
            Monkeys.ForEach(monkey =>
            {
                while (monkey.Items.Any())
                {
                    Execute(monkey, deWorry);
                }
            });
        }
    }

    public static long CalculateMonkeyBusiness()
    {
        return Monkeys
            .Select(x => x.TotalInspects)
            .OrderByDescending(x => x)
            .Take(2)
            .Aggregate(1L, (acc, current) => acc * current);
    }
}
