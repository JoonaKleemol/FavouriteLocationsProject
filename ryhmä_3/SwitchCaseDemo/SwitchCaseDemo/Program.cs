using RandomGene;
using Suosikkisijainnit;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchCaseDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // TÄÄ LUO RANDOM GENERAATTORI LISTAN 
            StreamWriter writer = File.CreateText(@"C:\mydir\rndSijainnit.txt");
            writer.WriteLine("Turenki\nHyvinkää\nVihti\nNummela\nRajamäki\nNurmijärvi\nRiihimäki\nJanakkala\nHämeenlinna\nRovaniemi\nOulu\nPori\nLappeenranta\nVammala\nKarkkila\nTurku\nHelsinki\nTanttala\nLeppäkoski\nJokimaa\nHeinäjoki\nSeinäjoki\nIvalo\nUtsjoki⁮\nJoensuu\nParola\nToijala\nLempäälä\nRyttylä\nHanko\nTammisaari\nMäntsälä\nKotka\nHauho");
            writer.Close();
            // TÄÄ LUO RANDOM GENERAATTORI LISTAN 

/*--------------------------------------------------------------------------------------------------------------------*/

            Start:
            // SETUP
            Randomi rand = new Randomi();
            Suosikkisijanti rand2 = new Suosikkisijanti();

            int valinta = 0;
            string newValinta;
            // SETUP

/*--------------------------------------------------------------------------------------------------------------------*/

            try
            {
                // TOIMINNAN VALINTA
                Console.WriteLine("Valitse Toiminto\n\n[1]. Random generoitu sijanti\n[2]. Suosikkisijanti\n[3]. Tyhjennä Suosikkisijainnit\n[4]. Exit from main menu");
                Console.Write("\nToiminto: ");
                newValinta = Console.ReadLine();
                valinta = int.Parse(newValinta);
                Console.Write("\n");
                // TOIMINNAN VALINTA

/*--------------------------------------------------------------------------------------------------------------------*/

                // MENU VALINNAT
                // -Näitä voi tehdä lisää.
                switch (valinta)
                {
                    case 1: rand.ToString(); break;         // break is mandatory; no fall-through
                    case 2: rand2.Suosikki(); break;
                    case 3: File.WriteAllText(@"c:\MyDir\Suosikkisijannit.txt", String.Empty); break; // Tyhejentää suosikkisijannit tiedoston
                    case 4: goto End; // Poistu Menusta
                    default: Console.WriteLine("Sopimaton valinta"); break;
                }
            }
                // MENU VALINNAT

/*--------------------------------------------------------------------------------------------------------------------*/

            // VIRHE ILMOITUS
            catch { Console.WriteLine("Sopimaton valinta"); }
            // VIRHE ILMOITUS 
            Console.WriteLine("\nPaina mitä vain näppäointä tyhjentääksesi ruudun");
            Console.ReadKey();
            Console.Clear();
            goto Start; // PALAA ALKUUN

            End: Console.WriteLine("Poistutaan ohjelmasta");

        }
    }
}
