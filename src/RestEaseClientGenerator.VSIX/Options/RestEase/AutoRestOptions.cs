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

                AddCredentials = options.AddCredentials;
                OverrideClientName = options.OverrideClientName;
                UseInternalConstructors = options.UseInternalConstructors;
                //SyncMethods = options.SyncMethods;
                UseDateTimeOffset = options.UseDateTimeOffset;
                ClientSideValidation = options.ClientSideValidation;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                Trace.WriteLine(Environment.NewLine);
                Trace.WriteLine("Error reading user options. Reverting to default values");
                Trace.WriteLine($"AddCredentials = {AddCredentials}");
                Trace.WriteLine($"OverrideClientName = {OverrideClientName}");
                Trace.WriteLine($"UseInternalConstructors = {UseInternalConstructors}");
                // Trace.WriteLine($"SyncMethods = {SyncMethods}");
                Trace.WriteLine($"UseDateTimeOffset = {UseDateTimeOffset}");
                Trace.WriteLine($"UseDateTimeOClientSideValidationffset = {ClientSideValidation}");

                AddCredentials = false;
                OverrideClientName = false;
                UseInternalConstructors = false;
                UseDateTimeOffset = false;
                ClientSideValidation = true;
            }
        }

        public bool AddCredentials { get; set; }
        public bool OverrideClientName { get; set; }
        public bool UseInternalConstructors { get; set; }
        // public SyncMethodOptions SyncMethods { get; set; }
        public bool UseDateTimeOffset { get; set; }
        public bool ClientSideValidation { get; set; }
    }
}