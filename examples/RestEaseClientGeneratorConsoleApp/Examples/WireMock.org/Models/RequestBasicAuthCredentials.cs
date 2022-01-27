using System;
using System.Collections.Generic;

namespace WireMockOrg.Models
{
    /// <summary>
    /// Pre-emptive basic auth credentials to match against
    /// </summary>
    public class RequestBasicAuthCredentials
    {
        public string Password { get; set; }

        public string Username { get; set; }
    }
}