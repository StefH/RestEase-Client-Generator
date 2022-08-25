namespace ConsoleAppV2.MicrosoftStorage.Models
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

    /// <summary>
    /// Settings properties for Active Directory (AD).
    /// </summary>
    public class ActiveDirectoryProperties
    {
        /// <summary>
        /// Specifies the primary domain that the AD DNS server is authoritative for.
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Specifies the NetBIOS domain name.
        /// </summary>
        public string NetBiosDomainName { get; set; }

        /// <summary>
        /// Specifies the Active Directory forest to get.
        /// </summary>
        public string ForestName { get; set; }

        /// <summary>
        /// Specifies the domain GUID.
        /// </summary>
        public string DomainGuid { get; set; }

        /// <summary>
        /// Specifies the security identifier (SID).
        /// </summary>
        public string DomainSid { get; set; }

        /// <summary>
        /// Specifies the security identifier (SID) for Azure Storage.
        /// </summary>
        public string AzureStorageSid { get; set; }
    }

    /// <summary>
    /// Settings for Azure Files identity based authentication.
    /// </summary>
    public class AzureFilesIdentityBasedAuthentication
    {
        /// <summary>
        /// Indicates the directory service used.
        /// </summary>
        public string DirectoryServiceOptions { get; set; }

        public ActiveDirectoryProperties ActiveDirectoryProperties { get; set; }

        /// <summary>
        /// Default share permission for users using Kerberos authentication if RBAC role is not assigned.
        /// </summary>
        public string DefaultSharePermission { get; set; }
    }

    /// <summary>
    /// The resource model definition for an Azure Resource Manager resource with an etag.
    /// </summary>
    public class AzureEntityResource
    {
        /// <summary>
        /// Resource Etag.
        /// </summary>
        public string Etag { get; set; }
    }

    /// <summary>
    /// The check availability request body.
    /// </summary>
    public class CheckNameAvailabilityRequest
    {
        /// <summary>
        /// The name of the resource for which availability needs to be checked.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The resource type.
        /// </summary>
        public string Type { get; set; }
    }

    /// <summary>
    /// The check availability result.
    /// </summary>
    public class CheckNameAvailabilityResponse
    {
        /// <summary>
        /// Indicates if the resource name is available.
        /// </summary>
        public bool NameAvailable { get; set; }

        /// <summary>
        /// The reason why the given name is not available.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Detailed reason why the given name is available.
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// Configuration of key for data encryption
    /// </summary>
    public class EncryptionProperties
    {
        /// <summary>
        /// Indicates whether or not the encryption is enabled for container registry.
        /// </summary>
        public string Status { get; set; }

        public KeyVaultProperties KeyVaultProperties { get; set; }
    }

    /// <summary>
    /// The resource management error additional info.
    /// </summary>
    public class ErrorAdditionalInfo
    {
        /// <summary>
        /// The additional info type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The additional info.
        /// </summary>
        public object Info { get; set; }
    }

    /// <summary>
    /// The error detail.
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// The error code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The error target.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// The error details.
        /// </summary>
        public ErrorDetail[] Details { get; set; }

        /// <summary>
        /// The error additional info.
        /// </summary>
        public ErrorAdditionalInfo[] AdditionalInfo { get; set; }
    }

    /// <summary>
    /// Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows the OData error response format.).
    /// </summary>
    public class ErrorResponse
    {
        public ErrorDetail Error { get; set; }
    }

    /// <summary>
    /// Identity for the resource.
    /// </summary>
    public class Identity
    {
        /// <summary>
        /// The principal ID of resource identity.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// The tenant ID of resource.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The identity type.
        /// </summary>
        public string Type { get; set; }
    }

    public class KeyVaultProperties
    {
        /// <summary>
        /// Key vault uri to access the encryption key.
        /// </summary>
        public string KeyIdentifier { get; set; }

        /// <summary>
        /// The client ID of the identity which will be used to access key vault.
        /// </summary>
        public string Identity { get; set; }
    }

    /// <summary>
    /// Metadata pertaining to the geographic location of the resource.
    /// </summary>
    public class LocationData
    {
        /// <summary>
        /// A canonical name for the geographic or physical location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The city or locality where the resource is located.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The district, state, or province where the resource is located.
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// The country or region where the resource is located
        /// </summary>
        public string CountryOrRegion { get; set; }
    }

    /// <summary>
    /// Localized display information for this particular operation.
    /// </summary>
    public class Display
    {
        /// <summary>
        /// The localized friendly form of the resource provider name, e.g. "Microsoft Monitoring Insights" or "Microsoft Compute".
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// The localized friendly name of the resource type related to this operation. E.g. "Virtual Machines" or "Job Schedule Collections".
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// The concise, localized friendly name for the operation; suitable for dropdowns. E.g. "Create or Update Virtual Machine", "Restart Virtual Machine".
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// The short, localized friendly description of the operation; suitable for tool tips and detailed views.
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// Details of a REST API operation, returned from the Resource Provider Operations API
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// The name of the operation, as per Resource-Based Access Control (RBAC). Examples: "Microsoft.Compute/virtualMachines/write", "Microsoft.Compute/virtualMachines/capture/action"
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether the operation applies to data-plane. This is "true" for data-plane operations and "false" for ARM/control-plane operations.
        /// </summary>
        public bool IsDataAction { get; set; }

        /// <summary>
        /// Localized display information for this particular operation.
        /// </summary>
        public Display Display { get; set; }

        /// <summary>
        /// The intended executor of the operation; as in Resource Based Access Control (RBAC) and audit logs UX. Default value is "user,system"
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Enum. Indicates the action type. "Internal" refers to actions that are for internal only APIs.
        /// </summary>
        public string ActionType { get; set; }
    }

    /// <summary>
    /// A list of REST API operations supported by an Azure Resource Provider. It contains an URL link to get the next set of results.
    /// </summary>
    public class OperationListResult
    {
        /// <summary>
        /// List of operations supported by the resource provider
        /// </summary>
        public Models.Operation[] Value { get; set; }

        /// <summary>
        /// URL to get the next set of operation list results (if there are any).
        /// </summary>
        public string NextLink { get; set; }
    }

    /// <summary>
    /// The current status of an async operation.
    /// </summary>
    public class OperationStatusResult
    {
        /// <summary>
        /// Fully qualified ID for the async operation.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the async operation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Operation status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Percent of the operation that is complete.
        /// </summary>
        public double PercentComplete { get; set; }

        /// <summary>
        /// The start time of the operation.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The end time of the operation.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// The operations list.
        /// </summary>
        public OperationStatusResult[] Operations { get; set; }

        public ErrorDetail Error { get; set; }
    }

    /// <summary>
    /// Plan for the resource.
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// A user defined name of the 3rd Party Artifact that is being procured.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at the time of Data Market onboarding. 
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// A publisher provided promotion code as provisioned in Data Market for the said product/artifact.
        /// </summary>
        public string PromotionCode { get; set; }

        /// <summary>
        /// The version of the desired product/artifact.
        /// </summary>
        public string Version { get; set; }
    }

    /// <summary>
    /// Common fields that are returned in the response for all Azure Resource Manager resources
    /// </summary>
    public class Resource
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
    }

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

        public Identity Identity { get; set; }

        public Sku Sku { get; set; }

        public Plan Plan { get; set; }
    }

    /// <summary>
    /// The resource model definition representing SKU
    /// </summary>
    public class Sku
    {
        /// <summary>
        /// The name of the SKU. Ex - P3. It is typically a letter+number code
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT.
        /// </summary>
        public string Tier { get; set; }

        /// <summary>
        /// The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code. 
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// If the service has different generations of hardware, for the same SKU, then that can be captured here.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the resource this may be omitted.
        /// </summary>
        public int Capacity { get; set; }
    }

    /// <summary>
    /// Metadata pertaining to creation and last modification of the resource.
    /// </summary>
    public class SystemData
    {
        /// <summary>
        /// The identity that created the resource.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// The type of identity that created the resource.
        /// </summary>
        public string CreatedByType { get; set; }

        /// <summary>
        /// The timestamp of resource creation (UTC).
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The identity that last modified the resource.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// The type of identity that last modified the resource.
        /// </summary>
        public string LastModifiedByType { get; set; }

        /// <summary>
        /// The timestamp of resource last modification (UTC)
        /// </summary>
        public DateTime LastModifiedAt { get; set; }
    }

    /// <summary>
    /// The resource model definition for an Azure Resource Manager tracked top level resource which has 'tags' and a 'location'
    /// </summary>
    public class TrackedResource
    {
        /// <summary>
        /// Resource tags.
        /// </summary>
        public object Tags { get; set; }

        /// <summary>
        /// The geo-location where the resource lives
        /// </summary>
        public string Location { get; set; }
    }

    /// <summary>
    /// The storage account blob inventory policy.
    /// </summary>
    public class BlobInventoryPolicy
    {
        public BlobInventoryPolicyProperties Properties { get; set; }

        /// <summary>
        /// Metadata pertaining to creation and last modification of the resource.
        /// </summary>
        public SystemData SystemData { get; set; }
    }

    /// <summary>
    /// An object that defines the blob inventory rule.
    /// </summary>
    public class BlobInventoryPolicyDefinition
    {
        public BlobInventoryPolicyFilter Filters { get; set; }

        /// <summary>
        /// This is a required field, it specifies the format for the inventory files.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// This is a required field. This field is used to schedule an inventory formation.
        /// </summary>
        public string Schedule { get; set; }

        /// <summary>
        /// This is a required field. This field specifies the scope of the inventory created either at the blob or container level.
        /// </summary>
        public string ObjectType { get; set; }

        /// <summary>
        /// This is a required field. This field specifies the fields and properties of the object to be included in the inventory. The Schema field value 'Name' is always required. The valid values for this field for the 'Blob' definition.objectType include 'Name, Creation-Time, Last-Modified, Content-Length, Content-MD5, BlobType, AccessTier, AccessTierChangeTime, Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl, Snapshot, VersionId, IsCurrentVersion, Metadata, LastAccessTime'. The valid values for 'Container' definition.objectType include 'Name, Last-Modified, Metadata, LeaseStatus, LeaseState, LeaseDuration, PublicAccess, HasImmutabilityPolicy, HasLegalHold'. Schema field values 'Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl' are valid only for Hns enabled accounts.
        /// </summary>
        public string[] SchemaFields { get; set; }
    }

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

    /// <summary>
    /// The storage account blob inventory policy properties.
    /// </summary>
    public class BlobInventoryPolicyProperties
    {
        /// <summary>
        /// Returns the last modified date and time of the blob inventory policy.
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        public BlobInventoryPolicySchema Policy { get; set; }
    }

    /// <summary>
    /// An object that wraps the blob inventory rule. Each rule is uniquely defined by name.
    /// </summary>
    public class BlobInventoryPolicyRule
    {
        /// <summary>
        /// Rule is enabled when set to true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Container name where blob inventory files are stored. Must be pre-created.
        /// </summary>
        public string Destination { get; set; }

        public BlobInventoryPolicyDefinition Definition { get; set; }
    }

    /// <summary>
    /// The storage account blob inventory policy rules.
    /// </summary>
    public class BlobInventoryPolicySchema
    {
        /// <summary>
        /// Policy is enabled if set to true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The valid value is Inventory
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The storage account blob inventory policy rules. The rule is applied when it is enabled.
        /// </summary>
        public BlobInventoryPolicyRule[] Rules { get; set; }
    }

    /// <summary>
    /// Blob restore parameters
    /// </summary>
    public class BlobRestoreParameters
    {
        /// <summary>
        /// Restore blob to the specified time.
        /// </summary>
        public DateTime TimeToRestore { get; set; }

        /// <summary>
        /// Blob ranges to restore.
        /// </summary>
        public BlobRestoreRange[] BlobRanges { get; set; }
    }

    /// <summary>
    /// Blob range
    /// </summary>
    public class BlobRestoreRange
    {
        /// <summary>
        /// Blob start range. This is inclusive. Empty means account start.
        /// </summary>
        public string StartRange { get; set; }

        /// <summary>
        /// Blob end range. This is exclusive. Empty means account end.
        /// </summary>
        public string EndRange { get; set; }
    }

    /// <summary>
    /// Blob restore status.
    /// </summary>
    public class BlobRestoreStatus
    {
        /// <summary>
        /// The status of blob restore progress. Possible values are: - InProgress: Indicates that blob restore is ongoing. - Complete: Indicates that blob restore has been completed successfully. - Failed: Indicates that blob restore is failed.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Failure reason when blob restore is failed.
        /// </summary>
        public string FailureReason { get; set; }

        /// <summary>
        /// Id for tracking blob restore request.
        /// </summary>
        public string RestoreId { get; set; }

        public BlobRestoreParameters Parameters { get; set; }
    }

    /// <summary>
    /// The CheckNameAvailability operation response.
    /// </summary>
    public class CheckNameAvailabilityResult
    {
        /// <summary>
        /// Gets a boolean value that indicates whether the name is available for you to use. If true, the name is available. If false, the name has already been taken or is invalid and cannot be used.
        /// </summary>
        public bool NameAvailable { get; set; }

        /// <summary>
        /// Gets the reason that a storage account name could not be used. The Reason element is only returned if NameAvailable is false.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets an error message explaining the Reason value in more detail.
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// The custom domain assigned to this storage account. This can be set via Update.
    /// </summary>
    public class CustomDomain
    {
        /// <summary>
        /// Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        /// </summary>
        public bool UseSubDomainName { get; set; }
    }

    /// <summary>
    /// Object to define the number of days after creation.
    /// </summary>
    public class DateAfterCreation
    {
        /// <summary>
        /// Value indicating the age in days after creation
        /// </summary>
        public double DaysAfterCreationGreaterThan { get; set; }
    }

    /// <summary>
    /// Object to define the number of days after object last modification Or last access. Properties daysAfterModificationGreaterThan and daysAfterLastAccessTimeGreaterThan are mutually exclusive.
    /// </summary>
    public class DateAfterModification
    {
        /// <summary>
        /// Value indicating the age in days after last modification
        /// </summary>
        public double DaysAfterModificationGreaterThan { get; set; }

        /// <summary>
        /// Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy
        /// </summary>
        public double DaysAfterLastAccessTimeGreaterThan { get; set; }
    }

    /// <summary>
    /// Deleted storage account
    /// </summary>
    public class DeletedAccount
    {
        public DeletedAccountProperties Properties { get; set; }
    }

    /// <summary>
    /// The response from the List Deleted Accounts operation.
    /// </summary>
    public class DeletedAccountListResult
    {
        /// <summary>
        /// Gets the list of deleted accounts and their properties.
        /// </summary>
        public DeletedAccount[] Value { get; set; }

        /// <summary>
        /// Request URL that can be used to query next page of deleted accounts. Returned when total number of requested deleted accounts exceed maximum page size.
        /// </summary>
        public string NextLink { get; set; }
    }

    /// <summary>
    /// Attributes of a deleted storage account.
    /// </summary>
    public class DeletedAccountProperties
    {
        /// <summary>
        /// Full resource id of the original storage account.
        /// </summary>
        public string StorageAccountResourceId { get; set; }

        /// <summary>
        /// Location of the deleted account.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Can be used to attempt recovering this deleted account via PutStorageAccount API.
        /// </summary>
        public string RestoreReference { get; set; }

        /// <summary>
        /// Creation time of the deleted account.
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// Deletion time of the deleted account.
        /// </summary>
        public string DeletionTime { get; set; }
    }

    /// <summary>
    /// Dimension of blobs, possibly be blob type or access tier.
    /// </summary>
    public class Dimension
    {
        /// <summary>
        /// Display name of dimension.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display name of dimension.
        /// </summary>
        public string DisplayName { get; set; }
    }

    /// <summary>
    /// The encryption settings on the storage account.
    /// </summary>
    public class Encryption
    {
        public EncryptionServices Services { get; set; }

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive):  Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        public string KeySource { get; set; }

        /// <summary>
        /// A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest.
        /// </summary>
        public bool RequireInfrastructureEncryption { get; set; }

        public KeyVaultProperties Keyvaultproperties { get; set; }

        public EncryptionIdentity Identity { get; set; }
    }

    /// <summary>
    /// Encryption identity for the storage account.
    /// </summary>
    public class EncryptionIdentity
    {
        /// <summary>
        /// Resource identifier of the UserAssigned identity to be associated with server-side encryption on the storage account.
        /// </summary>
        public string UserAssignedIdentity { get; set; }
    }

    /// <summary>
    /// The Encryption Scope resource.
    /// </summary>
    public class EncryptionScope
    {
        public EncryptionScopeProperties Properties { get; set; }
    }

    /// <summary>
    /// The key vault properties for the encryption scope. This is a required field if encryption scope 'source' attribute is set to 'Microsoft.KeyVault'.
    /// </summary>
    public class EncryptionScopeKeyVaultProperties
    {
        /// <summary>
        /// The object identifier for a key vault key object. When applied, the encryption scope will use the key referenced by the identifier to enable customer-managed key support on this encryption scope.
        /// </summary>
        public string KeyUri { get; set; }

        /// <summary>
        /// The object identifier of the current versioned Key Vault Key in use.
        /// </summary>
        public string CurrentVersionedKeyIdentifier { get; set; }

        /// <summary>
        /// Timestamp of last rotation of the Key Vault Key.
        /// </summary>
        public DateTime LastKeyRotationTimestamp { get; set; }
    }

    /// <summary>
    /// List of encryption scopes requested, and if paging is required, a URL to the next page of encryption scopes.
    /// </summary>
    public class EncryptionScopeListResult
    {
        /// <summary>
        /// List of encryption scopes requested.
        /// </summary>
        public EncryptionScope[] Value { get; set; }

        /// <summary>
        /// Request URL that can be used to query next page of encryption scopes. Returned when total number of requested encryption scopes exceeds the maximum page size.
        /// </summary>
        public string NextLink { get; set; }
    }

    /// <summary>
    /// Properties of the encryption scope.
    /// </summary>
    public class EncryptionScopeProperties
    {
        /// <summary>
        /// The provider for the encryption scope. Possible values (case-insensitive):  Microsoft.Storage, Microsoft.KeyVault.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The state of the encryption scope. Possible values (case-insensitive):  Enabled, Disabled.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets the creation date and time of the encryption scope in UTC.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets the last modification date and time of the encryption scope in UTC.
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        public EncryptionScopeKeyVaultProperties KeyVaultProperties { get; set; }

        /// <summary>
        /// A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest.
        /// </summary>
        public bool RequireInfrastructureEncryption { get; set; }
    }

    /// <summary>
    /// A service that allows server-side encryption to be used.
    /// </summary>
    public class EncryptionService
    {
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        public DateTime LastEnabledTime { get; set; }

        /// <summary>
        /// Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used.
        /// </summary>
        public string KeyType { get; set; }
    }

    /// <summary>
    /// A list of services that support encryption.
    /// </summary>
    public class EncryptionServices
    {
        public EncryptionService Blob { get; set; }

        public EncryptionService File { get; set; }

        public EncryptionService Table { get; set; }

        public EncryptionService Queue { get; set; }
    }

    /// <summary>
    /// The URIs that are used to perform a retrieval of a public blob, queue, table, web or dfs object.
    /// </summary>
    public class Endpoints
    {
        /// <summary>
        /// Gets the blob endpoint.
        /// </summary>
        public string Blob { get; set; }

        /// <summary>
        /// Gets the queue endpoint.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        /// Gets the table endpoint.
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// Gets the file endpoint.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Gets the web endpoint.
        /// </summary>
        public string Web { get; set; }

        /// <summary>
        /// Gets the dfs endpoint.
        /// </summary>
        public string Dfs { get; set; }

        public StorageAccountMicrosoftEndpoints MicrosoftEndpoints { get; set; }

        public StorageAccountInternetEndpoints InternetEndpoints { get; set; }
    }

    /// <summary>
    /// Error response body contract.
    /// </summary>
    public class ErrorResponseBody
    {
        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// The complex type of the extended location.
    /// </summary>
    public class ExtendedLocation
    {
        /// <summary>
        /// The name of the extended location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of extendedLocation.
        /// </summary>
        public string Type { get; set; }
    }

    /// <summary>
    /// Statistics related to replication for storage account's Blob, Table, Queue and File services. It is only available when geo-redundant replication is enabled for the storage account.
    /// </summary>
    public class GeoReplicationStats
    {
        /// <summary>
        /// The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location is temporarily unavailable.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime is not available, this can happen if secondary is offline or we are in bootstrap.
        /// </summary>
        public DateTime LastSyncTime { get; set; }

        /// <summary>
        /// A boolean flag which indicates whether or not account failover is supported for the account.
        /// </summary>
        public bool CanFailover { get; set; }
    }

    /// <summary>
    /// IP rule with specific IP or IP range in CIDR format.
    /// </summary>
    public class IPRule
    {
        /// <summary>
        /// Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The action of IP ACL rule.
        /// </summary>
        public string Action { get; set; }
    }

    /// <summary>
    /// Storage account keys creation time.
    /// </summary>
    public class KeyCreationTime
    {
        public DateTime Key1 { get; set; }

        public DateTime Key2 { get; set; }
    }

    /// <summary>
    /// KeyPolicy assigned to the storage account.
    /// </summary>
    public class KeyPolicy
    {
        /// <summary>
        /// The key expiration period in days.
        /// </summary>
        public int KeyExpirationPeriodInDays { get; set; }
    }

    /// <summary>
    /// The List SAS credentials operation response.
    /// </summary>
    public class ListAccountSasResponse
    {
        /// <summary>
        /// List SAS credentials of storage account.
        /// </summary>
        public string AccountSasToken { get; set; }
    }

    /// <summary>
    /// List of blob inventory policies returned.
    /// </summary>
    public class ListBlobInventoryPolicy
    {
        /// <summary>
        /// List of blob inventory policies.
        /// </summary>
        public BlobInventoryPolicy[] Value { get; set; }
    }

    /// <summary>
    /// The List service SAS credentials operation response.
    /// </summary>
    public class ListServiceSasResponse
    {
        /// <summary>
        /// List service SAS credentials of specific resource.
        /// </summary>
        public string ServiceSasToken { get; set; }
    }

    /// <summary>
    /// The Get Storage Account ManagementPolicies operation response.
    /// </summary>
    public class ManagementPolicy
    {
        public ManagementPolicyProperties Properties { get; set; }
    }

    /// <summary>
    /// Actions are applied to the filtered blobs when the execution condition is met.
    /// </summary>
    public class ManagementPolicyAction
    {
        public ManagementPolicyBaseBlob BaseBlob { get; set; }

        public ManagementPolicySnapShot Snapshot { get; set; }

        public ManagementPolicyVersion Version { get; set; }
    }

    /// <summary>
    /// Management policy action for base blob.
    /// </summary>
    public class ManagementPolicyBaseBlob
    {
        public DateAfterModification TierToCool { get; set; }

        public DateAfterModification TierToArchive { get; set; }

        public DateAfterModification Delete { get; set; }

        /// <summary>
        /// This property enables auto tiering of a blob from cool to hot on a blob access. This property requires tierToCool.daysAfterLastAccessTimeGreaterThan.
        /// </summary>
        public bool EnableAutoTierToHotFromCool { get; set; }
    }

    /// <summary>
    /// An object that defines the Lifecycle rule. Each definition is made up with a filters set and an actions set.
    /// </summary>
    public class ManagementPolicyDefinition
    {
        public ManagementPolicyAction Actions { get; set; }

        public ManagementPolicyFilter Filters { get; set; }
    }

    /// <summary>
    /// Filters limit rule actions to a subset of blobs within the storage account. If multiple filters are defined, a logical AND is performed on all filters. 
    /// </summary>
    public class ManagementPolicyFilter
    {
        /// <summary>
        /// An array of strings for prefixes to be match.
        /// </summary>
        public string[] PrefixMatch { get; set; }

        /// <summary>
        /// An array of predefined enum values. Currently blockBlob supports all tiering and delete actions. Only delete actions are supported for appendBlob.
        /// </summary>
        public string[] BlobTypes { get; set; }

        /// <summary>
        /// An array of blob index tag based filters, there can be at most 10 tag filters
        /// </summary>
        public TagFilter[] BlobIndexMatch { get; set; }
    }

    /// <summary>
    /// The Storage Account ManagementPolicy properties.
    /// </summary>
    public class ManagementPolicyProperties
    {
        /// <summary>
        /// Returns the date and time the ManagementPolicies was last modified.
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        public ManagementPolicySchema Policy { get; set; }
    }

    /// <summary>
    /// An object that wraps the Lifecycle rule. Each rule is uniquely defined by name.
    /// </summary>
    public class ManagementPolicyRule
    {
        /// <summary>
        /// Rule is enabled if set to true.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The valid value is Lifecycle
        /// </summary>
        public string Type { get; set; }

        public ManagementPolicyDefinition Definition { get; set; }
    }

    /// <summary>
    /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
    /// </summary>
    public class ManagementPolicySchema
    {
        /// <summary>
        /// The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
        /// </summary>
        public ManagementPolicyRule[] Rules { get; set; }
    }

    /// <summary>
    /// Management policy action for snapshot.
    /// </summary>
    public class ManagementPolicySnapShot
    {
        public DateAfterCreation TierToCool { get; set; }

        public DateAfterCreation TierToArchive { get; set; }

        public DateAfterCreation Delete { get; set; }
    }

    /// <summary>
    /// Management policy action for blob version.
    /// </summary>
    public class ManagementPolicyVersion
    {
        public DateAfterCreation TierToCool { get; set; }

        public DateAfterCreation TierToArchive { get; set; }

        public DateAfterCreation Delete { get; set; }
    }

    /// <summary>
    /// Metric specification of operation.
    /// </summary>
    public class MetricSpecification
    {
        /// <summary>
        /// Name of metric specification.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display name of metric specification.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Display description of metric specification.
        /// </summary>
        public string DisplayDescription { get; set; }

        /// <summary>
        /// Unit could be Bytes or Count.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Dimensions of blobs, including blob type and access tier.
        /// </summary>
        public Dimension[] Dimensions { get; set; }

        /// <summary>
        /// Aggregation type could be Average.
        /// </summary>
        public string AggregationType { get; set; }

        /// <summary>
        /// The property to decide fill gap with zero or not.
        /// </summary>
        public bool FillGapWithZero { get; set; }

        /// <summary>
        /// The category this metric specification belong to, could be Capacity.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Account Resource Id.
        /// </summary>
        public string ResourceIdDimensionNameOverride { get; set; }
    }

    /// <summary>
    /// Network rule set
    /// </summary>
    public class NetworkRuleSet
    {
        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        public string Bypass { get; set; }

        /// <summary>
        /// Sets the resource access rules
        /// </summary>
        public ResourceAccessRule[] ResourceAccessRules { get; set; }

        /// <summary>
        /// Sets the virtual network rules
        /// </summary>
        public VirtualNetworkRule[] VirtualNetworkRules { get; set; }

        /// <summary>
        /// Sets the IP ACL rules
        /// </summary>
        public IPRule[] IpRules { get; set; }

        /// <summary>
        /// Specifies the default action of allow or deny when no other rules match.
        /// </summary>
        public string DefaultAction { get; set; }
    }

    /// <summary>
    /// List storage account object replication policies.
    /// </summary>
    public class ObjectReplicationPolicies
    {
        /// <summary>
        /// The replication policy between two storage accounts.
        /// </summary>
        public ObjectReplicationPolicy[] Value { get; set; }
    }

    /// <summary>
    /// The replication policy between two storage accounts. Multiple rules can be defined in one policy.
    /// </summary>
    public class ObjectReplicationPolicy
    {
        public ObjectReplicationPolicyProperties Properties { get; set; }
    }

    /// <summary>
    /// Filters limit replication to a subset of blobs within the storage account. A logical OR is performed on values in the filter. If multiple filters are defined, a logical AND is performed on all filters.
    /// </summary>
    public class ObjectReplicationPolicyFilter
    {
        /// <summary>
        /// Optional. Filters the results to replicate only blobs whose names begin with the specified prefix.
        /// </summary>
        public string[] PrefixMatch { get; set; }

        /// <summary>
        /// Blobs created after the time will be replicated to the destination. It must be in datetime format 'yyyy-MM-ddTHH:mm:ssZ'. Example: 2020-02-19T16:05:00Z
        /// </summary>
        public string MinCreationTime { get; set; }
    }

    /// <summary>
    /// The Storage Account ObjectReplicationPolicy properties.
    /// </summary>
    public class ObjectReplicationPolicyProperties
    {
        /// <summary>
        /// A unique id for object replication policy.
        /// </summary>
        public string PolicyId { get; set; }

        /// <summary>
        /// Indicates when the policy is enabled on the source account.
        /// </summary>
        public DateTime EnabledTime { get; set; }

        /// <summary>
        /// Required. Source account name. It should be full resource id if allowCrossTenantReplication set to false.
        /// </summary>
        public string SourceAccount { get; set; }

        /// <summary>
        /// Required. Destination account name. It should be full resource id if allowCrossTenantReplication set to false.
        /// </summary>
        public string DestinationAccount { get; set; }

        /// <summary>
        /// The storage account object replication rules.
        /// </summary>
        public ObjectReplicationPolicyRule[] Rules { get; set; }
    }

    /// <summary>
    /// The replication policy rule between two containers.
    /// </summary>
    public class ObjectReplicationPolicyRule
    {
        /// <summary>
        /// Rule Id is auto-generated for each new rule on destination account. It is required for put policy on source account.
        /// </summary>
        public string RuleId { get; set; }

        /// <summary>
        /// Required. Source container name.
        /// </summary>
        public string SourceContainer { get; set; }

        /// <summary>
        /// Required. Destination container name.
        /// </summary>
        public string DestinationContainer { get; set; }

        public ObjectReplicationPolicyFilter Filters { get; set; }
    }

    /// <summary>
    /// Properties of operation, include metric specifications.
    /// </summary>
    public class OperationProperties
    {
        public ServiceSpecification ServiceSpecification { get; set; }
    }

    /// <summary>
    /// Resource Access Rule.
    /// </summary>
    public class ResourceAccessRule
    {
        /// <summary>
        /// Tenant Id
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Resource Id
        /// </summary>
        public string ResourceId { get; set; }
    }

    /// <summary>
    /// The restriction because of which SKU cannot be used.
    /// </summary>
    public class Restriction
    {
        /// <summary>
        /// The type of restrictions. As of now only possible value for this is location.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The value of restrictions. If the restriction type is set to location. This would be different locations where the SKU is restricted.
        /// </summary>
        public string[] Values { get; set; }

        /// <summary>
        /// The reason for the restriction. As of now this can be "QuotaId" or "NotAvailableForSubscription". Quota Id is set when the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The "NotAvailableForSubscription" is related to capacity at DC.
        /// </summary>
        public string ReasonCode { get; set; }
    }

    /// <summary>
    /// Routing preference defines the type of network, either microsoft or internet routing to be used to deliver the user data, the default option is microsoft routing
    /// </summary>
    public class RoutingPreference
    {
        /// <summary>
        /// Routing Choice defines the kind of network routing opted by the user.
        /// </summary>
        public string RoutingChoice { get; set; }

        /// <summary>
        /// A boolean flag which indicates whether microsoft routing storage endpoints are to be published
        /// </summary>
        public bool PublishMicrosoftEndpoints { get; set; }

        /// <summary>
        /// A boolean flag which indicates whether internet routing storage endpoints are to be published
        /// </summary>
        public bool PublishInternetEndpoints { get; set; }
    }

    /// <summary>
    /// SasPolicy assigned to the storage account.
    /// </summary>
    public class SasPolicy
    {
        /// <summary>
        /// The SAS expiration period, DD.HH:MM:SS.
        /// </summary>
        public string SasExpirationPeriod { get; set; }

        /// <summary>
        /// The SAS expiration action. Can only be Log.
        /// </summary>
        public string ExpirationAction { get; set; }
    }

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

    /// <summary>
    /// One property of operation, include metric specifications.
    /// </summary>
    public class ServiceSpecification
    {
        /// <summary>
        /// Metric specifications of operation.
        /// </summary>
        public MetricSpecification[] MetricSpecifications { get; set; }
    }

    /// <summary>
    /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
    /// </summary>
    public class SKUCapability
    {
        /// <summary>
        /// The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A string value to indicate states of given capability. Possibly 'true' or 'false'.
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// Specifies a CORS rule for the Blob service.
    /// </summary>
    public class CorsRule
    {
        /// <summary>
        /// Required if CorsRule element is present. A list of origin domains that will be allowed via CORS, or "*" to allow all domains
        /// </summary>
        public string[] AllowedOrigins { get; set; }

        /// <summary>
        /// Required if CorsRule element is present. A list of HTTP methods that are allowed to be executed by the origin.
        /// </summary>
        public string[] AllowedMethods { get; set; }

        /// <summary>
        /// Required if CorsRule element is present. The number of seconds that the client/browser should cache a preflight response.
        /// </summary>
        public int MaxAgeInSeconds { get; set; }

        /// <summary>
        /// Required if CorsRule element is present. A list of response headers to expose to CORS clients.
        /// </summary>
        public string[] ExposedHeaders { get; set; }

        /// <summary>
        /// Required if CorsRule element is present. A list of headers allowed to be part of the cross-origin request.
        /// </summary>
        public string[] AllowedHeaders { get; set; }
    }

    /// <summary>
    /// Sets the CORS rules. You can include up to five CorsRule elements in the request. 
    /// </summary>
    public class CorsRules
    {
        /// <summary>
        /// The List of CORS rules. You can include up to five CorsRule elements in the request. 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("CorsRules")]
        public CorsRule[] CorsRules_ { get; set; }
    }

    /// <summary>
    /// The service properties for soft delete.
    /// </summary>
    public class DeleteRetentionPolicy
    {
        /// <summary>
        /// Indicates whether DeleteRetentionPolicy is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Indicates the number of days that the deleted item should be retained. The minimum specified value can be 1 and the maximum value can be 365.
        /// </summary>
        public int Days { get; set; }
    }

    /// <summary>
    /// Storage SKU and its properties
    /// </summary>
    public class SkuInformation
    {
        public string Name { get; set; }

        public string Tier { get; set; }

        /// <summary>
        /// The type of the resource, usually it is 'storageAccounts'.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// Indicates the type of storage account.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.).
        /// </summary>
        public string[] Locations { get; set; }

        /// <summary>
        /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        public SKUCapability[] Capabilities { get; set; }

        /// <summary>
        /// The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        /// </summary>
        public Restriction[] Restrictions { get; set; }
    }

    /// <summary>
    /// The storage account.
    /// </summary>
    public class StorageAccount
    {
        /// <summary>
        /// The resource model definition representing SKU
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Gets the Kind.
        /// </summary>
        public string Kind { get; set; }

        public Identity Identity { get; set; }

        public ExtendedLocation ExtendedLocation { get; set; }

        public StorageAccountProperties Properties { get; set; }
    }

    /// <summary>
    /// The parameters used to check the availability of the storage account name.
    /// </summary>
    public class StorageAccountCheckNameAvailabilityParameters
    {
        /// <summary>
        /// The storage account name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of resource, Microsoft.Storage/storageAccounts
        /// </summary>
        public string Type { get; set; }
    }

    /// <summary>
    /// The parameters used when creating a storage account.
    /// </summary>
    public class StorageAccountCreateParameters
    {
        /// <summary>
        /// The resource model definition representing SKU
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Required. Indicates the type of storage account.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed.
        /// </summary>
        public string Location { get; set; }

        public ExtendedLocation ExtendedLocation { get; set; }

        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters.
        /// </summary>
        public object Tags { get; set; }

        public Identity Identity { get; set; }

        public StorageAccountPropertiesCreateParameters Properties { get; set; }
    }

    /// <summary>
    /// The URIs that are used to perform a retrieval of a public blob, file, web or dfs object via a internet routing endpoint.
    /// </summary>
    public class StorageAccountInternetEndpoints
    {
        /// <summary>
        /// Gets the blob endpoint.
        /// </summary>
        public string Blob { get; set; }

        /// <summary>
        /// Gets the file endpoint.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Gets the web endpoint.
        /// </summary>
        public string Web { get; set; }

        /// <summary>
        /// Gets the dfs endpoint.
        /// </summary>
        public string Dfs { get; set; }
    }

    /// <summary>
    /// An access key for the storage account.
    /// </summary>
    public class StorageAccountKey
    {
        /// <summary>
        /// Name of the key.
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// Base 64-encoded value of the key.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Permissions for the key -- read-only or full permissions.
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        /// Creation time of the key, in round trip date format.
        /// </summary>
        public DateTime CreationTime { get; set; }
    }

    /// <summary>
    /// The response from the ListKeys operation.
    /// </summary>
    public class StorageAccountListKeysResult
    {
        /// <summary>
        /// Gets the list of storage account keys and their properties for the specified storage account.
        /// </summary>
        public StorageAccountKey[] Keys { get; set; }
    }

    /// <summary>
    /// The response from the List Storage Accounts operation.
    /// </summary>
    public class StorageAccountListResult
    {
        /// <summary>
        /// Gets the list of storage accounts and their properties.
        /// </summary>
        public StorageAccount[] Value { get; set; }

        /// <summary>
        /// Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size.
        /// </summary>
        public string NextLink { get; set; }
    }

    /// <summary>
    /// The URIs that are used to perform a retrieval of a public blob, queue, table, web or dfs object via a microsoft routing endpoint.
    /// </summary>
    public class StorageAccountMicrosoftEndpoints
    {
        /// <summary>
        /// Gets the blob endpoint.
        /// </summary>
        public string Blob { get; set; }

        /// <summary>
        /// Gets the queue endpoint.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        /// Gets the table endpoint.
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// Gets the file endpoint.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Gets the web endpoint.
        /// </summary>
        public string Web { get; set; }

        /// <summary>
        /// Gets the dfs endpoint.
        /// </summary>
        public string Dfs { get; set; }
    }

    /// <summary>
    /// The Private Endpoint resource.
    /// </summary>
    public class PrivateEndpoint
    {
        /// <summary>
        /// The ARM identifier for Private Endpoint
        /// </summary>
        public string Id { get; set; }
    }

    /// <summary>
    /// The Private Endpoint Connection resource.
    /// </summary>
    public class PrivateEndpointConnection
    {
        public PrivateEndpointConnectionProperties Properties { get; set; }
    }

    /// <summary>
    /// List of private endpoint connection associated with the specified storage account
    /// </summary>
    public class PrivateEndpointConnectionListResult
    {
        /// <summary>
        /// Array of private endpoint connections
        /// </summary>
        public PrivateEndpointConnection[] Value { get; set; }
    }

    /// <summary>
    /// Properties of the PrivateEndpointConnectProperties.
    /// </summary>
    public class PrivateEndpointConnectionProperties
    {
        public PrivateEndpoint PrivateEndpoint { get; set; }

        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }

        /// <summary>
        /// The current provisioning state.
        /// </summary>
        public string ProvisioningState { get; set; }
    }

    /// <summary>
    /// A private link resource
    /// </summary>
    public class PrivateLinkResource
    {
        public PrivateLinkResourceProperties Properties { get; set; }
    }

    /// <summary>
    /// A list of private link resources
    /// </summary>
    public class PrivateLinkResourceListResult
    {
        /// <summary>
        /// Array of private link resources
        /// </summary>
        public PrivateLinkResource[] Value { get; set; }
    }

    /// <summary>
    /// Properties of a private link resource.
    /// </summary>
    public class PrivateLinkResourceProperties
    {
        /// <summary>
        /// The private link resource group id.
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// The private link resource required member names.
        /// </summary>
        public string[] RequiredMembers { get; set; }

        /// <summary>
        /// The private link resource Private link DNS zone name.
        /// </summary>
        public string[] RequiredZoneNames { get; set; }
    }

    /// <summary>
    /// A collection of information about the state of the connection between service consumer and provider.
    /// </summary>
    public class PrivateLinkServiceConnectionState
    {
        /// <summary>
        /// The private endpoint connection status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The reason for approval/rejection of the connection.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A message indicating if changes on the service provider require any updates on the consumer.
        /// </summary>
        public string ActionRequired { get; set; }
    }

    /// <summary>
    /// Properties of the storage account.
    /// </summary>
    public class StorageAccountProperties
    {
        /// <summary>
        /// Gets the status of the storage account at the time the operation was called.
        /// </summary>
        public string ProvisioningState { get; set; }

        public Endpoints PrimaryEndpoints { get; set; }

        /// <summary>
        /// Gets the location of the primary data center for the storage account.
        /// </summary>
        public string PrimaryLocation { get; set; }

        /// <summary>
        /// Gets the status indicating whether the primary location of the storage account is available or unavailable.
        /// </summary>
        public string StatusOfPrimary { get; set; }

        /// <summary>
        /// Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp is retained. This element is not returned if there has never been a failover instance. Only available if the accountType is Standard_GRS or Standard_RAGRS.
        /// </summary>
        public DateTime LastGeoFailoverTime { get; set; }

        /// <summary>
        /// Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS or Standard_RAGRS.
        /// </summary>
        public string SecondaryLocation { get; set; }

        /// <summary>
        /// Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available if the SKU name is Standard_GRS or Standard_RAGRS.
        /// </summary>
        public string StatusOfSecondary { get; set; }

        /// <summary>
        /// Gets the creation date and time of the storage account in UTC.
        /// </summary>
        public DateTime CreationTime { get; set; }

        public CustomDomain CustomDomain { get; set; }

        public SasPolicy SasPolicy { get; set; }

        public KeyPolicy KeyPolicy { get; set; }

        public KeyCreationTime KeyCreationTime { get; set; }

        public Endpoints SecondaryEndpoints { get; set; }

        public Encryption Encryption { get; set; }

        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        public string AccessTier { get; set; }

        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        /// <summary>
        /// Allows https traffic only to storage service if sets to true.
        /// </summary>
        public bool SupportsHttpsTrafficOnly { get; set; }

        public NetworkRuleSet NetworkAcls { get; set; }

        /// <summary>
        /// Account HierarchicalNamespace enabled if sets to true.
        /// </summary>
        public bool IsHnsEnabled { get; set; }

        public GeoReplicationStats GeoReplicationStats { get; set; }

        /// <summary>
        /// If the failover is in progress, the value will be true, otherwise, it will be null.
        /// </summary>
        public bool FailoverInProgress { get; set; }

        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        public string LargeFileSharesState { get; set; }

        /// <summary>
        /// List of private endpoint connection associated with the specified storage account
        /// </summary>
        public PrivateEndpointConnection[] PrivateEndpointConnections { get; set; }

        public RoutingPreference RoutingPreference { get; set; }

        public BlobRestoreStatus BlobRestoreStatus { get; set; }

        /// <summary>
        /// Allow or disallow public access to all blobs or containers in the storage account. The default interpretation is true for this property.
        /// </summary>
        public bool AllowBlobPublicAccess { get; set; }

        /// <summary>
        /// Set the minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property.
        /// </summary>
        public string MinimumTlsVersion { get; set; }

        /// <summary>
        /// Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key. If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD). The default value is null, which is equivalent to true.
        /// </summary>
        public bool AllowSharedKeyAccess { get; set; }

        /// <summary>
        /// NFS 3.0 protocol support enabled if set to true.
        /// </summary>
        public bool IsNfsV3Enabled { get; set; }

        /// <summary>
        /// Allow or disallow cross AAD tenant object replication. The default interpretation is true for this property.
        /// </summary>
        public bool AllowCrossTenantReplication { get; set; }
    }

    /// <summary>
    /// The parameters used to create the storage account.
    /// </summary>
    public class StorageAccountPropertiesCreateParameters
    {
        public SasPolicy SasPolicy { get; set; }

        public KeyPolicy KeyPolicy { get; set; }

        public CustomDomain CustomDomain { get; set; }

        public Encryption Encryption { get; set; }

        public NetworkRuleSet NetworkAcls { get; set; }

        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        public string AccessTier { get; set; }

        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        /// <summary>
        /// Allows https traffic only to storage service if sets to true. The default value is true since API version 2019-04-01.
        /// </summary>
        public bool SupportsHttpsTrafficOnly { get; set; }

        /// <summary>
        /// Account HierarchicalNamespace enabled if sets to true.
        /// </summary>
        public bool IsHnsEnabled { get; set; }

        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        public string LargeFileSharesState { get; set; }

        public RoutingPreference RoutingPreference { get; set; }

        /// <summary>
        /// Allow or disallow public access to all blobs or containers in the storage account. The default interpretation is true for this property.
        /// </summary>
        public bool AllowBlobPublicAccess { get; set; }

        /// <summary>
        /// Set the minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property.
        /// </summary>
        public string MinimumTlsVersion { get; set; }

        /// <summary>
        /// Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key. If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD). The default value is null, which is equivalent to true.
        /// </summary>
        public bool AllowSharedKeyAccess { get; set; }

        /// <summary>
        /// NFS 3.0 protocol support enabled if set to true.
        /// </summary>
        public bool IsNfsV3Enabled { get; set; }

        /// <summary>
        /// Allow or disallow cross AAD tenant object replication. The default interpretation is true for this property.
        /// </summary>
        public bool AllowCrossTenantReplication { get; set; }
    }

    /// <summary>
    /// The parameters used when updating a storage account.
    /// </summary>
    public class StorageAccountPropertiesUpdateParameters
    {
        public CustomDomain CustomDomain { get; set; }

        public Encryption Encryption { get; set; }

        public SasPolicy SasPolicy { get; set; }

        public KeyPolicy KeyPolicy { get; set; }

        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        public string AccessTier { get; set; }

        public AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }

        /// <summary>
        /// Allows https traffic only to storage service if sets to true.
        /// </summary>
        public bool SupportsHttpsTrafficOnly { get; set; }

        public NetworkRuleSet NetworkAcls { get; set; }

        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        public string LargeFileSharesState { get; set; }

        public RoutingPreference RoutingPreference { get; set; }

        /// <summary>
        /// Allow or disallow public access to all blobs or containers in the storage account. The default interpretation is true for this property.
        /// </summary>
        public bool AllowBlobPublicAccess { get; set; }

        /// <summary>
        /// Set the minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property.
        /// </summary>
        public string MinimumTlsVersion { get; set; }

        /// <summary>
        /// Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key. If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD). The default value is null, which is equivalent to true.
        /// </summary>
        public bool AllowSharedKeyAccess { get; set; }

        /// <summary>
        /// Allow or disallow cross AAD tenant object replication. The default interpretation is true for this property.
        /// </summary>
        public bool AllowCrossTenantReplication { get; set; }
    }

    /// <summary>
    /// The parameters used to regenerate the storage account key.
    /// </summary>
    public class StorageAccountRegenerateKeyParameters
    {
        /// <summary>
        /// The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2.
        /// </summary>
        public string KeyName { get; set; }
    }

    /// <summary>
    /// The parameters that can be provided when updating the storage account properties.
    /// </summary>
    public class StorageAccountUpdateParameters
    {
        /// <summary>
        /// The resource model definition representing SKU
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.
        /// </summary>
        public object Tags { get; set; }

        public Identity Identity { get; set; }

        public StorageAccountPropertiesUpdateParameters Properties { get; set; }

        /// <summary>
        /// Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.
        /// </summary>
        public string Kind { get; set; }
    }

    /// <summary>
    /// The response from the List Storage SKUs operation.
    /// </summary>
    public class StorageSkuListResult
    {
        /// <summary>
        /// Get the list result of storage SKUs and their properties.
        /// </summary>
        public SkuInformation[] Value { get; set; }
    }

    /// <summary>
    /// Blob index tag based filtering for blob objects
    /// </summary>
    public class TagFilter
    {
        /// <summary>
        /// This is the filter tag name, it can have 1 - 128 characters
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This is the comparison operator which is used for object comparison and filtering. Only == (equality operator) is currently supported
        /// </summary>
        public string Op { get; set; }

        /// <summary>
        /// This is the filter tag value field used for tag based filtering, it can have 0 - 256 characters
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// Describes Storage Resource Usage.
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// Gets the unit of measurement.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets the current count of the allocated resources in the subscription.
        /// </summary>
        public int CurrentValue { get; set; }

        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the subscription.
        /// </summary>
        public int Limit { get; set; }

        public UsageName Name { get; set; }
    }

    /// <summary>
    /// The response from the List Usages operation.
    /// </summary>
    public class UsageListResult
    {
        /// <summary>
        /// Gets or sets the list of Storage Resource Usages.
        /// </summary>
        public Usage[] Value { get; set; }
    }

    /// <summary>
    /// The usage names that can be used; currently limited to StorageAccount.
    /// </summary>
    public class UsageName
    {
        /// <summary>
        /// Gets a string describing the resource name.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets a localized string describing the resource name.
        /// </summary>
        public string LocalizedValue { get; set; }
    }

    /// <summary>
    /// UserAssignedIdentity for the resource.
    /// </summary>
    public class UserAssignedIdentity
    {
        /// <summary>
        /// The principal ID of the identity.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// The client ID of the identity.
        /// </summary>
        public string ClientId { get; set; }
    }

    /// <summary>
    /// Virtual Network rule.
    /// </summary>
    public class VirtualNetworkRule
    {
        /// <summary>
        /// Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The action of virtual network rule.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Gets the state of virtual network rule.
        /// </summary>
        public string State { get; set; }
    }
}