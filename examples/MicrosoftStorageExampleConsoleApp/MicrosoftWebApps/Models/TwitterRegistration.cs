using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the app registration for the Twitter provider.
    /// </summary>
    public class TwitterRegistration
    {
        /// <summary>
        /// The OAuth 1.0a consumer key of the Twitter application used for sign-in.This setting is required for enabling Twitter Sign-In.Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// The app setting name that contains the OAuth 1.0a consumer secret of the Twitterapplication used for sign-in.
        /// </summary>
        public string ConsumerSecretSettingName { get; set; }
    }
}