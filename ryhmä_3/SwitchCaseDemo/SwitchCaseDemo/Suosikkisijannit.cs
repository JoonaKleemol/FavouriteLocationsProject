using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using SwitchCaseDemo;

namespace Suosikkisijainnit
{
    class Suosikkisijanti
    {

        public void Suosikki()
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

            Program ohjelma = new Program();
            
            int valinta = 0;
            string newValinta;
           
            Start:

            try
            {
               
                Console.WriteLine("Valitse Toiminto\n\n[1]. Suosikkisijaintien lisäys\n[2]. Suosikkisijannit\n[3]. Poista Suosikkisijainteja\n[4]. Tyhjennä Suosikkilista\n[5]. Tyhjennä ikkuna\n[6]. Exit to main menu");
                Console.Write("\nToiminto: ");
                newValinta = Console.ReadLine();
                valinta = int.Parse(newValinta);
                Console.Write("\n");


                switch (valinta)
                {
                    case 1: SuosikkisijantienLisäys(); break;
                    case 2: SuosikkisijantiLista(); break;
                    case 3: SuosikkiSijainninPoisto(); break;
                    case 4: File.WriteAllText(@"c:\MyDir\Suosikkisijannit.txt", String.Empty); break; // Tyhejentää suosikkisijannit tiedoston
                    case 5: Console.WriteLine("\nTyhjennetään ikkuna. Paina mitä vain näppäintä.");
                            Console.ReadKey();
                            Console.Clear(); break;
                    case 6: goto Finish; 
                    default: Console.WriteLine("Sopimaton valinta"); break;                   
                }
                
            }

            catch { Console.WriteLine("Sopimaton valinta"); }
            goto Start;
            
            Finish:;
            Console.WriteLine("Palataan päävalikkoon");

        }
            
/*--------------------------------------------------------------------------------------------------------------------*/

            public void SuosikkisijantienLisäys()
            {


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

                    catch (Exception) { Console.WriteLine("Kirjain ei ole numero senkin idiootti"); }

                    for (int i = 0; i < SuosikkiSijaintienMaara; i++)
                    {
                        Console.WriteLine("\nLisää haluamasi sijainti listaan.");
                        sw.WriteLine(Console.ReadLine());
                    }               
            }
        }

        /*--------------------------------------------------------------------------------------------------------------------*/

        public void SuosikkisijantiLista()
        {
            string path = @"c:\MyDir\Suosikkisijannit.txt";

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

/*--------------------------------------------------------------------------------------------------------------------*/

        public void SuosikkiSijainninPoisto()
        {
            string path = @"c:\MyDir\Suosikkisijannit.txt";
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

