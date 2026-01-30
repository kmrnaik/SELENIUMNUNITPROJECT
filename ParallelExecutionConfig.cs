using NUnit.Framework;

// Set number of parallel workers (threads)
[assembly: LevelOfParallelism(4)]

// Enable parallel execution for test fixtures
[assembly: Parallelizable(ParallelScope.Fixtures)]