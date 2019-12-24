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
            }
            catch (Exception e)
            {
                ArrayType = ArrayType.Array;
                FailOnOpenApiErrors = false;

                Trace.WriteLine(e);
                Trace.WriteLine(Environment.NewLine);
                Trace.WriteLine("Error reading user options. Reverting to default values");
                Trace.WriteLine($"{nameof(ArrayType)} = {ArrayType}");
                Trace.WriteLine($"{nameof(FailOnOpenApiErrors)} = {FailOnOpenApiErrors}");
            }
        }

        public ArrayType ArrayType { get; set; }

        public bool FailOnOpenApiErrors { get; set; }
    }
}