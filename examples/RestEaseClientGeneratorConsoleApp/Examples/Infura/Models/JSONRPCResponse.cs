using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.Infura.Models
{
    public class JSONRPCResponse
    {
        public string Jsonrpc { get; set; }

        public int Id { get; set; }

        public string Result { get; set; }
    }
}
