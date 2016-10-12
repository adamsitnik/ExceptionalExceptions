using System;

namespace Demo
{
    public class ExceptionInFinally
    {
        public void Demo()
        {
            try
            {
                try
                {
                    throw new Exception("first");
                }
                finally
                {
                    throw new Exception("second");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}