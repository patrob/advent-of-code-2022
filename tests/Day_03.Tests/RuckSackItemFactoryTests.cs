namespace Day_03.Tests;

public class RuckSackItemFactoryTests
{
    private readonly RuckSackItemFactory _sut;

    public RuckSackItemFactoryTests()
    {
        _sut = new RuckSackItemFactory();
    }

    [Theory]
    [InlineData('a', 1)]
    [InlineData('z', 26)]
    [InlineData('A', 27)]
    [InlineData('Z', 52)]
    public void CreateRuckSackItem_ShouldCreateExpectedRuckSackItem(char id, int priority)
    {
        _sut.CreateRuckSackItem(id).Priority.Should().Be(priority);
    }
}