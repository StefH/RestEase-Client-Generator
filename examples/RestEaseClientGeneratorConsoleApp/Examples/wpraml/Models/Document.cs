using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.wpraml.Models
{
    public class Document
    {
        public DateTime Aanmaakdatum { get; set; }

        public DateTime Datumpoststuk { get; set; }

        public string Documenttype { get; set; }

        public int Jaar { get; set; }

        public int Maand { get; set; }

        public string Naam { get; set; }

        public int Placetdocumentnummer { get; set; }
    }
}
