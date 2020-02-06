using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.Infura.Models
{
    public class JSONRPCRequest
    {
        public Jsonrpc Jsonrpc { get; set; }

        public int Id { get; set; }

        public Method Method { get; set; }

        public object[] Params { get; set; }
    }
}
