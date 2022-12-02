namespace Day_02.Tests;

public class PredictableRoundParserTests
{
    [Theory]
    [InlineData("A Y", 4)]
    [InlineData("B X", 1)]
    [InlineData("C Z", 7)]
    public void GetRoundScore_ShouldGetExpectedValue(string input, int expected)
    {
        new PredictableRoundParser(new PlayOptionParser(), new PointTallier())
            .GetRoundScore(input).Should().Be(expected);
    }

    [Theory]
    [InlineData(PlayOptionEnum.Rock, "X", PlayOptionEnum.Scissors)]
    [InlineData(PlayOptionEnum.Rock, "Y", PlayOptionEnum.Rock)]
    [InlineData(PlayOptionEnum.Rock, "Z", PlayOptionEnum.Paper)]
    [InlineData(PlayOptionEnum.Paper, "X", PlayOptionEnum.Rock)]
    [InlineData(PlayOptionEnum.Paper, "Y", PlayOptionEnum.Paper)]
    [InlineData(PlayOptionEnum.Paper, "Z", PlayOptionEnum.Scissors)]
    [InlineData(PlayOptionEnum.Scissors, "X", PlayOptionEnum.Paper)]
    [InlineData(PlayOptionEnum.Scissors, "Y", PlayOptionEnum.Scissors)]
    [InlineData(PlayOptionEnum.Scissors, "Z", PlayOptionEnum.Rock)]
    public void GetDesiredOutcome_ShouldGetExpectedValue(PlayOptionEnum opponent, string input, PlayOptionEnum expected)
    {
        new PredictableRoundParser(new PlayOptionParser(), new PointTallier())
            .GetDesiredOutcome(opponent, input).Should().Be(expected);
    }
}