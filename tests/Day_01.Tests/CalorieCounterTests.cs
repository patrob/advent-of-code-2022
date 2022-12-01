namespace Day_01.Tests;

public class CalorieCounterTests
{
    private readonly CalorieCounter _sut;

    public CalorieCounterTests()
    {
        _sut = new CalorieCounter();
    }

    [Fact]
    public void GetMaxCalorieCount_ShouldReturnMaxCalorieCount()
    {
        var calorieCounts = new List<List<int>>
        {
            new() { 1000, 2000, 3000 },
            new() { 4000 },
            new() { 5000, 6000 },
            new() { 7000, 8000, 9000 },
            new() { 10000 }
        };
        _sut.GetMaxCalorieCount(calorieCounts).Should().Be(24000);
    }

    [Fact]
    public void GetTop3CalorieCounts_ShouldReturnTop3SummedCalorieCount()
    {
        var calorieCounts = new List<List<int>>
        {
            new() { 1000, 2000, 3000 },
            new() { 4000 },
            new() { 5000, 6000 },
            new() { 7000, 8000, 9000 },
            new() { 10000 }
        };
        _sut.GetTop3CalorieCounts(calorieCounts).Should().Be(45000);
    }
}