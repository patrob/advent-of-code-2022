using Microsoft.Extensions.DependencyInjection;

namespace Day_01;

public class Part1Runner
{
    private readonly IServiceProvider _services;

    public Part1Runner(IServiceProvider services)
    {
        _services = services;
    }

    public void Run(string filePath)
    {
        var reader = _services.GetRequiredService<IInputReader>();
        RunWith(reader.GetAllText(filePath));
    }

    public void RunWith(string input)
    {
        var lines = input.Split('\n').ToList();
        var parser = _services.GetRequiredService<ICalorieCountParser>();
        var counter = _services.GetRequiredService<ICalorieCounter>();

        var counts = parser.ParseCalorieCounts(lines);
        var max = counter.GetMaxCalorieCount(counts);
        Console.WriteLine($"Max Calories: {max}");
        var top3 = counter.GetTop3CalorieCounts(counts);
        Console.WriteLine($"Top 3 Total: {top3}");
    }
}