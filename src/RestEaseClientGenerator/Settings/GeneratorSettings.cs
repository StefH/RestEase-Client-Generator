using System.ComponentModel;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Settings
{
    public class GeneratorSettings
    {
        [DisplayName("Generate Single .cs file")]
        [Description("Generate a Single .cs file. The default is 'True'.")]
        public bool SingleFile { get; set; } = true;

        #region General
        [DisplayName("Array Type")]
        [Description("The Array type to use. The default is 'T[]'.")]
        public ArrayType ArrayType { get; set; } = ArrayType.Array;

        [DisplayName("Namespace")]
        [Description("The Namespace to use for the generated class file(s).")]
        public string Namespace { get; set; }

        [DisplayName("Use DateTimeOffset")]
        [Description("Use DateTimeOffset instead of DateTime. The default value is 'False'.")]
        public bool UseDateTimeOffset { get; set; }

        [DisplayName("Namespace for the Api")]
        [Description("Append this namespace for the Api. The default value is 'Api'.")]
        public string ApiNamespace { get; set; } = "Api";

        [DisplayName("Namespace for the Models")]
        [Description("Append this namespace for the Models. The default value is 'Models'.")]
        public string ModelsNamespace { get; set; } = "Models";

        [DisplayName("Generate option")]
        [Description("Define what should be generated. The default value is 'Api and Models'.")]
        public GenerationType GenerationType { get; set; } = GenerationType.Both;

        [DisplayName("Preferred Enum Type to generate.")]
        [Description("Preferred Enum Type to generate. In case 'enum' is selected, enum classes are generated if needed. The default value is 'string'.")]
        public EnumType PreferredEnumType { get; set; } = EnumType.String;
        #endregion

        #region Models
        [DisplayName("Generate properties as nullable for OpenApi 2.0")]
        [Description("Generate all (primitive) properties as nullable for OpenApi 2.0, the default value is 'False'.")]
        public bool GeneratePrimitivePropertiesAsNullableForOpenApi20 { get; set; } = false;

        [DisplayName("Support 'x-nullable'")]
        [Description("Support vendor extension 'x-nullable' to indicate a property as nullable for OpenApi 2.0, the default value is 'False'.")]
        public bool SupportExtensionXNullable { get; set; } = false;
        #endregion

        #region Interface
        [DisplayName("Api FileName")]
        [Description("The base FileName of the generated .cs files.")]
        public string ApiName { get; set; }

        // public bool AddAuthorizationHeader { get; set; }

        [DisplayName("Method ReturnType")]
        [Description("The ReturnType to use for the methods. The default value is 'T'. For more details see https://github.com/canton7/RestEase#return-types.")]
        public MethodReturnType MethodReturnType { get; set; } = MethodReturnType.Type;

        [DisplayName("Append Async")]
        [Description("Append Async postfix to all methods. The default value is 'True'.")]
        public bool AppendAsync { get; set; } = true;

        [DisplayName("Type for multipart/form-data")]
        [Description("The MultipartFormData FileType to use. The default value is 'byte[]'.")]
        public MultipartFormDataFileType MultipartFormDataFileType { get; set; } = MultipartFormDataFileType.ByteArray;

        [DisplayName("Type for application/octet-stream")]
        [Description("The ApplicationOctetStream Type to use. The default value is 'byte[]'.")]
        public ApplicationOctetStreamType ApplicationOctetStreamType { get; set; } = ApplicationOctetStreamType.ByteArray;

        [DisplayName("Generate MultipartFormData Extension methods")]
        [Description("Generate Extension methods for MultipartFormData methods. The default value is 'True'.")]
        public bool GenerateMultipartFormDataExtensionMethods { get; set; } = true;

        [DisplayName("Generate ApplicationOctetStream Extension methods")]
        [Description("Generate Extension methods for ApplicationOctetStream methods. The default value is 'True'.")]
        public bool GenerateApplicationOctetStreamExtensionMethods { get; set; } = true;

        [DisplayName("Generate FormUrlEncoded Extension methods")]
        [Description("Generate Extension methods for FormUrlEncoded methods. The default value is 'True'.")]
        public bool GenerateFormUrlEncodedExtensionMethods { get; set; } = true;

        [DisplayName("Return Object from Method")]
        [Description("Return Object from Method when Response is defined but no Model is specified. The default value is 'False'.")]
        public bool ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified { get; set; }

        [DisplayName("Preferred Content-Type")]
        [Description("Preferred Content-Type to use when both 'application/json' and 'application/xml' are defined. The default value is 'application/json'.")]
        public ContentType PreferredContentType { get; set; }

        [DisplayName("Force Content-Type to 'application/json'")]
        [Description("Always use Content-Type 'application/json', also when multiple Content-Types are are defined. The default value is 'False'.")]
        public bool ForceContentTypeToApplicationJson { get; set; }

        [DisplayName("Use OperationId as method name")]
        [Description("Use the OperationId as method name, if valid. The default value is 'True'.")]
        public bool UseOperationIdAsMethodName { get; set; } = true;

        [DisplayName("Preferred SecurityDefinition")]
        [Description("Preferred SecurityDefinition type to add to the interface. The default value is 'Automatic'.")]
        public SecurityDefinitionType PreferredSecurityDefinitionType { get; set; } = SecurityDefinitionType.Automatic;

        [DisplayName("Make NonRequired parameters optional")]
        [Description("Append '= null' to optional parameters in the interface methods. The default value is 'True'.")]
        public bool MakeNonRequiredParametersOptional { get; set; } = true;

        [DisplayName("Define headers on interface")]
        [Description("Define all method-headers on the interface. The default value is 'False'.")]
        public bool DefineAllMethodHeadersOnInterface { get; set; } = false;

        [DisplayName("Define shared query parameters on interface")]
        [Description("Define all shared method query parameters on the interface. The default value is 'True'.")]
        public bool DefineSharedMethodQueryParametersOnInterface { get; set; } = true;

        [DisplayName("Generate and use model for 'AnyOf' and 'OneOf'")]
        [Description("Generate and use model for 'AnyOf' and 'OneOf' return types. The default value is 'True'.")]
        public bool GenerateAndUseModelForAnyOfOrOneOf { get; set; } = true;
        #endregion
    }
}