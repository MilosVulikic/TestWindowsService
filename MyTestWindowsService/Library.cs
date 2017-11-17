using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyTestWindowsService
{
    public class Library
    {
        public static void WriteErrorLog(Exception exception)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString().Trim() + ";" + exception.Message.ToString().Trim());
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {
            }


        }

        public static void WriteErrorLog(string Message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString().Trim() + ";" + Message);                
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {
            }


        }


        public static int ProcessNumber()
        {
            Random random = new Random();
            return random.Next(10000, 20000);
        }

    }
}
