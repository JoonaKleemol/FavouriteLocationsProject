using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGeneraattori
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            int rndNumber = rnd.Next(1, 34);

            string line15 = ReadLine(@"C:\mydir\rndSijainnit.txt", rndNumber);

            Console.WriteLine(line15); 

            string ReadLine(string FilePath, int LineNumber)
            {
                string result = "";
                try
                {
                    if (File.Exists(FilePath))
                    {
                        using (StreamReader _StreamReader = new StreamReader(FilePath))
                        {
                            for (int a = 0; a < LineNumber; a++)
                            {
                                result = _StreamReader.ReadLine();
                            }
                        }
                    }
                }
                catch { }
                return result;
            }
        }
    }
}
