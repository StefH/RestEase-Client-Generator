using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.wpraml.Models
{
    public class Product
    {
        public DateTime Begindatum { get; set; }

        public string Dekking { get; set; }

        public string Dienstverleningsdocument { get; set; }

        public DateTime? Einddatum { get; set; }

        public string Naam { get; set; }

        public int? Polisnummer { get; set; }

        public string Polisvoorwaardentype { get; set; }

        public string Reglementtype { get; set; }

        public int? Status { get; set; }

        public string Werkgevernaam { get; set; }
    }
}
