using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGene

{
    public class Randomi
    {
        
        static Random rnd = new Random();
        static int rndNumber = rnd.Next(1, 34);
   
        string line15 = ReadLine(@"C:\mydir\rndSijainnit.txt", rndNumber);
        static string ReadLine(string FilePath, int LineNumber)
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
#pragma warning disable CS0114
        public void ToString()
#pragma warning restore CS0114 
        {
            Console.WriteLine("Random sijaintsi on: " + line15);
        }   
    }
}

