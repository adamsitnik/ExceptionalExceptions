using System;
using System.Threading.Tasks;

namespace Demo
{
    public class AsyncAwaitAggregatedException : IDemoable
    {
        public void Demo() => DemoAsync().Wait();

        private async Task DemoAsync()
        {
            try
            {
                await ThrowsAggregatedException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // "One or more errors occurred. (first task has failed)"
            }
        }

        private Task ThrowsAggregatedException()
        {
            return Task.Factory.StartNew(
                    () =>
                    {
                        Task.Factory.StartNew(() => { throw new Exception("first task has failed"); }, TaskCreationOptions.AttachedToParent);
                        Task.Factory.StartNew(() => { throw new Exception("second task has failed"); }, TaskCreationOptions.AttachedToParent);
                        Task.Factory.StartNew(() => { throw new Exception("third task has failed"); }, TaskCreationOptions.AttachedToParent);
                    });
        }
    }
}