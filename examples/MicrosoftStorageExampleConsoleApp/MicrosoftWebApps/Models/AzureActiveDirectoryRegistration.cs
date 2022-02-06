using System;
using System.Collections.Generic;

namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The configuration settings of the Azure Active Directory app registration.
    /// </summary>
    public class AzureActiveDirectoryRegistration
    {
        /// <summary>
        /// The OpenID Connect Issuer URI that represents the entity which issues access tokens for this application.When using Azure Active Directory, this value is the URI of the directory tenant, e.g. https://login.microsoftonline.com/v2.0/{tenant-guid}/.This URI is a case-sensitive identifier for the token issuer.More information on OpenID Connect Discovery: http://openid.net/specs/openid-connect-discovery-1_0.html
        /// </summary>
        public string OpenIdIssuer { get; set; }

        /// <summary>
        /// The Client ID of this relying party application, known as the client_id.This setting is required for enabling OpenID Connection authentication with Azure Active Directory or other 3rd party OpenID Connect providers.More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The app setting name that contains the client secret of the relying party application.
        /// </summary>
        public string ClientSecretSettingName { get; set; }

        /// <summary>
        /// An alternative to the client secret, that is the thumbprint of a certificate used for signing purposes. This property acts asa replacement for the Client Secret. It is also optional.
        /// </summary>
        public string ClientSecretCertificateThumbprint { get; set; }

        /// <summary>
        /// An alternative to the client secret thumbprint, that is the subject alternative name of a certificate used for signing purposes. This property acts asa replacement for the Client Secret Certificate Thumbprint. It is also optional.
        /// </summary>
        public string ClientSecretCertificateSubjectAlternativeName { get; set; }

        /// <summary>
        /// An alternative to the client secret thumbprint, that is the issuer of a certificate used for signing purposes. This property acts asa replacement for the Client Secret Certificate Thumbprint. It is also optional.
        /// </summary>
        public string ClientSecretCertificateIssuer { get; set; }
    }
}