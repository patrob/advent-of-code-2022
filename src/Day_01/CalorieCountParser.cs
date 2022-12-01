namespace Day_01;

public interface ICalorieCountParser
{
    List<List<int>> ParseCalorieCounts(List<string> input);
}

public class CalorieCountParser : ICalorieCountParser
{
    public List<List<int>> ParseCalorieCounts(List<string> input)
    {
        List<List<int>> result = new();
        List<int> runningList = new();
        input.ForEach(item =>
        {
            if (string.IsNullOrEmpty(item) && runningList.Any())
            {
                result.Add(runningList.ToList());
                runningList.Clear();
            }
            else
            {
                runningList.Add(int.Parse(item));
            }
        });
        if (runningList.Any())
        {
            result.Add(runningList);
        }
        return result;
    }
}