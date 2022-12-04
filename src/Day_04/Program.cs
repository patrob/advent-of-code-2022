// See https://aka.ms/new-console-template for more information

using Day_04;
using Library;

const string examplePath = "./ExampleData.txt";
const string problemPath = "./ProblemData.txt";
const bool isExample = false;

const string path = isExample ? examplePath : problemPath;

var sum = new InputReader()
    .GetAllLinesOfText(path)
    .Select(x => x.Split(',').Select(SimpleRange.Parse).ToArray())
    .Select(x => x[0].IsWithinRange(x[1]) || x[1].IsWithinRange(x[0]) ? 1 : 0)
    .Sum();

Console.WriteLine($"{sum} Need Attention...");

var sum2 = new InputReader()
    .GetAllLinesOfText(path)
    .Select(x => x.Split(',').Select(SimpleRange.Parse).ToArray())
    .Select(x => x[0].ToArray().Intersect(x[1].ToArray()).Any() ? 1 : 0)
    .Sum();
    
Console.WriteLine($"{sum2} Need Attention, too!");