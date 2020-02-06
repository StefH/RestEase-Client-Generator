using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStore.Models
{
    public class Order
    {
        public long Id { get; set; }

        public long PetId { get; set; }

        public int Quantity { get; set; }

        public DateTime ShipDate { get; set; }

        public Status Status { get; set; }

        public bool Complete { get; set; }
    }
}
