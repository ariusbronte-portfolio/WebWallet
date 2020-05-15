using System.Xml.Serialization;

namespace WebWallet.Infrastructure.Types
{
    [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public class TopCube
    {
        [XmlElement(ElementName = "Cube")]
        public TimeCube TimeCube { get; set; }
    }
}