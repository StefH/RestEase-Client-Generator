using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.PetStore.Models
{
    public class Pet
    {
        public int Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> PhotoUrls { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public string Status { get; set; }
    }
}
