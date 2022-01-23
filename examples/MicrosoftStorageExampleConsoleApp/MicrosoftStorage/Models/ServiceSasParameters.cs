using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The parameters to list service SAS credentials of a specific resource.
    /// </summary>
    public class ServiceSasParameters
    {
        /// <summary>
        /// The canonical path to the signed resource.
        /// </summary>
        public string CanonicalizedResource { get; set; }

        /// <summary>
        /// The signed services accessible with the service SAS. Possible values include: Blob (b), Container (c), File (f), Share (s).
        /// </summary>
        public string SignedResource { get; set; }

        /// <summary>
        /// The signed permissions for the service SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a), Create (c), Update (u) and Process (p).
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
        /// A unique value up to 64 characters in length that correlates to an access policy specified for the container, queue, or table.
        /// </summary>
        public string SignedIdentifier { get; set; }

        /// <summary>
        /// The start of partition key.
        /// </summary>
        public string StartPk { get; set; }

        /// <summary>
        /// The end of partition key.
        /// </summary>
        public string EndPk { get; set; }

        /// <summary>
        /// The start of row key.
        /// </summary>
        public string StartRk { get; set; }

        /// <summary>
        /// The end of row key.
        /// </summary>
        public string EndRk { get; set; }

        /// <summary>
        /// The key to sign the account SAS token with.
        /// </summary>
        public string KeyToSign { get; set; }

        /// <summary>
        /// The response header override for cache control.
        /// </summary>
        public string Rscc { get; set; }

        /// <summary>
        /// The response header override for content disposition.
        /// </summary>
        public string Rscd { get; set; }

        /// <summary>
        /// The response header override for content encoding.
        /// </summary>
        public string Rsce { get; set; }

        /// <summary>
        /// The response header override for content language.
        /// </summary>
        public string Rscl { get; set; }

        /// <summary>
        /// The response header override for content type.
        /// </summary>
        public string Rsct { get; set; }
    }
}