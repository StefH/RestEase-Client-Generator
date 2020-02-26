using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.wpraml.Models
{
    public class Adres
    {
        public long Huisnummer { get; set; }

        public string Huisnummertoevoeging { get; set; }

        public int Landcode { get; set; }

        public string Postcode { get; set; }

        public string Straat { get; set; }

        public string Straatbuitenland { get; set; }

        public string Woonplaats { get; set; }

        public string Woonplaatsbuitenland { get; set; }
    }
}
