using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkhaus
{
    internal class Auto
    {
        public string Kennzeichen { get; set; }
        public string Farbe { get; set; }
        public string Marke { get; set; }

        public Auto(string kennzeichen, string farbe, string marke)
        {
            Kennzeichen = kennzeichen;
            Farbe = farbe;
            Marke = marke;
        }

    }
}
