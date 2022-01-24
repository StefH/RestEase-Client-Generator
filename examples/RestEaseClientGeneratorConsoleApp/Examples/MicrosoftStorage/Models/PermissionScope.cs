using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    public class PermissionScope
    {
        /// <summary>
        /// The permissions for the local user. Possible values include: Read (r), Write (w), Delete (d), List (l), and Create (c).
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        /// The service used by the local user, e.g. blob, file.
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// The name of resource, normally the container name or the file share name, used by the local user.
        /// </summary>
        public string ResourceName { get; set; }
    }
}