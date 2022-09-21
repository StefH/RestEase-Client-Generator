using System;
using System.Collections.Generic;

namespace ConsoleAppV2.Examples.Replicate.Models
{
    public class ValidationError
    {
        public object[] Loc { get; set; }

        public string Msg { get; set; }

        public string Type { get; set; }
    }
}