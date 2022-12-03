// See https://aka.ms/new-console-template for more information

using Day_02;
using Library;

const string path = "./ProblemData.txt";
var inputReader = new InputReader();
var roundParser = new RoundParser(new PlayOptionParser(), new PointTallier());
var total = inputReader.GetAllLinesOfText(path)
    .Select(x => roundParser.GetRoundScore(x))
    .Aggregate((c,n) => c+n);
Console.WriteLine($"Total points: {total}");

var predictableRoundParser = new PredictableRoundParser(new PlayOptionParser(), new PointTallier());

var total2 = inputReader.GetAllLinesOfText(path)
    .Select(x => predictableRoundParser.GetRoundScore(x))
    .Aggregate((c,n) => c+n);
Console.WriteLine($"Total predicted points: {total2}");