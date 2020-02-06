using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStore.Models
{
    public class Pet
    {
        public long Id { get; set; }

        public long? Id2 { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public ICollection<string> PhotoUrls { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public Status1 Status { get; set; }
    }
}
