using System;
using System.Threading.Tasks;

namespace Demo
{
    public class HowToHandleAggregatedException : IDemoable
    {
        public void Demo() => DemoAsync().Wait();

        async Task DemoAsync()
        {
            var firstTask = ThrowsAggregatedException();

            Task errorHandler = firstTask.ContinueWith(previous => Handle(previous.Exception), TaskContinuationOptions.OnlyOnFaulted);

            Task processingResults = firstTask.ContinueWith(ProcessResult, TaskContinuationOptions.OnlyOnRanToCompletion);

            await Task.WhenAny(errorHandler, processingResults);
        }

        private static void Handle(AggregateException ex)
        {
            foreach (var exception in ex.Flatten().InnerExceptions)
            {
                Console.WriteLine(exception.Message);
            }
        }

        Task ThrowsAggregatedException()
        {
            return Task.Factory.StartNew(
                    () =>
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Task.Factory.StartNew(input => { throw new Exception($"{input} task has failed"); }, i, TaskCreationOptions.AttachedToParent);
                        }
                    });
        }

        private void ProcessResult(Task obj)
        {
        }
    }
}