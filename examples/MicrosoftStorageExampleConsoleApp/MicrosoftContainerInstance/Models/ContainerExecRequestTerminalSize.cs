using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// The size of the terminal.
    /// </summary>
    public class ContainerExecRequestTerminalSize
    {
        /// <summary>
        /// The row size of the terminal
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// The column size of the terminal
        /// </summary>
        public int Cols { get; set; }
    }
}