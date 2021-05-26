using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusinessLayer.Exceptions
{
    public class ExceptionLogging : Exception
    {
        //public ExceptionLogging(string logMessage, TextWriter w, string location)
        //{
        //    w.WriteLine("\r\nLog Entry : ");
        //    w.WriteLine($"During: {DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
        //    w.WriteLine($"Location : {location}");
        //    w.WriteLine("  :");
        //    w.WriteLine($" Message :{logMessage}");
        //    w.WriteLine("-------------------------------");
        //}

        public static void WriteLog(Exception ex)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("\r\nLog Entry : ");
                writer.WriteLine($"During: {DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                writer.WriteLine($"Location : {ex.StackTrace}");
                writer.WriteLine("  :");
                writer.WriteLine($" Message :{ex.Message}");
                writer.WriteLine("--------------------------------");
            }
        }

        public ExceptionLogging(string message) : base(message)
        {
        }
    }
}
