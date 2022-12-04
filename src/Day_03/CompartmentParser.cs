namespace Day_03;

public interface ICompartmentParser
{
    (string, string) ParseCompartments(string input);
}

public class CompartmentParser : ICompartmentParser
{
    public (string, string) ParseCompartments(string input)
    {
        var compartment1 = input[..(input.Length / 2)];
        var compartment2 = input[compartment1.Length..];
        return (compartment1, compartment2);
    }
}