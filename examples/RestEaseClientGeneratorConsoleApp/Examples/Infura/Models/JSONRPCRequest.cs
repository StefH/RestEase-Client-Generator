using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.Infura.Models
{
    public class JSONRPCRequest
    {
        public string Jsonrpc { get; set; }

        public int Id { get; set; }

        public string Method { get; set; }

        public object[] Params { get; set; }
    }
}
