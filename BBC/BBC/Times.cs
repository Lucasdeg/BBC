using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC
{
    class Times
    {
        public String GetTimestamp(DateTime value)
        {
            return value.ToString("dd/MM/yyyy>>HH:mm:ss");
        }
        public String PrintTimeStamp()
        {
            string TimeStamp = GetTimestamp(DateTime.Now);
            Console.WriteLine(GetTimestamp(DateTime.Now));
            Console.ReadKey();
            return TimeStamp;
        }
    }
}
