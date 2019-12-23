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
                    options = GetFromDialogPage();

                ArrayType = options.ArrayType;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                Trace.WriteLine(Environment.NewLine);
                Trace.WriteLine("Error reading user options. Reverting to default values");
                Trace.WriteLine($"ArrayType = {ArrayType}");

                ArrayType = ArrayType.Array;
            }
        }

        public ArrayType ArrayType { get; set; }
    }
}