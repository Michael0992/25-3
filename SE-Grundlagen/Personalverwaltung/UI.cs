using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personalverwaltung
{
    internal static class UI
    {
        public static List<string> MainMenuPoints = new List<string>()
        {
            "1. Mitarbeiter anlegen\n",
            "2. Mitarbeiter anzeigen\n",
            "3. Mittarbeiter entfernen\n",
            "\n",
            "Geben Sie Ihre Wahl ein: "
        };


        public static void ShowMenu(string title, List<string> menuPoints)
        {
            Console.Clear();
            Console.WriteLine("\t\t" + title + "\n\n" );

            foreach(var i in menuPoints)
            {
                Console.Write(i);
            }

        }


        public static int Input(int choices)
        {
            while (true)
            {
                var i = Console.ReadLine();
                if (int.TryParse(i, out int input) && (input > 0 && input <= choices))
                {       
                    return input;
                }
                else
                {
                    Console.Write("Ungültige Eingabe! Bitte erneut versuchen: ");
                }
     
            }
                
        }


        public static void AddMitarbeiter()
        {
            Console.Clear();

            Console.WriteLine("Mitarbeiter anlegen\n");
            Console.Write("Vorname: ");
            var vorname = Console.ReadLine();
            Console.Write("Nachname: ");
            var nachname = Console.ReadLine();
            Console.Write("Urlaubstage: ");
            var urlaub = int.TryParse(Console.ReadLine() , out int urlaubstage) ? urlaubstage : (int?)null;
            List<DateTime> krankheitstage = new List<DateTime>();

            Mitabeiter.AddMitarbeiter(vorname, nachname, urlaub, krankheitstage);
        }


        public static void ShowMitarbeiter()
        {
            Console.Clear();
            Console.WriteLine("Mitarbeiter anzeigen\n");
            foreach(var mitabeiter in Mitabeiter.MitabeiterListe)
            {
                Console.WriteLine($"Name: {mitabeiter.Vorname} {mitabeiter.Nachname} - Urlaubstage: {mitabeiter.Urlaubstage} - Krankheitstage: {string.Join(", ", mitabeiter.Krankheitstage ?? new List<DateTime>())} \n");
            }
            Console.WriteLine("\nDrücken Sie eine beliebige Taste um zum Hauptmenü zurückzukehren...");
            Console.ReadKey();
        }


        public static void RemoveMitarbeiter()
        {
            Console.Clear();
            Console.WriteLine("Mitarbeiter entfernen\n");
            if(Mitabeiter.MitabeiterListe.Count == 0)
            {
                Console.WriteLine("Keine Mitarbeiter Vorhanden");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < Mitabeiter.MitabeiterListe.Count; i++)
            {
                var mitabeiter = Mitabeiter.MitabeiterListe[i];
                Console.WriteLine($"{i + 1}. {mitabeiter.Vorname} {mitabeiter.Nachname}");
            }
            Console.Write("\nGeben Sie die Nummer des Mitarbeiters ein, den Sie entfernen möchten: ");
            while (true) {
                var auswahl = int.TryParse(Console.ReadLine(), out int input) ? input : (int?)null;
                if (auswahl == null || auswahl > Mitabeiter.MitabeiterListe.Count || auswahl <= 0)
                {
                    Console.Write("Ungültige Eingabe! Bitte erneut versuchen: ");
                }
                else
                {
                    Mitabeiter.MitabeiterListe.RemoveAt(auswahl.Value - 1);
                    Console.WriteLine("Mitarbeiter erfolgreich entfernt. Drücken Sie eine beliebige Taste um zum Hauptmenü zurückzukehren...");
                    Console.ReadKey();
                    break;
                }
            
            }
        }

    }   
}

