using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.wpraml.Models
{
    public class BankGegevens
    {
        public int? Klantnummer { get; set; }

        public string ExcassoIBAN { get; set; }

        public string IncassoIBAN { get; set; }
    }
}
