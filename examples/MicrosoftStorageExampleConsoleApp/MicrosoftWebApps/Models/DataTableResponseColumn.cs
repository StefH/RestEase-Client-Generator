using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Column definition
    /// </summary>
    public class DataTableResponseColumn
    {
        /// <summary>
        /// Name of the column
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Data type which looks like 'String' or 'Int32'.
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Column Type
        /// </summary>
        public string ColumnType { get; set; }
    }
}