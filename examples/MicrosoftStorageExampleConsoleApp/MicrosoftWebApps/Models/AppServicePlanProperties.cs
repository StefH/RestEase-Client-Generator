using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// AppServicePlan resource specific properties
    /// </summary>
    public class AppServicePlanProperties
    {
        /// <summary>
        /// Target worker tier assigned to the App Service plan.
        /// </summary>
        public string WorkerTierName { get; set; }

        /// <summary>
        /// App Service plan status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// App Service plan subscription.
        /// </summary>
        public string Subscription { get; set; }

        /// <summary>
        /// Specification for an App Service Environment to use for this resource.
        /// </summary>
        public HostingEnvironmentProfile HostingEnvironmentProfile { get; set; }

        /// <summary>
        /// Maximum number of instances that can be assigned to this App Service plan.
        /// </summary>
        public int MaximumNumberOfWorkers { get; set; }

        /// <summary>
        /// Geographical location for the App Service plan.
        /// </summary>
        public string GeoRegion { get; set; }

        /// <summary>
        /// If true, apps assigned to this App Service plan can be scaled independently.If false, apps assigned to this App Service plan will scale to all instances of the plan.
        /// </summary>
        public bool PerSiteScaling { get; set; }

        /// <summary>
        /// ServerFarm supports ElasticScale. Apps in this plan will scale as if the ServerFarm was ElasticPremium sku
        /// </summary>
        public bool ElasticScaleEnabled { get; set; }

        /// <summary>
        /// Maximum number of total workers allowed for this ElasticScaleEnabled App Service Plan
        /// </summary>
        public int MaximumElasticWorkerCount { get; set; }

        /// <summary>
        /// Number of apps assigned to this App Service plan.
        /// </summary>
        public int NumberOfSites { get; set; }

        /// <summary>
        /// If true, this App Service Plan owns spot instances.
        /// </summary>
        public bool IsSpot { get; set; }

        /// <summary>
        /// The time when the server farm expires. Valid only if it is a spot server farm.
        /// </summary>
        public DateTime SpotExpirationTime { get; set; }

        /// <summary>
        /// The time when the server farm free offer expires.
        /// </summary>
        public DateTime FreeOfferExpirationTime { get; set; }

        /// <summary>
        /// Resource group of the App Service plan.
        /// </summary>
        public string ResourceGroup { get; set; }

        /// <summary>
        /// If Linux app service plan true, false otherwise.
        /// </summary>
        public bool Reserved { get; set; }

        /// <summary>
        /// Obsolete: If Hyper-V container app service plan true, false otherwise.
        /// </summary>
        public bool IsXenon { get; set; }

        /// <summary>
        /// If Hyper-V container app service plan true, false otherwise.
        /// </summary>
        public bool HyperV { get; set; }

        /// <summary>
        /// Scaling worker count.
        /// </summary>
        public int TargetWorkerCount { get; set; }

        /// <summary>
        /// Scaling worker size ID.
        /// </summary>
        public int TargetWorkerSizeId { get; set; }

        /// <summary>
        /// Provisioning state of the App Service Plan.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Specification for a Kubernetes Environment to use for this resource.
        /// </summary>
        public KubeEnvironmentProfile KubeEnvironmentProfile { get; set; }

        /// <summary>
        /// If true, this App Service Plan will perform availability zone balancing.If false, this App Service Plan will not perform availability zone balancing.
        /// </summary>
        public bool ZoneRedundant { get; set; }
    }
}