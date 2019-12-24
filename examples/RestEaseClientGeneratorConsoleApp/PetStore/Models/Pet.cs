using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.PetStore.Models
{
    public class Pet
    {
        public long Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> PhotoUrls { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public string Status { get; set; }
    }
}
