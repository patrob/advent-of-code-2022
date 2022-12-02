namespace Day_02.Tests;

public class PointTallierTests
{
    [Theory]
    [InlineData(PlayOptionEnum.Rock, PlayOptionEnum.Paper, 8)]
    [InlineData(PlayOptionEnum.Paper, PlayOptionEnum.Rock, 1)]
    [InlineData(PlayOptionEnum.Scissors, PlayOptionEnum.Scissors, 6)]
    public void TallyScore_ShouldResultInExpectedValue(PlayOptionEnum opponent, PlayOptionEnum myPlay, int expected)
    {
        var tallier = new PointTallier();
        tallier.TallyScore(new PlayOption(opponent), new PlayOption(myPlay)).Should().Be(expected);
    }
}