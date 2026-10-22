using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTest
{
    class DiscountLogger : ILogger
    {
        private static DiscountLogger instance = new DiscountLogger();

        public static DiscountLogger Instance
        {
            get { return instance; }
        }

        private DiscountLogger()
        {

        }

        public void Log(string message)
        {
            Console.WriteLine("[Журнал]" + message);
        }
    }
}
