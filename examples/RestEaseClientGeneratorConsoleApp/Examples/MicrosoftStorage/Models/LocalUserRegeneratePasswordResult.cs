using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// The secrets of Storage Account Local User.
    /// </summary>
    public class LocalUserRegeneratePasswordResult
    {
        /// <summary>
        /// Auto generated password by the server for SSH authentication if hasSshPassword is set to true on the creation of local user.
        /// </summary>
        public string SshPassword { get; set; }
    }
}