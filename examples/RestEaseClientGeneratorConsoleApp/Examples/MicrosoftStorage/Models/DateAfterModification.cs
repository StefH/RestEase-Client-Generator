using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Object to define the number of days after object last modification Or last access. Properties daysAfterModificationGreaterThan and daysAfterLastAccessTimeGreaterThan are mutually exclusive.
    /// </summary>
    public class DateAfterModification
    {
        /// <summary>
        /// Value indicating the age in days after last modification
        /// </summary>
        public double DaysAfterModificationGreaterThan { get; set; }

        /// <summary>
        /// Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy
        /// </summary>
        public double DaysAfterLastAccessTimeGreaterThan { get; set; }
    }
}