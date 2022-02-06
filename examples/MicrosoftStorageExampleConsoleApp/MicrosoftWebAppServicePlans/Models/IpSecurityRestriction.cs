using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// IP security restriction on an app.
    /// </summary>
    public class IpSecurityRestriction
    {
        /// <summary>
        /// IP address the security restriction is valid for.It can be in form of pure ipv4 address (required SubnetMask property) orCIDR notation such as ipv4/mask (leading bit match). For CIDR,SubnetMask property must not be specified.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Subnet mask for the range of IP addresses the restriction is valid for.
        /// </summary>
        public string SubnetMask { get; set; }

        /// <summary>
        /// Virtual network resource id
        /// </summary>
        public string VnetSubnetResourceId { get; set; }

        /// <summary>
        /// (internal) Vnet traffic tag
        /// </summary>
        public int VnetTrafficTag { get; set; }

        /// <summary>
        /// (internal) Subnet traffic tag
        /// </summary>
        public int SubnetTrafficTag { get; set; }

        /// <summary>
        /// Allow or Deny access for this IP range.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Defines what this IP filter will be used for. This is to support IP filtering on proxies.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Priority of IP restriction rule.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// IP restriction rule name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IP restriction rule description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// IP restriction rule headers.X-Forwarded-Host (https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Forwarded-Host#Examples). The matching logic is ..- If the property is null or empty (default), all hosts(or lack of) are allowed.- A value is compared using ordinal-ignore-case (excluding port number).- Subdomain wildcards are permitted but don't match the root domain. For example, *.contoso.com matches the subdomain foo.contoso.com but not the root domain contoso.com or multi-level foo.bar.contoso.com- Unicode host names are allowed but are converted to Punycode for matching.X-Forwarded-For (https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Forwarded-For#Examples).The matching logic is ..- If the property is null or empty (default), any forwarded-for chains (or lack of) are allowed.- If any address (excluding port number) in the chain (comma separated) matches the CIDR defined by the property.X-Azure-FDID and X-FD-HealthProbe.The matching logic is exact match.
        /// </summary>
        public Dictionary<string, string[]> Headers { get; set; }
    }
}