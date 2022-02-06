using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// ProcessInfo resource specific properties
    /// </summary>
    public class ProcessInfoProperties
    {
        /// <summary>
        /// ARM Identifier for deployment.
        /// </summary>
        public int Identifier { get; set; }

        /// <summary>
        /// Deployment name.
        /// </summary>
        public string DeploymentName { get; set; }

        /// <summary>
        /// HRef URI.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Minidump URI.
        /// </summary>
        public string Minidump { get; set; }

        /// <summary>
        /// Is profile running?
        /// </summary>
        public bool IsProfileRunning { get; set; }

        /// <summary>
        /// Is the IIS Profile running?
        /// </summary>
        public bool IsIisProfileRunning { get; set; }

        /// <summary>
        /// IIS Profile timeout (seconds).
        /// </summary>
        public double IisProfileTimeoutInSeconds { get; set; }

        /// <summary>
        /// Parent process.
        /// </summary>
        public string Parent { get; set; }

        /// <summary>
        /// Child process list.
        /// </summary>
        public string[] Children { get; set; }

        /// <summary>
        /// Thread list.
        /// </summary>
        public ProcessThreadInfo[] Threads { get; set; }

        /// <summary>
        /// List of open files.
        /// </summary>
        public string[] OpenFileHandles { get; set; }

        /// <summary>
        /// List of modules.
        /// </summary>
        public ProcessModuleInfo[] Modules { get; set; }

        /// <summary>
        /// File name of this process.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Command line.
        /// </summary>
        public string CommandLine { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Handle count.
        /// </summary>
        public int HandleCount { get; set; }

        /// <summary>
        /// Module count.
        /// </summary>
        public int ModuleCount { get; set; }

        /// <summary>
        /// Thread count.
        /// </summary>
        public int ThreadCount { get; set; }

        /// <summary>
        /// Start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Total CPU time.
        /// </summary>
        public string TotalCpuTime { get; set; }

        /// <summary>
        /// User CPU time.
        /// </summary>
        public string UserCpuTime { get; set; }

        /// <summary>
        /// Privileged CPU time.
        /// </summary>
        public string PrivilegedCpuTime { get; set; }

        /// <summary>
        /// Working set.
        /// </summary>
        public long WorkingSet { get; set; }

        /// <summary>
        /// Peak working set.
        /// </summary>
        public long PeakWorkingSet { get; set; }

        /// <summary>
        /// Private memory size.
        /// </summary>
        public long PrivateMemory { get; set; }

        /// <summary>
        /// Virtual memory size.
        /// </summary>
        public long VirtualMemory { get; set; }

        /// <summary>
        /// Peak virtual memory usage.
        /// </summary>
        public long PeakVirtualMemory { get; set; }

        /// <summary>
        /// Paged system memory.
        /// </summary>
        public long PagedSystemMemory { get; set; }

        /// <summary>
        /// Non-paged system memory.
        /// </summary>
        public long NonPagedSystemMemory { get; set; }

        /// <summary>
        /// Paged memory.
        /// </summary>
        public long PagedMemory { get; set; }

        /// <summary>
        /// Peak paged memory.
        /// </summary>
        public long PeakPagedMemory { get; set; }

        /// <summary>
        /// Time stamp.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// List of environment variables.
        /// </summary>
        public Dictionary<string, string> EnvironmentVariables { get; set; }

        /// <summary>
        /// Is this the SCM site?
        /// </summary>
        public bool IsScmSite { get; set; }

        /// <summary>
        /// Is this a Web Job?
        /// </summary>
        public bool IsWebjob { get; set; }

        /// <summary>
        /// Description of process.
        /// </summary>
        public string Description { get; set; }
    }
}