using System;
using System.IO;
using System.Linq;
using CommandLine;
using DotNetRestEaseClientGenerator.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace DotNetRestEaseClientGenerator;

public class Program
{
    public class Options
    {
        [Option('f', "File", HelpText = "The Swagger or OpenApi file. Can be '.json' or '.raml'.", Required = true)]
        public string SourceFile { get; set; }

        [Option('d', "DestinationFolder", HelpText = "The destination folder to place the generated C# files.", Required = true)]
        public string DestinationFolder { get; set; }

        [Option('s', "SingleFile", HelpText = "Generate Single .cs file.", Default = true)]
        public bool SingleFile { get; set; }

        #region General
        [Option("ArrayType", HelpText = "The Array type to use.", Default = ArrayType.Array)]
        public ArrayType ArrayType { get; set; }

        [Option('n', "Namespace", HelpText = "The Namespace to use for the generated class file(s).", Required = true)]
        public string Namespace { get; set; }

        [Option("UseDateTimeOffset", HelpText = "Use DateTimeOffset instead of DateTime.", Default = false)]
        public bool UseDateTimeOffset { get; set; }

        [Option("ApiNamespace", HelpText = "Append this namespace for the Api.", Default = "Api")]
        public string ApiNamespace { get; set; }

        [Option("ModelsNamespace", HelpText = "Append this namespace for the Models.", Default = "Models")]
        public string ModelsNamespace { get; set; }

        [Option('g', "GenerationType", HelpText = "Define what should be generated.", Default = GenerationType.Both)]
        public GenerationType GenerationType { get; set; }

        [Option('e', "PreferredEnumType", HelpText = "Preferred Enum Type to generate. In case 'enum' is selected, enum classes are generated if needed.", Default = EnumType.String)]
        public EnumType PreferredEnumType { get; set; }
        #endregion

        #region Interface
        [Option('a', "ApiName", HelpText = "The base FileName of the generated .cs files.", Required = true)]
        public string ApiName { get; set; }

        [Option("MethodReturnType", HelpText = "The ReturnType to use for the methods. For more details see https://github.com/canton7/RestEase#return-types.", Default = MethodReturnType.Type)]
        public MethodReturnType MethodReturnType { get; set; }

        [Option("AppendAsync", HelpText = "Append Async postfix to all methods.", Default = true)]
        public bool AppendAsync { get; set; } = true;

        [Option("MultipartFormDataFileType", HelpText = "The MultipartFormData FileType to use.", Default = MultipartFormDataFileType.ByteArray)]
        public MultipartFormDataFileType MultipartFormDataFileType { get; set; }

        [Option("ApplicationOctetStreamType", HelpText = "The application/octet-stream type to use.", Default = MultipartFormDataFileType.ByteArray)]
        public ApplicationOctetStreamType ApplicationOctetStreamType { get; set; }

        [Option("GenerateMultipartFormDataExtensionMethods", HelpText = "Generate Extension methods for MultipartFormData methods.", Default = true)]
        public bool GenerateMultipartFormDataExtensionMethods { get; set; }

        [Option("GenerateApplicationOctetStreamExtensionMethods", HelpText = "Generate Extension methods for ApplicationOctetStream methods.", Default = true)]
        public bool GenerateApplicationOctetStreamExtensionMethods { get; set; } = true;

        [Option("GenerateFormUrlEncodedExtensionMethods", HelpText = "Generate Extension methods for FormUrlEncoded methods.", Default = true)]
        public bool GenerateFormUrlEncodedExtensionMethods { get; set; } = true;

        [Option("ReturnObjectFromMethod", HelpText = "Return Object from Method when Response is defined but no Model is specified.", Default = false)]
        public bool ReturnObjectFromMethodWhenResponseIsDefinedButNoModelIsSpecified { get; set; }

