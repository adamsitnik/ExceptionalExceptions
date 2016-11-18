using System;
using System.Threading.Tasks;

namespace Demo
{
    public class FireForgetAndFail : IDemoable
    {
        public void Demo()
        {
            Task.Run(() => Fail()); // the result is not stored or checked anywhere!!!

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Fail()
        {
            throw new Exception("please help me");
        }
    }
}