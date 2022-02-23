using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// Details about restoring a deleted app.
    /// </summary>
    public class DeletedAppRestoreRequest : ProxyOnlyResource 
    {
        /// <summary>
        /// DeletedAppRestoreRequest resource specific properties
        /// </summary>
        public DeletedAppRestoreRequestProperties Properties { get; set; }

    }
}