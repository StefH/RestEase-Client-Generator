using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Defines a unique Support Topic
    /// </summary>
    public class SupportTopic
    {
        /// <summary>
        /// Support Topic Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Unique resource Id
        /// </summary>
        public string PesId { get; set; }
    }
}