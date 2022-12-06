namespace Library.Day01;

public interface ICalorieCounter
{
    int GetMaxCalorieCount(List<List<int>> calorieCounts);
    int GetTop3CalorieCounts(List<List<int>> calorieCounts);
}

public class CalorieCounter : ICalorieCounter
{
    public int GetMaxCalorieCount(List<List<int>> calorieCounts)
    {
        return calorieCounts.Select(calorieCount => calorieCount.Sum()).Max();
    }

    public int GetTop3CalorieCounts(List<List<int>> calorieCounts)
    {
        return calorieCounts.Select(calorieCount => calorieCount.Sum()).OrderDescending().Take(3).Sum();
    }
}