        [Option("PreferredContentType", HelpText = "Preferred Content-Type to use when both 'application/json' and 'application/xml' are defined.", Default = ContentType.ApplicationJson)]
        public ContentType PreferredContentType { get; set; }

        [Option("ForceContentTypeToApplicationJson", HelpText = "Always use Content-Type 'application/json', also when multiple Content-Types are are defined.", Default = false)]
        public bool ForceContentTypeToApplicationJson { get; set; }

        [Option("UseOperationIdAsMethodName", HelpText = "Use the OperationId as method name, if valid.", Default = true)]
        public bool UseOperationIdAsMethodName { get; set; } = true;

        [Option("PreferredSecurityDefinitionType", HelpText = "Preferred SecurityDefinition type to add to the interface.", Default = SecurityDefinitionType.Automatic)]
        public SecurityDefinitionType PreferredSecurityDefinitionType { get; set; } = SecurityDefinitionType.Automatic;

        [Option("MakeNonRequiredParametersOptional", HelpText = "Append '= null' to optional parameters in the interface methods.", Default = true)]
        public bool MakeNonRequiredParametersOptional { get; set; }

        [Option("DefineAllMethodHeadersOnInterface", HelpText = "Define all method-headers on the interface.", Default = false)]
        public bool DefineAllMethodHeadersOnInterface { get; set; }

        [Option("DefineSharedMethodQueryParametersOnInterface", HelpText = "Define all shared method query parameters on the interface.", Default = true)]
        public bool DefineSharedMethodQueryParametersOnInterface { get; set; }

        [Option("GenerateAndUseModelForAnyOfOrOneOf", HelpText = "Generate and use model for 'AnyOf' and 'OneOf' return types.", Default = true)]
        public bool GenerateAndUseModelForAnyOfOrOneOf { get; set; }

        [Option("PreferredMultipleResponsesType", HelpText = "Preferred MultipleResponsesType to use when multiple responses are defined for a path.", Default = MultipleResponsesType.AnyOf)]
        public MultipleResponsesType PreferredMultipleResponsesType { get; set; }
        #endregion

        #region Models
        [Option("GeneratePrimitivePropertiesAsNullable", HelpText = "Generate properties as nullable for OpenApi 2.0", Default = false)]
        public bool GeneratePrimitivePropertiesAsNullableForOpenApi20 { get; set; }

        [Option("SupportExtensionXNullable", HelpText = "Support vendor extension 'x-nullable' to indicate a property as nullable for OpenApi 2.0", Default = false)]
        public bool SupportExtensionXNullable { get; set; }
        #endregion
    }

    private static void Main(string[] args)
    {
        var logger = LoggerFactory.Create(o =>
        {
            o.SetMinimumLevel(LogLevel.Information);
            o.AddSimpleConsole(c => c.SingleLine = true);
        }).CreateLogger("RestEaseClientGenerator");


        logger.LogInformation("Starting");

        Parser.Default.ParseArguments<Options>(args).WithParsed(options => Run(options, logger));
    }

    private static void Run(Options options, ILogger logger)
    {
        var settings = TinyMapperUtils.Instance.Map<GeneratorSettings>(options);

        var generator = new Generator();

        try
        {
            var files = generator.FromFile(options.SourceFile, settings, out OpenApiDiagnostic diagnostic);
            if (diagnostic.Errors.Any())
            {
                logger.LogError("OpenApiDiagnostic Errors: {errors}", string.Format(",", diagnostic.Errors.Select(e => e.Message)));
                return;
            }

            foreach (var file in files)
            {
                var directory = Path.Combine(options.DestinationFolder, file.Path);
                Directory.CreateDirectory(directory);

                File.WriteAllText(Path.Combine(directory, file.Name), file.Content);
            }

            logger.LogInformation("File{0} generated in '{1}'.", files.Count > 0 ? "s" : string.Empty, options.DestinationFolder);
        }
        catch (Exception ex)
        {
            logger.LogCritical(ex, string.Empty);
        }
    }
}