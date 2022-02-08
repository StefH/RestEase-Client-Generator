using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebAppServicePlans.Models
{
    /// <summary>
    /// Routing rules for ramp up testing. This rule allows to redirect static traffic % to a slot or to gradually change routing % based on performance.
    /// </summary>
    public class RampUpRule
    {
        /// <summary>
        /// Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
        /// </summary>
        public string ActionHostName { get; set; }

        /// <summary>
        /// Percentage of the traffic which will be redirected to ActionHostName.
        /// </summary>
        public double ReroutePercentage { get; set; }

        /// <summary>
        /// In auto ramp up scenario this is the step to add/remove from ReroutePercentage until it reaches \nMinReroutePercentage or MaxReroutePercentage. Site metrics are checked every N minutes specified in ChangeIntervalInMinutes.\nCustom decision algorithm can be provided in TiPCallback site extension which URL can be specified in ChangeDecisionCallbackUrl.
        /// </summary>
        public double ChangeStep { get; set; }

        /// <summary>
        /// Specifies interval in minutes to reevaluate ReroutePercentage.
        /// </summary>
        public int ChangeIntervalInMinutes { get; set; }

        /// <summary>
        /// Specifies lower boundary above which ReroutePercentage will stay.
        /// </summary>
        public double MinReroutePercentage { get; set; }

        /// <summary>
        /// Specifies upper boundary below which ReroutePercentage will stay.
        /// </summary>
        public double MaxReroutePercentage { get; set; }

        /// <summary>
        /// Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.https://www.siteextensions.net/packages/TiPCallback/
        /// </summary>
        public string ChangeDecisionCallbackUrl { get; set; }

        /// <summary>
        /// Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
        /// </summary>
        public string Name { get; set; }
    }
}