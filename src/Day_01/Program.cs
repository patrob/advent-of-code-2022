
using Day_01;
using Microsoft.Extensions.DependencyInjection;

const string path = "./ProblemData.txt";
var serviceCollection = new ServiceCollection();
serviceCollection.AddTransient<IInputReader, InputReader>();
serviceCollection.AddTransient<ICalorieCounter, CalorieCounter>();
serviceCollection.AddTransient<ICalorieCountParser, CalorieCountParser>();
var provider = serviceCollection.BuildServiceProvider();

var runner = new Part1Runner(provider);
runner.Run(path);