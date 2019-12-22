using System.Threading;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace RestEaseClientCodeGeneratorVSIX.Commands
{
    public interface ICommandInitializer
    {
        Task InitializeAsync(
            AsyncPackage package,
            CancellationToken token);
    }
}