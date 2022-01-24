using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftStorage.Models
{
    /// <summary>
    /// An object that defines the blob inventory rule filter conditions. For 'Blob' definition.objectType all filter properties are applicable, 'blobTypes' is required and others are optional. For 'Container' definition.objectType only prefixMatch is applicable and is optional.
    /// </summary>
    public class BlobInventoryPolicyFilter
    {
        /// <summary>
        /// An array of strings for blob prefixes to be matched.
        /// </summary>
        public string[] PrefixMatch { get; set; }

        /// <summary>
        /// An array of predefined enum values. Valid values include blockBlob, appendBlob, pageBlob. Hns accounts does not support pageBlobs. This field is required when definition.objectType property is set to 'Blob'.
        /// </summary>
        public string[] BlobTypes { get; set; }

        /// <summary>
        /// Includes blob versions in blob inventory when value is set to true. The definition.schemaFields values 'VersionId and IsCurrentVersion' are required if this property is set to true, else they must be excluded.
        /// </summary>
        public bool IncludeBlobVersions { get; set; }

        /// <summary>
        /// Includes blob snapshots in blob inventory when value is set to true. The definition.schemaFields value 'Snapshot' is required if this property is set to true, else it must be excluded.
        /// </summary>
        public bool IncludeSnapshots { get; set; }
    }
}