using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.FormRecognizer.Models
{
    public class DataTable
    {
        public int Rows { get; set; }

        public int Columns { get; set; }

        public DataTableCell[] Cells { get; set; }
    }
}
