using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi302.Models
{
    public class Order
    {
        public long Id { get; set; }

        public long PetId { get; set; }

        public int Quantity { get; set; }

        public DateTime ShipDate { get; set; }

        /// <summary>
        /// Order Status
        /// </summary>
        public string Status { get; set; }

        public bool Complete { get; set; }
    }
}