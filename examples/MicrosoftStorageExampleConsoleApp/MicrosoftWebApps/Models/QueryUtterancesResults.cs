using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Suggested utterances where the detector can be applicable
    /// </summary>
    public class QueryUtterancesResults
    {
        /// <summary>
        /// Search Query.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Array of utterance results for search query.
        /// </summary>
        public QueryUtterancesResult[] Results { get; set; }
    }
}