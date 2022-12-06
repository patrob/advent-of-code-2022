using AoCHelper;

Solver.SolveLast(opt =>
{
    opt.ShowConstructorElapsedTime = true;
    opt.ShowTotalElapsedTimePerDay = true;
    opt.ShowOverallResults = false;
});

// ----- See all days -----
// await Solver.SolveAll(opt =>
// {
//     opt.ShowConstructorElapsedTime = true;
//     opt.ShowTotalElapsedTimePerDay = true;
// });