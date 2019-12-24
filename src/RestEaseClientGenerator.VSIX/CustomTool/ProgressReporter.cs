﻿using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace RestEaseClientGenerator.VSIX.CustomTool
{
    public class ProgressReporter : IProgressReporter
    {
        private readonly IVsGeneratorProgress pGenerateProgress;

        public ProgressReporter(IVsGeneratorProgress pGenerateProgress)
        {
            this.pGenerateProgress = pGenerateProgress;
        }

        public void Progress(uint progress, uint total = 100)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            pGenerateProgress.Progress(progress, total);
        }
    }
}
