using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.Models
{
    public class DataTableCell
    {
        public int RowIndex { get; set; }

        public int ColumnIndex { get; set; }

        public int RowSpan { get; set; }

        public int ColumnSpan { get; set; }

        public string Text { get; set; }

        public double[] BoundingBox { get; set; }

        public double Confidence { get; set; }

        public string[] Elements { get; set; }

        public bool IsHeader { get; set; }

        public bool IsFooter { get; set; }
    }
}
