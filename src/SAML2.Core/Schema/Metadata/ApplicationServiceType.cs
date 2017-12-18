using System;
using System.Xml.Serialization;

namespace SAML2.Schema.Metadata
{
    [Serializable]
    [XmlType(TypeName = nameof(ApplicationServiceType), Namespace = Saml20Constants.Federation)]
    [XmlRoot(ElementName, Namespace = Saml20Constants.Federation, IsNullable = false)]
    public class ApplicationServiceType : RoleDescriptor
    {
    }
}
