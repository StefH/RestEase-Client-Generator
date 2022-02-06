using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Sample utterance.
    /// </summary>
    public class SampleUtterance
    {
        /// <summary>
        /// Text attribute of sample utterance.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Links attribute of sample utterance.
        /// </summary>
        public string[] Links { get; set; }

        /// <summary>
        /// Question id of sample utterance (for stackoverflow questions titles).
        /// </summary>
        public string Qid { get; set; }
    }
}