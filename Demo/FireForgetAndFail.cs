using System;
using System.Threading.Tasks;

namespace Demo
{
    public class FireForgetAndFail
    {
        public void Demo()
        {
            Task.Run(() => Fail()); // the result is not stored or checked anywhere!!!
        }

        private void Fail()
        {
            throw new Exception("please help me");
        }
    }
}