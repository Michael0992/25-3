using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Personalverwaltung
{
    internal class Mitabeiter
    {
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public int? Urlaubstage { get; set; }
        public List<DateTime>? Krankheitstage { get; set; }

        public static List<Mitabeiter> MitabeiterListe = new List<Mitabeiter>();


        private Mitabeiter() { }

        [JsonConstructor]
        public Mitabeiter(string? vorname, string? nachname, int? urlaubstage, List<DateTime>? krankheitstage)
        {
            Vorname = vorname;
            Nachname = nachname;
            Urlaubstage = urlaubstage;
            Krankheitstage = krankheitstage;
        }

        public static void AddMitarbeiter(string? vorname, string? nachname, int? urlaubstage, List<DateTime> krankheitstage)
        {
            if (string.IsNullOrEmpty(vorname) || string.IsNullOrEmpty(nachname) || urlaubstage == null)
            {
                Console.WriteLine("Mittarbeiter konnte nicht erstellt werden!");
                return;
            }

            Mitabeiter mitabeiter = new Mitabeiter();
            mitabeiter.Vorname = vorname;
            mitabeiter.Nachname = nachname;
            mitabeiter.Urlaubstage = urlaubstage;
            mitabeiter.Krankheitstage = krankheitstage;
            MitabeiterListe.Add(mitabeiter);
        }


        public static void LoadFromJSON(string path)
        {
            MitabeiterListe = JsonSerializer.Deserialize<List<Mitabeiter>>(File.ReadAllText(path)) ?? new List<Mitabeiter>();
        }

        public static void SaveToJSON(string path)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(MitabeiterListe, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
