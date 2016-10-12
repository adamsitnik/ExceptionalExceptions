using System;
using System.Threading.Tasks;
// ReSharper disable All

namespace Demo
{
    public class AggregateExceptionSample
    {
        public void Demo()
        {
            try
            {
                Task.Factory.StartNew(
                    () =>
                    {
                        Task.Factory.StartNew(() => { throw new Exception("first task has failed"); }, TaskCreationOptions.AttachedToParent);
                        Task.Factory.StartNew(() => { throw new Exception("second task has failed"); }, TaskCreationOptions.AttachedToParent);
                        Task.Factory.StartNew(() => { throw new Exception("third task has failed"); }, TaskCreationOptions.AttachedToParent);
                    }).Wait();
            }
            catch (AggregateException aggregateException)
            {
                foreach (Exception exception in aggregateException.InnerExceptions)
                {
                    Handle(exception);
                }
            }
        }

        private void Handle(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}