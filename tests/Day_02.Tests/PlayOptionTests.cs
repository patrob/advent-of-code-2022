namespace Day_02.Tests;

public class PlayOptionTests
{
    [Theory]
    [InlineData(PlayOptionEnum.Rock, PlayOptionEnum.Rock, 0)]
    [InlineData(PlayOptionEnum.Rock, PlayOptionEnum.Paper, -1)]
    [InlineData(PlayOptionEnum.Rock, PlayOptionEnum.Scissors, 1)]
    [InlineData(PlayOptionEnum.Paper, PlayOptionEnum.Rock, 1)]
    [InlineData(PlayOptionEnum.Paper, PlayOptionEnum.Paper, 0)]
    [InlineData(PlayOptionEnum.Paper, PlayOptionEnum.Scissors, -1)]
    [InlineData(PlayOptionEnum.Scissors, PlayOptionEnum.Rock, -1)]
    [InlineData(PlayOptionEnum.Scissors, PlayOptionEnum.Paper, 1)]
    [InlineData(PlayOptionEnum.Scissors, PlayOptionEnum.Scissors, 0)]
    public void CompareTo_ShouldReturnExpected(PlayOptionEnum me, PlayOptionEnum opponent, int expected)
    {
        var myOption = new PlayOption(me);
        var opponentOption = new PlayOption(opponent);
        myOption.CompareTo(opponentOption).Should().Be(expected);
    }
}