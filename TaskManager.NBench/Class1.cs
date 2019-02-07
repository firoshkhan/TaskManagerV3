using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLib;
using NBench;
using NBench.Util;
using Test;

namespace TaskManager.NBenchTest
{
    public class NBenchTest
    {
        private Counter _counter;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            //  _counter = context.GetCounter("TestCounter");
        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
            NumberOfIterations = 3, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 6000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 10000000.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.AllGc, MustBe.ExactlyEqualTo, 0.0d)]
        public void Benchmark(BenchmarkContext context)
        {
            // _counter.Increment();
            //  var bytes = new byte[0];
            TaskManager.BusinessLib.TaskBL obj = new TaskBL();
            int Count = obj.GetAllTasks().Count;

        }

       
        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
           NumberOfIterations = 3, RunMode = RunMode.Throughput,
           RunTimeMilliseconds = 6000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 10000000.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.AllGc, MustBe.ExactlyEqualTo, 0.0d)]
        public void Benchmark2(BenchmarkContext context)
        {
            // _counter.Increment();
            //  var bytes = new byte[0];
            TaskManager.BusinessLib.UserBL obj = new UserBL();
            int Count = obj.GetAllUsers().Count;

        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
                    NumberOfIterations = 3, RunMode = RunMode.Throughput,
                    RunTimeMilliseconds = 60000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 10000000.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.AllGc, MustBe.ExactlyEqualTo, 0.0d)]
        public void BenchmarkUnitTestProjects(BenchmarkContext context)
        {
            // _counter.Increment();
            //  var bytes = new byte[0];
            TaskManager.BusinessLib.ProjectBL obj = new ProjectBL();

            int Count = obj.GetAllProjects().Count;

        }

        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing

        }

    }
}
