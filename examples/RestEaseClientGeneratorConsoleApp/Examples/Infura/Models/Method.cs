using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.Infura.Models
{
    public enum Method
    {
        eth_sendRawTransaction,
        eth_estimateGas,
        eth_submitWork,
        eth_submitHashrate
    }
}
