

namespace Day_03.Tests;

public class CompartmentParserTests : BaseTest
{
    private readonly CompartmentParser _sut;
    
    public CompartmentParserTests()
    {
        _sut = new CompartmentParser();
    }

    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", "vJrwpWtwJgWr","hcsFMMfFFhFp")]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "jqHRNqRjqzjGDLGL","rsFMfFZSrLrFZsSL")]
    [InlineData("PmmdzqPrVvPwwTWBwg", "PmmdzqPrV","vPwwTWBwg")]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "wMqvLMZHhHMvwLH", "jbvcjnnSBnvTQFn")]
    [InlineData("ttgJtRGJQctTZtZT", "ttgJtRGJ", "QctTZtZT")]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", "CrZsJsPPZsGz", "wwsLwLmpwMDw")]
    public void ParseCompartments_ShouldReturnExpectedValue(string input, string compartment1, string compartment2)
    {
        var expected = (compartment1, compartment2);
        new CompartmentParser().ParseCompartments(input).Should().Be(expected);
    }
}