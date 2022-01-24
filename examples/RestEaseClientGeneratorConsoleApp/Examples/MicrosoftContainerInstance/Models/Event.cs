using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.MicrosoftContainerInstance.Models
{
    /// <summary>
    /// A container group or container instance event.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// The count of the event.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The date-time of the earliest logged event.
        /// </summary>
        public DateTime FirstTimestamp { get; set; }

        /// <summary>
        /// The date-time of the latest logged event.
        /// </summary>
        public DateTime LastTimestamp { get; set; }

        /// <summary>
        /// The event name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The event message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The event type.
        /// </summary>
        public string Type { get; set; }
    }
}