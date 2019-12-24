using System;
using System.Diagnostics;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.VSIX.Options.RestEase
{
    public class RestEaseOptions : OptionsBase<IRestEaseOptions, RestEaseOptionsPage>, IRestEaseOptions
    {
        public RestEaseOptions(IRestEaseOptions options)
        {
            try
            {
                if (options == null)
                {
                    options = GetFromDialogPage();
                }

                ArrayType = options.ArrayType;
                FailOnOpenApiErrors = options.FailOnOpenApiErrors;
                AddAuthorizationHeader = options.AddAuthorizationHeader;
                UseDateTimeOffset = options.UseDateTimeOffset;
            }
            catch (Exception e)
            {
                ArrayType = ArrayType.Array;
                FailOnOpenApiErrors = false;
                AddAuthorizationHeader = false;
                UseDateTimeOffset = false;

                Trace.WriteLine(e);
                Trace.WriteLine(Environment.NewLine);
                Trace.WriteLine("Error reading user options. Reverting to default values");
                Trace.WriteLine($"{nameof(ArrayType)} = {ArrayType}");
                Trace.WriteLine($"{nameof(FailOnOpenApiErrors)} = {FailOnOpenApiErrors}");
                Trace.WriteLine($"{nameof(AddAuthorizationHeader)} = {AddAuthorizationHeader}");
                Trace.WriteLine($"{nameof(UseDateTimeOffset)} = {UseDateTimeOffset}");
            }
        }

        public ArrayType ArrayType { get; set; }

        public bool FailOnOpenApiErrors { get; set; }

        public bool AddAuthorizationHeader { get; set; }

        public bool UseDateTimeOffset { get; set; }
    }
}