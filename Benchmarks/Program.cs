using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
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
                .With(Job.MediumRun.With(Platform.X64))
                .With(DefaultConfig.Instance.GetLoggers().ToArray())
                .With(DefaultConfig.Instance.GetColumnProviders().ToArray())
                .With(MarkdownExporter.Default)
                .With(HtmlExporter.Default)
                // uncomment to get image representation
                .With(CsvMeasurementsExporter.Default)
                .With(RPlotExporter.Default)
                // uncomment to sort the results 
                .With(new SlowestToFastestOrderProviderWithoutParameters())
                .RemoveBenchmarkFiles();

            BenchmarkRunner.Run<AlwaysFailing>(config);
            BenchmarkRunner.Run<CallstackDepth>(config);
            BenchmarkRunner.Run<CostOfFinally>(config);
            BenchmarkRunner.Run<HavingAThrowInstruction>(config);
            BenchmarkRunner.Run<TailRecursionBenchmarks>(config);
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
