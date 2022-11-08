using BenchmarkDotNet.Running;
using Benchmarks;

BenchmarkRunner.Run(typeof(MediatorsBenchmarks).Assembly);