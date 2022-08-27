using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftStorage.Models
{
    /// <summary>
    /// The resource model definition containing the full set of allowed properties for a resource. Except properties bag, there cannot be a top level property outside of this set.
    /// </summary>
    public class ResourceModelWithAllowedPropertySet
    {
        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The geo-location where the resource lives
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The fully qualified resource ID of the resource that manages this resource. Indicates if this resource is managed by another Azure resource. If this is present, complete mode deployment will not delete the resource if it is removed from the template since it is managed by another resource.
        /// </summary>
        public string ManagedBy { get; set; }

        /// <summary>
        /// Metadata used by portal/tooling/etc to render different UX experiences for resources of the same type; e.g. ApiApps are a kind of Microsoft.Web/sites type.  If supported, the resource provider must validate and persist this value.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// The etag field is *not* required. If it is provided in the response body, it must also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields. 
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Resource tags.
        /// </summary>
        public object Tags { get; set; }

        /// <summary>
        /// Identity for the resource.
        /// </summary>
        public Identity Identity { get; set; }

        /// <summary>
        /// The resource model definition representing SKU
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Plan for the resource.
        /// </summary>
        public Plan Plan { get; set; }
    }
}