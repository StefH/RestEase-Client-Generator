using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302.Models
{
    public class Pet
    {
        public long Id { get; set; }

        public long? Optional { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public string[] PhotoUrls { get; set; }

        public Tag[] Tags { get; set; }

        /// <summary>
        /// pet status in the store
        /// </summary>
        public string Status { get; set; }
    }
}