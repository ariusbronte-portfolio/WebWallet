using System.Xml.Serialization;

namespace WebWallet.Infrastructure.Types
{
    [XmlRoot(ElementName = "Cube", Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public class TimeCube
    {
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }

        [XmlElement(ElementName = "Cube")] 
        public Cube[] Cube { get; set; }
    }
}