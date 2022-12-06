using FluentAssertions;
using Library;
using Moq;

namespace Day_06.Tests;

public class Day06SolverTests
{
    private readonly Mock<IInputReader> _mockReader = new();
    private readonly Day06Solver _sut;

    public Day06SolverTests()
    {
        _sut = new Day06Solver(_mockReader.Object);
    }
    
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 4, 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 4, 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 4, 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4, 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4, 11)]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14, 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 14, 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 14, 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14, 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14, 26)]
    public void FindUniqueChars(string input, int size, int expectedResultSize)
    {
        _sut.FindUniqueChars(input, size).Should().HaveCount(expectedResultSize);
    }
}