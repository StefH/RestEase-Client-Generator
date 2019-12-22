using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using RestEaseClientCodeGeneratorVSIX.Commands;
using RestEaseClientCodeGeneratorVSIX.Commands.AddNew;
using RestEaseClientCodeGeneratorVSIX.Commands.CustomTool;
using RestEaseClientCodeGeneratorVSIX.Options.AutoRest;
using RestEaseClientCodeGeneratorVSIX.Options.General;
using Task = System.Threading.Tasks.Task;

namespace RestEaseClientCodeGeneratorVSIX
{
    [ExcludeFromCodeCoverage]
    [Guid("47AFE4E1-0000-4FE1-8CA7-EDB8310BDA44")]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(VsixName, "", "1.0")]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideUIContextRule(
        CustomToolSetterCommand.ContextGuid,
        CustomToolSetterCommand.Name,
        CustomToolSetterCommand.Expression,
        new[] { CustomToolSetterCommand.Expression },
        new[] { CustomToolSetterCommand.TermValue })]
    [ProvideOptionPage(
        typeof(GeneralOptionPage),
        VsixName,
        GeneralOptionPage.Name,
        0,
        0,
        true)]
    [ProvideOptionPage(
        typeof(RestEaseOptionsPage),
        VsixName,
        RestEaseOptionsPage.Name,
        0,
        0,
        true)]

    public sealed class VsPackage : AsyncPackage
    {
        public const string VsixName = "RestEase Client Code Generator";

        private readonly ICommandInitializer[] _commands = {
            new NewRestEaseClientCommand()
        };

        public static AsyncPackage Instance { get; private set; }

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);
        
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            foreach (var command in _commands)
                await command.InitializeAsync(this, cancellationToken);
        }
    }
}