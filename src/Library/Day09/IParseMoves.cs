using System.Collections;

namespace Library.Day09;

public interface IParseMoves
{
    List<Move> Parse(List<string> input);
}

public class ParseMoves : IParseMoves
{
    // 100 x 100 grid should be good enough?
    public readonly List<List<Stack<char>>> Grid;
    private const int Max = 10;
    // private const int Max = 100;
    private const int Half = 5;
    // private const int Half = 50;

    public ParseMoves()
    {
        Grid = Enumerable.Range(0, Max).Select(x => new Stack<char>[Max].Select(_ => new Stack<char>()).ToList()).ToList();
        Grid.ToList().ForEach(row => row.ToList().ForEach(column => column.Push(Constants.Unvisited)));
        Grid[Half][Half].Push(Constants.Start);
    }

    public void AddRow(bool end)
    {
        var getStack = () =>
        {
            var stack = new Stack<char>();
            stack.Push(Constants.Unvisited);
            return stack;
        };
        var row = Enumerable.Range(0, Grid[0].Count).Select(_ => getStack()).ToList();
        if (end)  Grid.Add(row);
        else Grid.Insert(0, row);
    }

    public void AddCol(bool end)
    {
        var getStack = () =>
        {
            var stack = new Stack<char>();
            stack.Push(Constants.Unvisited);
            return stack;
        };
        if (end)  Grid.ForEach(row => row.Add(getStack()));
        else Grid.ForEach(row => row.Insert(0, getStack()));
    }
    
    public List<Move> Parse(List<string> input)
    {
        return input
            .Select(x => x.Split(' '))
            .Select(x => new Move((Direction)x[0][0], int.Parse(x[1])))
            .ToList();
    }

    public int Distance((int, int) head, (int, int) tail)
    {
        return (int)Math.Sqrt(Math.Pow(head.Item1 - tail.Item1, 2) + Math.Pow(head.Item2 - tail.Item2, 2));
    }

    public void MoveMultiple(List<Move> moves)
    {
        var headAndTail = new List<(int, int)> { (Half, Half), (Half, Half) };
        moves.ForEach(move =>
        {
            headAndTail = Move(headAndTail, move);
        });
    }

    public void PrintGrid()
    {
        Grid.ForEach(row =>
        {
            row.ForEach(col => Console.Write(col.Peek()));
            Console.WriteLine();
        });
    }

    public void MoveLongRope(List<Move> moves)
    {
        var knots = Enumerable.Range(0, 10).Select(_ => (Half, Half)).ToList();
        moves.ForEach(move =>
        {
            knots = Move(knots, move, false);
        });
    }

    public int PlusOrMinus1(int a, int b)
    {
        if (a - b == 0) return 0;
        return a - b > 0 ? 1 : -1;
    }

    public List<(int, int)> Move(List<(int, int)> knots, Move move, bool isPart1 = true)
    {
        var result = knots.ToList();
        for (var spaces = 0; spaces < move.Spaces; spaces++)
        {
            for (var i = 0; i < result.Count - 1; i++)
            {
                var headAndTail = (result[i], result[i + 1]);
                var isVisiting = i == result.Count - 2;
                if (i == 0)
                {
                    headAndTail.Item1 = GetNextHead(headAndTail.Item1, move.Direction);
                }

                if (Distance(headAndTail.Item1, headAndTail.Item2) >= 2)
                {
                    headAndTail.Item2 = GetNextTail((isVisiting && !isPart1) || isPart1, headAndTail.Item1, headAndTail.Item2);
                }
                
                result[i] = headAndTail.Item1;
                result[i + 1] = headAndTail.Item2;
            }
        }

        return result;
    }

    private (int, int) GetNextHead((int, int) head, Direction direction)
    {
        var newHead = direction switch
        {
            Direction.Up => (head.Item1 + 1, head.Item2),
            Direction.Down => (head.Item1 - 1, head.Item2),
            Direction.Left => (head.Item1, head.Item2 - 1),
            Direction.Right => (head.Item1, head.Item2 + 1),
            _ => throw new ArgumentOutOfRangeException()
        };
        return GetFixedLocation(newHead);
    }

    private ((int, int), (int,int)) GetNextHeadAndTail(Direction direction, bool isTailVisiting, (int, int) newHead, (int, int) newTail)
    {
        newHead = GetNextHead(newHead, direction);

        var distance = Distance(newHead, newTail);

        if (distance >= 2)
        {
            newTail = GetNextTail(isTailVisiting, newHead, newTail);
        }

        return (newHead, newTail);
    }

    private (int, int) GetNextTail(bool isTailVisiting, (int, int) newHead, (int, int) newTail)
    {
        var rowDist = PlusOrMinus1(newHead.Item1, newTail.Item1);
        var colDist = PlusOrMinus1(newHead.Item2, newTail.Item2);
        newTail = (newTail.Item1 + rowDist, newTail.Item2 + colDist);
        newTail = GetFixedLocation(newTail);
        if (newTail.Item1 == 0)
        {
            
        }
        if (isTailVisiting && Grid[newTail.Item1][newTail.Item2].Peek() != Constants.Visited)
        {
            Grid[newTail.Item1][newTail.Item2].Push(Constants.Visited);
        }

        return newTail;
    }

    private (int, int) GetFixedLocation((int, int) location)
    {
        if (location.Item1 < 0)
        {
            AddRow(false);
            location.Item1 = 0;
        }

        if (location.Item1 > Grid.Count - 1)
        {
            AddRow(true);
        }

        if (location.Item2 < 0)
        {
            AddCol(false);
            location.Item2 = 0;
        }

        if (location.Item2 > Grid[0].Count - 1)
        {
            AddCol(true);
        }

        return location;
    }

    public int GetVisitedCount()
    {
        return Grid.SelectMany(g => g).Count(g => g.Peek() == Constants.Visited) + 1;
    }
}