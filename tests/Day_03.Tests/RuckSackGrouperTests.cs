namespace Day_03.Tests;

public class RuckSackGrouperTests
{
    public static IEnumerable<object[]> RuckSackGroupTestData = new List<object[]>
    {
        new object[] {
            new List<(string, string)>
            {
                ("vJrwpWtwJgWr", "hcsFMMfFFhFp"),
                ("jqHRNqRjqzjGDLGL","rsFMfFZSrLrFZsSL"),
                ("PmmdzqPrV","vPwwTWBwg"),
                ("wMqvLMZHhHMvwLH", "jbvcjnnSBnvTQFn"),
                ("ttgJtRGJ", "QctTZtZT"),
                ("CrZsJsPPZsGz", "wwsLwLmpwMDw")
            },
            3,
            new List<List<(string, string)>>
            {
                new()
                {
                    ("vJrwpWtwJgWr", "hcsFMMfFFhFp"),
                    ("jqHRNqRjqzjGDLGL","rsFMfFZSrLrFZsSL"),
                    ("PmmdzqPrV","vPwwTWBwg")
                },
                new()
                {
                    ("wMqvLMZHhHMvwLH", "jbvcjnnSBnvTQFn"),
                    ("ttgJtRGJ", "QctTZtZT"),
                    ("CrZsJsPPZsGz", "wwsLwLmpwMDw")
                },
            }
        }
    };

    [Theory]
    [MemberData(nameof(RuckSackGroupTestData))]
    public void GroupByCount_ShouldReturnExpectedList(List<(string,string)> ruckSacks, int numberOfSacks, List<List<(string, string)>> expected)
    {
        new RuckSackGrouper().GroupByCount(ruckSacks, numberOfSacks).Should().BeEquivalentTo(expected);
    }
}