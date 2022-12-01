using TestingLibrary;

namespace Day_01.Tests;

public class CalorieCountParserTests : BaseTest
{
    private readonly CalorieCountParser sut;
    public CalorieCountParserTests()
    {
        sut = new CalorieCountParser();
    }
    
    [Fact]
    public void ParseCalorieCounts_ShouldReturnExpectedLength()
    {
        var input = new List<string>
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000"
        };
        sut.ParseCalorieCounts(input).Should().HaveCount(5);
    }

    [Fact]
    public void METHOD_ShouldDoSomething()
    {
        var input = new List<string>
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000"
        };
        var expected = new List<List<int>>
        {
            new() { 1000, 2000, 3000 },
            new() { 4000 },
            new() { 5000, 6000 },
            new() { 7000, 8000, 9000 },
            new() { 10000 }
        };
        sut.ParseCalorieCounts(input).Should().BeEquivalentTo(expected);
    }
}