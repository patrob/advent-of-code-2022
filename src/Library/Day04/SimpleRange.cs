namespace Library.Day04;

public class SimpleRange
{
    public static SimpleRange Parse(string input)
    {
        var split = input.Split('-');
        return new SimpleRange { Lower = int.Parse(split[0]), Upper = int.Parse(split[1]) };
    }

    public int Lower { get; set; }
    public int Upper { get; set; }

    public int[] ToArray()
    {
        return Enumerable.Range(Lower, Upper - Lower + 1).ToArray();
    }

    public override string ToString()
    {
        return $"[{Lower}, {Upper}]";
    }

    public bool IsWithinRange(SimpleRange outerRange)
    {
        return outerRange.Lower <= Lower && outerRange.Upper >= Upper;
    }
}