// See https://aka.ms/new-console-template for more information

using Day_03;
using Library;

const string path = "./ProblemData.txt";

var inputReader = new InputReader();
var input = inputReader.GetAllLinesOfText(path).ToList();

var itemFactory = new RuckSackItemFactory();
var dupeFinder = new DuplicateItemDetector(itemFactory);
var parser = new CompartmentParser();
var grouper = new RuckSackGrouper();

var totalPriority = input
    .Select(x => parser.ParseCompartments(x))
    .Select(x => dupeFinder.GetDuplicateItem(x))
    .Sum(x => x.Priority);
    
Console.WriteLine($"Total priority: {totalPriority}");

var ruckSacks = input
    .Select(x => parser.ParseCompartments(x))
    .ToList();

var badgePriority = grouper.GroupByCount(ruckSacks, 3)
    .Select(x => dupeFinder.GetDuplicateItemAcrossMultiple(x))
    .Sum(x => x.Priority);

Console.WriteLine($"Total badge priority: {badgePriority}");
