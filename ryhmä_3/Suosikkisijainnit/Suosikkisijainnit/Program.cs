﻿using System;
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

                try
                {
                    //Kysytään monta Sijaintia tiedostoon halutaan lisätä.
                    Console.WriteLine("Kuinka monta suosikkisijaintia haluat lisätä?");
                    newSuosikkiSijaintienMaara = Console.ReadLine();
                    SuosikkiSijaintienMaara = int.Parse(newSuosikkiSijaintienMaara);
                }

                catch (Exception e) { Console.WriteLine("Kirjain ei ole numero senkin idiootti"); }

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

            string uusiSana;
            string vanhaSana;
            try
            {
                Console.WriteLine("Minkä sijainnin haluat poistaa? ");
                vanhaSana = Console.ReadLine();
            }
            catch { return; }

            try
            {
                Console.WriteLine("Kirjoita uusi suosikkisijainti: ");
                uusiSana = Console.ReadLine();
            }
            catch { return; }

            try
            {
                string text = File.ReadAllText(@"c:\MyDir\Suosikkisijannit.txt");
                text = text.Replace(vanhaSana, uusiSana);
                File.WriteAllText(@"c:\MyDir\Suosikkisijannit.txt", text);

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
            catch { Console.WriteLine("Et poistanut Sijainteja"); }
        }
    }
}
