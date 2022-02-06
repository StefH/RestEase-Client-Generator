using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Result for utterances query.
    /// </summary>
    public class QueryUtterancesResult
    {
        /// <summary>
        /// Sample utterance.
        /// </summary>
        public SampleUtterance SampleUtterance { get; set; }

        /// <summary>
        /// Score of a sample utterance.
        /// </summary>
        public float Score { get; set; }
    }
}