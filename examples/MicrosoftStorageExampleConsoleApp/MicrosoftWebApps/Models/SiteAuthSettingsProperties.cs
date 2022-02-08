using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// SiteAuthSettings resource specific properties
    /// </summary>
    public class SiteAuthSettingsProperties
    {
        /// <summary>
        /// true if the Authentication / Authorization feature is enabled for the current app; otherwise, false.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The RuntimeVersion of the Authentication / Authorization feature in use for the current app.The setting in this value can control the behavior of certain features in the Authentication / Authorization module.
        /// </summary>
        public string RuntimeVersion { get; set; }

        /// <summary>
        /// The action to take when an unauthenticated client attempts to access the app.
        /// </summary>
        public string UnauthenticatedClientAction { get; set; }

        /// <summary>
        /// true to durably store platform-specific security tokens that are obtained during login flows; otherwise, false. The default is false.
        /// </summary>
        public bool TokenStoreEnabled { get; set; }

        /// <summary>
        /// External URLs that can be redirected to as part of logging in or logging out of the app. Note that the query string part of the URL is ignored.This is an advanced setting typically only needed by Windows Store application backends.Note that URLs within the current domain are always implicitly allowed.
        /// </summary>
        public string[] AllowedExternalRedirectUrls { get; set; }

        /// <summary>
        /// The default authentication provider to use when multiple providers are configured.This setting is only needed if multiple providers are configured and the unauthenticated clientaction is set to "RedirectToLoginPage".
        /// </summary>
        public string DefaultProvider { get; set; }

        /// <summary>
        /// The number of hours after session token expiration that a session token can be used tocall the token refresh API. The default is 72 hours.
        /// </summary>
        public double TokenRefreshExtensionHours { get; set; }

        /// <summary>
        /// The Client ID of this relying party application, known as the client_id.This setting is required for enabling OpenID Connection authentication with Azure Active Directory or other 3rd party OpenID Connect providers.More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The Client Secret of this relying party application (in Azure Active Directory, this is also referred to as the Key).This setting is optional. If no client secret is configured, the OpenID Connect implicit auth flow is used to authenticate end users.Otherwise, the OpenID Connect Authorization Code Flow is used to authenticate end users.More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// The app setting name that contains the client secret of the relying party application.
        /// </summary>
        public string ClientSecretSettingName { get; set; }

        /// <summary>
        /// An alternative to the client secret, that is the thumbprint of a certificate used for signing purposes. This property acts asa replacement for the Client Secret. It is also optional.
        /// </summary>
        public string ClientSecretCertificateThumbprint { get; set; }

        /// <summary>
        /// The OpenID Connect Issuer URI that represents the entity which issues access tokens for this application.When using Azure Active Directory, this value is the URI of the directory tenant, e.g. https://sts.windows.net/{tenant-guid}/.This URI is a case-sensitive identifier for the token issuer.More information on OpenID Connect Discovery: http://openid.net/specs/openid-connect-discovery-1_0.html
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets a value indicating whether the issuer should be a valid HTTPS url and be validated as such.
        /// </summary>
        public bool ValidateIssuer { get; set; }

        /// <summary>
        /// Allowed audience values to consider when validating JWTs issued by Azure Active Directory. Note that the ClientID value is always considered anallowed audience, regardless of this setting.
        /// </summary>
        public string[] AllowedAudiences { get; set; }

        /// <summary>
        /// Login parameters to send to the OpenID Connect authorization endpoint whena user logs in. Each parameter must be in the form "key=value".
        /// </summary>
        public string[] AdditionalLoginParams { get; set; }

        /// <summary>
        /// Gets a JSON string containing the Azure AD Acl settings.
        /// </summary>
        public string AadClaimsAuthorization { get; set; }

        /// <summary>
        /// The OpenID Connect Client ID for the Google web application.This setting is required for enabling Google Sign-In.Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        public string GoogleClientId { get; set; }

        /// <summary>
        /// The client secret associated with the Google web application.This setting is required for enabling Google Sign-In.Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        public string GoogleClientSecret { get; set; }

        /// <summary>
        /// The app setting name that contains the client secret associated with the Google web application.
        /// </summary>
        public string GoogleClientSecretSettingName { get; set; }

        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Google Sign-In authentication.This setting is optional. If not specified, "openid", "profile", and "email" are used as default scopes.Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        public string[] GoogleOAuthScopes { get; set; }

        /// <summary>
        /// The App ID of the Facebook app used for login.This setting is required for enabling Facebook Login.Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        public string FacebookAppId { get; set; }

        /// <summary>
        /// The App Secret of the Facebook app used for Facebook Login.This setting is required for enabling Facebook Login.Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        public string FacebookAppSecret { get; set; }

        /// <summary>
        /// The app setting name that contains the app secret used for Facebook Login.
        /// </summary>
        public string FacebookAppSecretSettingName { get; set; }

        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Facebook Login authentication.This setting is optional.Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        public string[] FacebookOAuthScopes { get; set; }

        /// <summary>
        /// The Client Id of the GitHub app used for login.This setting is required for enabling Github login
        /// </summary>
        public string GitHubClientId { get; set; }

        /// <summary>
        /// The Client Secret of the GitHub app used for Github Login.This setting is required for enabling Github login.
        /// </summary>
        public string GitHubClientSecret { get; set; }

        /// <summary>
        /// The app setting name that contains the client secret of the Githubapp used for GitHub Login.
        /// </summary>
        public string GitHubClientSecretSettingName { get; set; }

        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of GitHub Login authentication.This setting is optional
        /// </summary>
        public string[] GitHubOAuthScopes { get; set; }

        /// <summary>
        /// The OAuth 1.0a consumer key of the Twitter application used for sign-in.This setting is required for enabling Twitter Sign-In.Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        public string TwitterConsumerKey { get; set; }

        /// <summary>
        /// The OAuth 1.0a consumer secret of the Twitter application used for sign-in.This setting is required for enabling Twitter Sign-In.Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        public string TwitterConsumerSecret { get; set; }

        /// <summary>
        /// The app setting name that contains the OAuth 1.0a consumer secret of the Twitterapplication used for sign-in.
        /// </summary>
        public string TwitterConsumerSecretSettingName { get; set; }

        /// <summary>
        /// The OAuth 2.0 client ID that was created for the app used for authentication.This setting is required for enabling Microsoft Account authentication.Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
        /// </summary>
        public string MicrosoftAccountClientId { get; set; }

        /// <summary>
        /// The OAuth 2.0 client secret that was created for the app used for authentication.This setting is required for enabling Microsoft Account authentication.Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
        /// </summary>
        public string MicrosoftAccountClientSecret { get; set; }

        /// <summary>
        /// The app setting name containing the OAuth 2.0 client secret that was created for theapp used for authentication.
        /// </summary>
        public string MicrosoftAccountClientSecretSettingName { get; set; }

        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Microsoft Account authentication.This setting is optional. If not specified, "wl.basic" is used as the default scope.Microsoft Account Scopes and permissions documentation: https://msdn.microsoft.com/en-us/library/dn631845.aspx
        /// </summary>
        public string[] MicrosoftAccountOAuthScopes { get; set; }

        /// <summary>
        /// "true" if the auth config settings should be read from a file,"false" otherwise
        /// </summary>
        public string IsAuthFromFile { get; set; }

        /// <summary>
        /// The path of the config file containing auth settings.If the path is relative, base will the site's root directory.
        /// </summary>
        public string AuthFilePath { get; set; }

        /// <summary>
        /// The ConfigVersion of the Authentication / Authorization feature in use for the current app.The setting in this value can control the behavior of the control plane for Authentication / Authorization.
        /// </summary>
        public string ConfigVersion { get; set; }
    }
}