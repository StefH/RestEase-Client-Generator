using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage20190401.Models
{
    /// <summary>
    /// The parameters to list SAS credentials of a storage account.
    /// </summary>
    public class AccountSasParameters
    {
        /// <summary>
        /// The signed services accessible with the account SAS. Possible values include: Blob (b), Queue (q), Table (t), File (f).
        /// </summary>
        public string SignedServices { get; set; }

        /// <summary>
        /// The signed resource types that are accessible with the account SAS. Service (s): Access to service-level APIs; Container (c): Access to container-level APIs; Object (o): Access to object-level APIs for blobs, queue messages, table entities, and files.
        /// </summary>
        public string SignedResourceTypes { get; set; }

        /// <summary>
        /// The signed permissions for the account SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a), Create (c), Update (u) and Process (p).
        /// </summary>
        public string SignedPermission { get; set; }

        /// <summary>
        /// An IP address or a range of IP addresses from which to accept requests.
        /// </summary>
        public string SignedIp { get; set; }

        /// <summary>
        /// The protocol permitted for a request made with the account SAS.
        /// </summary>
        public string SignedProtocol { get; set; }

        /// <summary>
        /// The time at which the SAS becomes valid.
        /// </summary>
        public DateTime SignedStart { get; set; }

        /// <summary>
        /// The time at which the shared access signature becomes invalid.
        /// </summary>
        public DateTime SignedExpiry { get; set; }

        /// <summary>
        /// The key to sign the account SAS token with.
        /// </summary>
        public string KeyToSign { get; set; }
    }
}