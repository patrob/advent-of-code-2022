namespace Day_03.Tests;

public class DuplicateItemDetectorTests
{
    public static IEnumerable<object[]> DuplicateItemTestData => new List<object[]>
    {
        new object[] { ("vJrwpWtwJgWr", "hcsFMMfFFhFp"), new RuckSackItem('p', 16)},
        new object[] { ("jqHRNqRjqzjGDLGL","rsFMfFZSrLrFZsSL"), new RuckSackItem('L', 38)},
        new object[] { ("PmmdzqPrV","vPwwTWBwg"), new RuckSackItem('P', 42)},
        new object[] { ("wMqvLMZHhHMvwLH", "jbvcjnnSBnvTQFn"), new RuckSackItem('v', 22)},
        new object[] { ("ttgJtRGJ", "QctTZtZT"), new RuckSackItem('t', 20)},
        new object[] { ("CrZsJsPPZsGz", "wwsLwLmpwMDw"), new RuckSackItem('s', 19)},
    };
    
    public static IEnumerable<object[]> DuplicateItemMultipleTestData => new List<object[]>
    {
        new object[]
        {
            new List<(string, string)>
            {
                ("vJrwpWtwJgWr", "hcsFMMfFFhFp"),
                ("jqHRNqRjqzjGDLGL","rsFMfFZSrLrFZsSL"),
                ("PmmdzqPrV","vPwwTWBwg")
            },
            new RuckSackItem('r', 18)
        },
        new object[]
        {
            new List<(string, string)>
            {
                ("wMqvLMZHhHMvwLH", "jbvcjnnSBnvTQFn"),
                ("ttgJtRGJ", "QctTZtZT"),
                ("CrZsJsPPZsGz", "wwsLwLmpwMDw")
            },
            new RuckSackItem('Z', 52)
        },
    };

    private readonly DuplicateItemDetector _sut;
    
    public DuplicateItemDetectorTests()
    {
        _sut = new DuplicateItemDetector(new RuckSackItemFactory());
    }

    [Theory]
    [MemberData(nameof(DuplicateItemTestData))]
    public void GetDuplicateItem_ShouldReturnExpectedItem((string, string) ruckSack, RuckSackItem expected)
    {
        _sut.GetDuplicateItem(ruckSack).Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(DuplicateItemMultipleTestData))]
    public void GetDuplicateItemAcrossMultiple_ShouldReturnExpectedItem(List<(string, string)> ruckSacks, RuckSackItem expected)
    {
        _sut.GetDuplicateItemAcrossMultiple(ruckSacks).Should().Be(expected);
    }
}