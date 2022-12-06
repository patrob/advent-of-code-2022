// See https://aka.ms/new-console-template for more information

using Day_06;
using Library;

var inputReader = new InputReader();
var solver = new Day06Solver(inputReader);
var solution = solver.Solve();
Console.WriteLine(solution);