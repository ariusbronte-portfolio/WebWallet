using System.Xml.Serialization;

namespace WebWallet.Infrastructure.Types
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
    public class Envelope
    {
        [XmlElement(ElementName = "subject", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        public string Subject { get; set; }

        [XmlElement(ElementName = "Sender", Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        public Sender Sender { get; set; }

        [XmlElement(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public TopCube Cube { get; set; }

        [XmlAttribute(AttributeName = "gesmes", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Gesmes { get; set; }

        [XmlAttribute(AttributeName = "xmlns", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xmlns { get; set; }
    }
}