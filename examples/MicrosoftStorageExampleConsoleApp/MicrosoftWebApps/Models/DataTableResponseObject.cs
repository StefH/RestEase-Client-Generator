using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Data Table which defines columns and raw row values
    /// </summary>
    public class DataTableResponseObject
    {
        /// <summary>
        /// Name of the table
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// List of columns with data types
        /// </summary>
        public DataTableResponseColumn[] Columns { get; set; }

        /// <summary>
        /// Raw row values
        /// </summary>
        public string[][] Rows { get; set; }
    }
}