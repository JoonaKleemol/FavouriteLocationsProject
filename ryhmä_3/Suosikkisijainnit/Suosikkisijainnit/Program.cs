using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Suosikkisijainnit
{
    class Program
    {

        public static void Main()
        {

            
            // Specify the directory you want to manipulate.
            string OmaDatabase = @"c:\MyDir";

            try
            {
                // Determine whether the directory exists.
                //if (Directory.Exists(OmaDatabase))
                //{
                //    Console.WriteLine("Polku on jo käytössä. ");
                //    Delete the directory.
                //    di.Delete();
                //    Console.WriteLine("Kansio poistettiin.");

                //}

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(OmaDatabase);
                Console.WriteLine("Kansio, joka sisältää suosikkisijainnit luotiin {0}.", Directory.GetCreationTime(OmaDatabase));


            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            string path = @"c:\MyDir\Suosikkisijannit.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                int SuosikkiSijaintienMaara = 0;
                string newSuosikkiSijaintienMaara;


                //Kysytään monta Sijaintia tiedostoon halutaan lisätä.
                Console.WriteLine("Kuinka monta suosikkisijaintia haluat lisätä?");
                newSuosikkiSijaintienMaara = Console.ReadLine();
                SuosikkiSijaintienMaara = int.Parse(newSuosikkiSijaintienMaara);

                for (int i = 0; i < SuosikkiSijaintienMaara; i++)
                {
                    Console.WriteLine("\nLisää haluamasi sijainti listaan.");
                    sw.WriteLine(Console.ReadLine());
                }
            }

            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                Console.WriteLine("\nNykyiset suosikkisijainnit: ");
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }

            }
        }


    }
}
