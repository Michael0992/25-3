namespace Parkhaus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Aufgabe
            //Programmiere eine Klasse Auto, diese Klasse soll uns ermöglichen verschiedene Autos zu instanzieren
            //Die Klasse soll folgende Felder haben Farbe, Marke und Kennzeichnen
            //Im Anschluss soll ein Algorytmus geschrieben werden der es uns erlaubt autos zu erstellen und diese in ein Liste
            //abzuspeichern namens Parkhaus. Diese Liste soll nach dem erstellen des Autos in der Konsole ausgegeben werden.

            List<Auto> parkhaus = new List<Auto>();

            while (true)
            {
                Console.WriteLine("Welche Farbe hat das Auto");
                var farbe = Console.ReadLine();
                Console.WriteLine("Welche Marke hat das Auto");
                var marke = Console.ReadLine();
                Console.WriteLine("Welches Kennzeichen hat das Auto");
                var kennzeichen = Console.ReadLine();

                var auto = new Auto(kennzeichen ?? "", farbe ?? "", marke ?? "");

                parkhaus.Add(auto);

                Console.WriteLine("Soll ein weiteres Auto erstellt werden? ");
                var antwort = Console.ReadLine();
                if (antwort?.ToLower() != "ja")
                {
                    break;
                }
            }

            Console.WriteLine("Im Parkhaus befinden sich folgende Autos:");
            foreach (var auto in parkhaus)
            {
                Console.WriteLine($"Marke: {auto.Marke}, Farbe: {auto.Farbe}, Kennzeichen: {auto.Kennzeichen}");

            }
            Console.WriteLine("Nuutze irgendeine Pipline");
            Console.ReadKey();


        }
    }
}
