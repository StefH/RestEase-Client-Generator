using System;
using System.Collections.Generic;

namespace MicrosoftStorageExampleConsoleApp.MicrosoftStorage.Models
{
    public class Operation
    {
        public string Name { get; set; }

        public bool IsDataAction { get; set; }

        public string Origin { get; set; }

        public string ActionType { get; set; }
    }
}