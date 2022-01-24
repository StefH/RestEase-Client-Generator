using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302.Models
{
    public class Customer
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public Address[] Address { get; set; }

        /// <summary>
        /// Status2
        /// </summary>
        public string Status { get; set; }
    }
}