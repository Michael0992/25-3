// Erstelle ein einfaches Personal Verwaltungsprogramm
// Dieses soll uns erlauben eine Kartei über einen oder mehrere Mittarbeiter zu erstellen und auszugeben und auch einzelne Mittarbeiter zu  wieder entfernen
// mit folgenden Informationen: Name - Nachname - Urlaubstage - Liste(mit Datum von Krankheitstagen)(die Liste darf leer sein)
// Sorge dafür das die Personen gespeichert werden in einer json-datei (Recherchiere selbständig was Serialisierung bedeutet)
// und auch wieder abgerufen werden können automatisch beim start des Programms

using System.Text.Json;

namespace Personalverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dateiname = "mitarbeiter.json";
            if (File.Exists(dateiname))
            {
                Mitabeiter.LoadFromJSON(dateiname);
            }

            while (true)
            {

                UI.ShowMenu("Hauptmenü", UI.MainMenuPoints);
                switch (UI.Input(3))
                {
                    case 1:
                        UI.AddMitarbeiter();
                        Mitabeiter.SaveToJSON(dateiname);
                        break;
                    case 2:
                        UI.ShowMitarbeiter();
                        break;
                    case 3:
                        UI.RemoveMitarbeiter();
                        Mitabeiter.SaveToJSON(dateiname);
                        break;
                }
            }
               

        }
    }
}
