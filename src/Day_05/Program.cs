using Library;

const string emptySlot = "[_]";
var inputReader = new InputReader();
var inputLines = inputReader.GetAllLinesOfText().ToList();

void PrintStack(Stack<string> stack)
{
    stack.ToArray().ToList().ForEach(Console.Write);
    Console.WriteLine();
}

var stackLines = inputLines.TakeWhile(x => !string.IsNullOrEmpty(x)).ToList();
var moves = inputLines.Skip(stackLines.Count + 1)
    .Select(x => new { text = x, split = x.Split(' ')})
    .Select(x => new
    {
        Move = int.Parse(x.split[1]),
        From = int.Parse(x.split[3]),
        To = int.Parse(x.split[5]),
        Text = x.text
    })
    .Select(x => new {
        x.Text,
        Move1AtATime = new Action<List<Stack<string>>>(stacks =>
        {
            var from = stacks[x.From - 1];
            var to = stacks[x.To - 1];
            for (var i = 0; i < x.Move; i++)
            {
                var popped = from.Pop();
                to.Push(popped);
            }
        }),
        MoveInSameOrder = new Action<List<Stack<string>>>(stacks =>
        {
            var from = stacks[x.From - 1];
            var to = stacks[x.To - 1];
            var restack = new List<string>();
            for (var i = 0; i < x.Move; i++)
            {
                var popped = from.Pop();
                restack.Add(popped);
            }

            restack.Reverse();

            restack.ForEach(y => to.Push(y));
        })
    })
    .ToList();

var stackCount = stackLines
    .Last()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Count();

var stacks1 = Enumerable.Range(0, stackCount).Select(_ => new Stack<string>()).ToList();
var stacks2 = Enumerable.Range(0, stackCount).Select(_ => new Stack<string>()).ToList();
    
stackLines.RemoveAt(stackLines.Count - 1);
stackLines.Reverse();
var stackInputs = stackLines
    .Select(x => x
        .Replace("    [", $"{emptySlot} [")
        .Replace("]    ", $"] {emptySlot}")
        .Split(' ')
        .ToList())
    .ToList();

stacks1.ForEach(stack =>
{
    var index = stacks1.IndexOf(stack);
    stackInputs.ForEach(items =>
    {
        if (items[index] != emptySlot && !string.IsNullOrEmpty(items[index])) stack.Push(items[index]);
    });
});

stacks2.ForEach(stack =>
{
    var index = stacks2.IndexOf(stack);
    stackInputs.ForEach(items =>
    {
        if (items[index] != emptySlot && !string.IsNullOrEmpty(items[index])) stack.Push(items[index]);
    });
});

moves.ForEach(x =>
{
    x.Move1AtATime(stacks1);
    x.MoveInSameOrder(stacks2);
});

Console.WriteLine("first problem:");

stacks1.ForEach(x =>
{
    if (x.Any()) Console.WriteLine(x.Peek());
    else Console.WriteLine();
});

Console.WriteLine("-----");

Console.WriteLine("second problem:");

stacks2.ForEach(x =>
{
    if (x.Any()) Console.WriteLine(x.Peek());
    else Console.WriteLine();
});