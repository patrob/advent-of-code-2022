namespace Day_02.Tests;

public class RoundParserTests
{
    [Theory]
    [InlineData("A Y", 8)]
    [InlineData("B X", 1)]
    [InlineData("C Z", 6)]
    public void GetRoundScore_ShouldGetExpectedValue(string input, int expected)
    {
        var parser = new RoundParser(new PlayOptionParser(), new PointTallier());
        parser.GetRoundScore(input).Should().Be(expected);
    }
}