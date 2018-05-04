using SAML2.Config;
using System;

namespace SAML2.Bindings
{
    /// <summary>
    /// Utility functions for use in binding implementations.
    /// </summary>
    public class BindingUtility
    {
        /// <summary>
        /// Validates the SAML20Federation configuration.
        /// </summary>
        /// <returns>True if validation passes, false otherwise</returns>
        public static bool ValidateConfiguration(Saml2Configuration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config), ErrorMessages.ConfigMissingSaml2Element);
            }

            if (config.ServiceProvider == null)
            {
                throw new ArgumentOutOfRangeException(nameof(config), ErrorMessages.ConfigMissingServiceProviderElement);
            }

            if (string.IsNullOrEmpty(config.ServiceProvider.Id))
            {
                throw new ArgumentOutOfRangeException(nameof(config), ErrorMessages.ConfigMissingServiceProviderIdAttribute);
            }

            if (config.ServiceProvider.SigningCertificate == null)
            {
                throw new ArgumentOutOfRangeException(nameof(config), ErrorMessages.ConfigMissingSigningCertificateElement);
            }

            // This will throw if no certificate or multiple certificates are found
            var certificate = config.ServiceProvider.SigningCertificate;
            if (!certificate.HasPrivateKey)
            {
                throw new ArgumentOutOfRangeException(nameof(config), ErrorMessages.ConfigSigningCertificateMissingPrivateKey);
            }

            if (config.IdentityProvidersSource == null)
            {
                throw new ArgumentOutOfRangeException(nameof(config), ErrorMessages.ConfigMissingIdentityProvidersElement);
            }

            return true;
        }
    }
}
