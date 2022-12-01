using AutoFixture;

namespace TestingLibrary;

public class BaseTest
{
    protected Fixture Fixture { get; set; } = new();
}