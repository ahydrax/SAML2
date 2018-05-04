using System.Collections.Generic;
using SAML2.Config;

namespace SAML2.Services
{
    public interface IIdentityProvidersSource
    {
        string SelectionUrl { get; }
        IdentityProvider GetById(string id);
        IEnumerable<IdentityProvider> GetAll();
    }
}
