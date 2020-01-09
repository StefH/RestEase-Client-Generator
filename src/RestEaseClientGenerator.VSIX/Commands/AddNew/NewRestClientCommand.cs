using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Windows;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using RestEaseClientGenerator.VSIX.Extensions;
using VSLangProj;
using Task = System.Threading.Tasks.Task;

namespace RestEaseClientGenerator.VSIX.Commands.AddNew
{
    [ExcludeFromCodeCoverage]
    public abstract class NewRestClientCommand : ICommandInitializer
    {
        protected Guid CommandSet { get; } = new Guid("E4B99F94-0000-4CAA-ADCD-24302C232938");

        protected virtual int CommandId { get; } = 0x100;
        protected abstract SupportedCodeGenerator CodeGenerator { get; }

        public Task InitializeAsync(AsyncPackage package, CancellationToken token)
            => package.SetupCommandAsync(CommandSet, CommandId, OnExecuteAsync, token);

        private async Task OnExecuteAsync(DTE dte, AsyncPackage package)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var result = EnterOpenApiSpecDialog.GetResult();
            if (result == null)
                return;

            var selectedItem = ProjectExtensions.GetSelectedItem();
            var folder = FindFolder(selectedItem, dte);
            if (string.IsNullOrWhiteSpace(folder))
            {
                Trace.WriteLine("Unable to get folder name");
                return;
            }

            var contents = result.OpenApiSpecification;
            var filename = result.OutputFilename + ".json";

            var filePath = Path.Combine(folder, filename);
            File.WriteAllText(filePath, contents);

            var fileInfo = new FileInfo(filePath);
            var project = ProjectExtensions.GetActiveProject(dte);
            var projectItem = project.AddFileToProject(dte, fileInfo, "None");
            projectItem.Properties.Item("BuildAction").Value = prjBuildAction.prjBuildActionNone;

            var customTool = CodeGenerator.GetCustomToolName();
            projectItem.Properties.Item("CustomTool").Value = customTool;

            await project.InstallMissingPackagesAsync(package, CodeGenerator);
        }

        private static string FindFolder(object item, DTE dte)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            switch (item)
            {
                case ProjectItem projectItem:
                    return File.Exists(projectItem.FileNames[1])
                        ? Path.GetDirectoryName(projectItem.FileNames[1])
                        : projectItem.FileNames[1];

                case Project project:
                    return project.GetRootFolder(dte);

                default:
                    return null;
            }
        }
    }
}