using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = ManualConfig.CreateEmpty()
                .With(Job.Dry.With(Platform.X64).With(Mode.Throughput).WithWarmupCount(1).WithTargetCount(10))
                .With(DefaultConfig.Instance.GetLoggers().ToArray())
                .With(PropertyColumn.Method, PropertyColumn.Runtime, PropertyColumn.Platform, PropertyColumn.Jit, StatisticColumn.Median, StatisticColumn.StdDev, StatisticColumn.Max, StatisticColumn.Min, BaselineScaledColumn.Scaled)
                .With(MarkdownExporter.Default)
                .With(HtmlExporter.Default)
                // uncomment to get image representation
                .With(CsvMeasurementsExporter.Default)
                .With(RPlotExporter.Default)
                // uncomment to sort the results 
                .With(new SlowestToFastestOrderProviderWithoutParameters())
                .RemoveBenchmarkFiles();

            BenchmarkRunner.Run<AlwaysFailing>(config);
        }

        private class SlowestToFastestOrderProviderWithoutParameters : IOrderProvider
        {
            public IEnumerable<Benchmark> GetExecutionOrder(Benchmark[] benchmarks) => benchmarks;

            public IEnumerable<Benchmark> GetSummaryOrder(Benchmark[] benchmarks, Summary summary) =>
                from benchmark in benchmarks
                orderby summary[benchmark]?.ResultStatistics?.Median descending
                select benchmark;

            public string GetGroupKey(Benchmark benchmark, Summary summary) => null;
        }

    }
}
