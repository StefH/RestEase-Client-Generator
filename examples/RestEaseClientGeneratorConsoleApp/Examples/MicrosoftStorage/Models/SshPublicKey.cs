using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class SshPublicKey
    {
        /// <summary>
        /// Optional. It is used to store the function/usage of the key
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ssh public key base64 encoded. The format should be: ' ', e.g. ssh-rsa AAAABBBB
        /// </summary>
        public string Key { get; set; }
    }
}