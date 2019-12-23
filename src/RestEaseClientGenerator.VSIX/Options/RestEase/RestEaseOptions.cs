using System;
using System.Diagnostics;

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

                TODO = options.TODO;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                Trace.WriteLine(Environment.NewLine);
                Trace.WriteLine("Error reading user options. Reverting to default values");
                Trace.WriteLine($"TODO = {TODO}");

                TODO = false;
            }
        }

        public bool TODO { get; set; }
    }
}