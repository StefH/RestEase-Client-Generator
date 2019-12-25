using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace RestEaseClientGenerator.VSIX.CustomTool
{
    public class ProgressReporter : IProgressReporter
    {
        private readonly IVsGeneratorProgress _generateProgress;

        public ProgressReporter(IVsGeneratorProgress pGenerateProgress)
        {
            _generateProgress = pGenerateProgress;
        }

        public void Progress(uint progress, uint total = 100)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            _generateProgress.Progress(progress, total);
        }
    }
}