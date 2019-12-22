using System.Threading;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace RestEaseClientGenerator.VSIX.Commands
{
    public interface ICommandInitializer
    {
        Task InitializeAsync(
            AsyncPackage package,
            CancellationToken token);
    }
}