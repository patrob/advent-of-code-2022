using System.Text;

namespace Library.Day10;

public class Processor
{
    public int Cycles => RegisterValues.Count;
    public List<int> RegisterValues { get; } = new() {1};

    public void Execute(Command command)
    {
        var currentX = RegisterValues.Last();
        switch (command)
        {
            case AddCommand add:
                RegisterValues.Add(currentX);
                RegisterValues.Add(currentX + add.AddValue);
                break;
            case NoOpCommand noOp:
                RegisterValues.Add(currentX);
                break;
        }
    }

    public int GetSignalStrength(int cycle)
    {
        return RegisterValues[cycle - 1] * cycle;
    }

    public int GetSignalStrengths()
    {
        return Enumerable.Range(0, 6)
            .Select(x => GetSignalStrength(20 + x * 40))
            .Aggregate(0, (acc, current) => acc + current);
    }

    public string GetPixelToPrint(int x)
    {
        var spriteCenter = RegisterValues[x];
        var pixelToPrint = x % 40;
        return GetPixelToPrint(pixelToPrint, spriteCenter);
    }

    public string GetPixelToPrint(int cycle, int spriteX)
    {
        return cycle >= spriteX - 1 && cycle <= spriteX + 1 ? "#" : ".";
    }

    public string[] GetPixelsToPrint()
    {
        var result = new List<string>();
        var sb = new StringBuilder();
        for (var i = 0; i < RegisterValues.Count; i++)
        {
            sb.Append(GetPixelToPrint(i));
            
            if ((i + 1) % 40 != 0 || i == 0) continue;
            
            result.Add(sb.ToString());
            sb.Clear();
        }

        return result.ToArray();
    }
}