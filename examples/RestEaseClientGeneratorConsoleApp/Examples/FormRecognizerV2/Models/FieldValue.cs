using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.V2.Models
{
    public class FieldValue
    {
        public Type Type { get; set; }

        public string ValueString { get; set; }

        public DateTime ValueDate { get; set; }

        public DateTime ValueTime { get; set; }

        public string ValuePhoneNumber { get; set; }

        public double ValueNumber { get; set; }

        public int ValueInteger { get; set; }

        public FieldValue[] ValueArray { get; set; }

        public Dictionary<string, FieldValue> ValueObject { get; set; }

        public string Text { get; set; }

        public double[] BoundingBox { get; set; }

        public double Confidence { get; set; }

        public string[] Elements { get; set; }

        public int Page { get; set; }
    }
}
