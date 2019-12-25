using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Shell;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.VSIX.Options.RestEase
{
    [ExcludeFromCodeCoverage]
    public class RestEaseOptionsPage : DialogPage, IRestEaseOptions
    {
        private const string General = "General";
        private const string Interface = "Interface";

        #region General
        [Category(General)]
        [DisplayName("ArrayType")]
        [Description("The Array type to use. The default is Array '[]'.")]
        [PropertyPageTypeConverter(typeof(EnumDescriptionConverter))]
        public ArrayType ArrayType { get; set; }

        [Category(General)]
        [DisplayName("Fail on OpenApi Errors")]
        [Description("Don't generate the file if errors are detected when parsing the specification file. The default value is 'false'.")]
        public bool FailOnOpenApiErrors { get; set; }

        [Category(Interface)]
        [DisplayName("Use DateTimeOffset")]
        [Description("Use DateTimeOffset instead of DateTime. The default value is 'false'.")]
        public bool UseDateTimeOffset { get; set; }
        #endregion

        #region Interface
        [Category(Interface)]
        [DisplayName("Add Authorization header")]
        [Description("Add an Authorization header to the generated interface. The default value is 'false'.")]
        public bool AddAuthorizationHeader { get; set; }

        [Category(Interface)]
        [DisplayName("Append Async")]
        [Description("Append Async postfix to all methods. The default value is 'true'.")]
        public bool AppendAsync { get; set; } = true;

        [Category(Interface)]
        [DisplayName("Method ReturnType")]
        [Description("The ReturnType to use for the methods. The default value is 'Type'. For more details see https://github.com/canton7/RestEase#return-types.")]
        [PropertyPageTypeConverter(typeof(EnumDescriptionConverter))]
        public MethodReturnType MethodReturnType { get; set; }
        #endregion
    }
}