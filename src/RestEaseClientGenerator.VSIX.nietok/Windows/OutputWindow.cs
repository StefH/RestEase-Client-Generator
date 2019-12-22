using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

#pragma warning disable VSTHRD010 // Invoke single-threaded types on Main thread

namespace RestEaseClientCodeGeneratorVSIX.Windows
{
    [ExcludeFromCodeCoverage]
    public static class OutputWindow
    {
        private static string _name;
        private static IVsOutputWindowPane _pane;
        private static IVsOutputWindow _output;

        public static void Initialize(IServiceProvider provider, string outputSource)
        {
            if (_output != null)
                return;

            ThreadHelper.ThrowIfNotOnUIThread();
            _output = (IVsOutputWindow)provider.GetService(typeof(SVsOutputWindow));
            Assumes.Present(_output);
            _name = outputSource;

            Trace.Listeners.Add(new OutputWindowTraceListener());
        }
        
        public static void Log(object message)
        {
            try
            {
                if (EnsurePane()) 
                    _pane.OutputString($"{DateTime.Now}: {message}{Environment.NewLine}");
            }
            catch
            {
                // ignored
            }
        }
        
        private static bool EnsurePane()
        {
            if (_pane != null)
                return true;

            var guid = Guid.NewGuid();
            _output.CreatePane(ref guid, _name, 1, 1);
            _output.GetPane(ref guid, out _pane);
            return _pane != null;
        }
    }
}
#pragma warning restore VSTHRD010 // Invoke single-threaded types on Main thread