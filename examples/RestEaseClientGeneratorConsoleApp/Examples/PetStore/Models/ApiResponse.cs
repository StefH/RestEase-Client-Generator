using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStore.Models
{
    public class ApiResponse
    {
        public int? Code { get; set; }

        public string Type { get; set; }

        public string Message { get; set; }
    }
}
