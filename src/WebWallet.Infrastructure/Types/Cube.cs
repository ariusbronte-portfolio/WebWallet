using System.Xml.Serialization;

namespace WebWallet.Infrastructure.Types
{
    [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public class Cube
    {
        [XmlAttribute(AttributeName = "currency")]
        public Currency Currency { get; set; }

        [XmlAttribute(AttributeName = "rate")] 
        public decimal Rate { get; set; }
    }
}