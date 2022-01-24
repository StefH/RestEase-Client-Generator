using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// Blob index tag based filtering for blob objects
    /// </summary>
    public class TagFilter
    {
        /// <summary>
        /// This is the filter tag name, it can have 1 - 128 characters
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This is the comparison operator which is used for object comparison and filtering. Only == (equality operator) is currently supported
        /// </summary>
        public string Op { get; set; }

        /// <summary>
        /// This is the filter tag value field used for tag based filtering, it can have 0 - 256 characters
        /// </summary>
        public string Value { get; set; }
    }
}